using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elements_of_higher_mathematics.SystemOfEquations
{
    class Equations
    {
        // Левая часть.
        public string LeftPart { get; private set; }

        // Правая часть.
        public string RightPart { get; private set; }

        public Equations(string leftPart, string rightPart)
        {
            LeftPart = leftPart;
            RightPart = rightPart;
        }

        /// <summary>
        /// Метод переносящий элемент из левой части в правую.
        /// </summary>
        /// <param name="n1"> Номер 1 элемента. </param>
        /// <param name="n2"> Номер 2 элемента. </param>
        /// <returns> Уравнение. </returns>
        public Equations MovingFromLeftToRight(int n1, int n2)
        {
            // Массив элементов уравнения левой части.
            var leftPart = SeparationOfCharacters(LeftPart);

            // Массив элементов уравнения правой части.
            var rightPart = SeparationOfCharacters(RightPart);

            // Меняет знак на противоположный.
            leftPart[n1 - 1] = ChangesSign(leftPart[n1 - 1]);

            rightPart[n2 - 1] = ChangesSign(rightPart[n2 - 1]);

            // Меняет элементы местами.
            var tmp = leftPart[n1 - 1];

            leftPart[n1 - 1] = rightPart[n2 - 1];

            rightPart[n2 - 1] = tmp;

            // Возвращает значения.
            return new Equations(String.Join("", leftPart), String.Join("", rightPart));
        }

        /// <summary>
        /// Меняет знак на противоположный.
        /// </summary>
        /// <param name="item"> элемент знак которого надо изменить. </param>
        /// <returns> элемент знак которого был изменен. </returns>
        private string ChangesSign(string item)
        {
            if (item.First() == '-')
            {
                item = String.Join("", item.Skip(1));
            }
            else
            {
                item = "-" + item;
            }

            return item;
        }

        /// <summary>
        /// Метод разделяющий строку на элементы.
        /// </summary>
        /// <param name="item"> Строка. </param>
        /// <returns> Массив элементов. </returns>
        private static string[] SeparationOfCharacters(string item)
        {
            // Разделение строки на массив элементов уравнения с удалением пустых строк.
            string[] _string = item.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // Цикл обьединяющий знаки с их числами.
            for (int i = 0; i < _string.Length; i++)
            {
                // Проверка является ли этот элемент знаком +.
                if (_string[i] == "+")
                {
                    // если да то знак + прибавляется к следующему элементу.
                    _string[i] = $" + {_string[i + 1]}";

                    // удаляет следующий элемент.
                    Array.Clear(_string, i + 1, 1);
                }
                // Проверка является ли этот элемент знаком -.
                if (_string[i] == "-")
                {
                    // Проверка является ли следующее число отрицательным.
                    if (_string[i + 1].First() == '(' && _string[i + 1].Skip(1).First() == '-')
                    {
                        // Уберает скобки, добавляет знак + и сокращает знаки - . 
                        _string[i] = $" + {String.Join("", _string[i + 1].Skip(2).SkipLast(1))}";
                    }
                    else
                    {
                        // знак - прибавляется к следующему элементу.
                        _string[i] = $" - {_string[i + 1]}";
                    }

                    // удаляет следующий элемент.
                    Array.Clear(_string, i + 1, 1);
                }
                // Проверка является ли этот элемент null.
                if (_string[i] != null)
                {
                    // Проверка является ли этот элемент (.
                    if (_string[i].First() == '(')
                    {
                        // Уберает скобку. 
                        _string[i] = $"{String.Join("", _string[i].Skip(1))}";
                    }
                    // Проверка является ли этот элемент ).
                    if (_string[i].Last() == ')')
                    {
                        // Уберает скобку. 
                        _string[i] = $"{String.Join("", _string[i].SkipLast(1))}";
                    }
                }
            }

            // Удаляет все null элементы из массива.
            _string = _string.Where(c => c != null).ToArray();

            // Возвращает массив.
            return _string;
        }

        public override string ToString()
        {
            return $"{LeftPart} = {RightPart}";
        }
    }
}
