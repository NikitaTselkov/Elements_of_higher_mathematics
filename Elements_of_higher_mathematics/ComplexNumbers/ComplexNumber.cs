using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elements_of_higher_mathematics.ComplexNumbers
{
    class ComplexNumber
    {
        /// <summary>
        /// Действительная часть.
        /// </summary>
        public string RealPart { get; private set; }

        /// <summary>
        /// Мнимая часть.
        /// </summary>
        public string ImaginaryPart { get; private set; }

        /// <summary>
        /// Уравнение.
        /// </summary>
        public string Equation { get; private set; }

        # region Конструкторы

        public ComplexNumber(double realPart, double imaginaryPart)
        {
            RealPart = realPart.ToString();
            ImaginaryPart = imaginaryPart.ToString();
        }

        public ComplexNumber(string realPart, string imaginaryPart)
        {
            RealPart = realPart;
            ImaginaryPart = imaginaryPart;
        }

        public ComplexNumber(string realPart, double imaginaryPart)
        {
            RealPart = realPart;
            ImaginaryPart = imaginaryPart.ToString();
        }

        public ComplexNumber(double realPart, string imaginaryPart)
        {
            RealPart = realPart.ToString();
            ImaginaryPart = imaginaryPart.ToString();
        }

        public ComplexNumber(string equation)
        {
            Equation = equation;
        }

        #endregion

        /// <summary>
        /// Метод приводящий комплксное число к стандартному виду.
        /// </summary>
        public void MethodLeadingToStandardView()
        {
            // Действительная часть.
            var realPart = "";

            // Мнимая часть.
            var imaginaryPart = "";

            // Разделение строки на массив элементов уравнения с удалением пустых строк.
            string[] equationElements = Equation.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // Значение делителя.
            string dividedValue = "";

            //Если есть разделились.
            bool isHaveDivided = false;

            // Цикл обьединяющий знаки с их числами.
            for (int i = 0; i < equationElements.Length; i++)
            {
                // Проверка является ли этот элемент знаком +.
                if (equationElements[i] == "+")
                {
                    // если да то знак + прибавляется к следующему элементу.
                    equationElements[i] = $" + {equationElements[i + 1]}";

                    // удаляет следующий элемент.
                    Array.Clear(equationElements, i + 1, 1);
                }
                // Проверка является ли этот элемент знаком -.
                if (equationElements[i] == "-")
                {
                    // Проверка является ли следующее число отрицательным.
                    if (equationElements[i + 1].First() == '(' && equationElements[i + 1].Skip(1).First() == '-')
                    {
                        // Уберает скобки, добавляет знак + и сокращает знаки - . 
                        equationElements[i] = $" + {String.Join("", equationElements[i + 1].Skip(2).SkipLast(1))}";
                    }
                    else
                    {
                        // знак - прибавляется к следующему элементу.
                        equationElements[i] = $" - {equationElements[i + 1]}";
                    }

                    // удаляет следующий элемент.
                    Array.Clear(equationElements, i + 1, 1);
                }
                // Проверка является ли этот элемент знаком /.
                if (equationElements[i] == "/")
                {
                    // Устанавливает значение True.
                    isHaveDivided = true;

                    // Устанавливает значение делителя.
                    dividedValue = equationElements[i + 1];

                    // Знак / прибавляется к следующему элементу.
                    equationElements[i] = $" / {equationElements[i + 1]}";

                    // Удаляет следующий элемент.
                    Array.Clear(equationElements, i + 1, 1);
                }
                // Проверка является ли этот элемент null.
                if (equationElements[i] != null)
                {
                    // Проверка является ли этот элемент (.
                    if (equationElements[i].First() == '(')
                    {
                        // Уберает скобку. 
                        equationElements[i] = $"{String.Join("", equationElements[i].Skip(1))}";
                    }
                    // Проверка является ли этот элемент ).
                    if (equationElements[i].Last() == ')')
                    {
                        // Уберает скобку. 
                        equationElements[i] = $"{String.Join("", equationElements[i].SkipLast(1))}";
                    }
                }
            }

            // Удаляет все null элементы из массива.
            equationElements = equationElements.Where(c => c != null).ToArray();

            // Обьеденяет все действительные элементы.
            realPart = String.Join("", equationElements.Where(w => w.All(a => a.ToString() != "i")));

            // Обьеденяет все мнимые элементы.
            imaginaryPart = String.Join("", equationElements.Where(w => w.Any(a => a.ToString() == "i")));

            #region Проверка первых элементов

            if (imaginaryPart[0] == ' ')
            {
                imaginaryPart = String.Join("", imaginaryPart.Skip(1));
            }
            if (imaginaryPart[0] == '+')
            {
                imaginaryPart = String.Join("", imaginaryPart.Skip(2));
            }
            if (imaginaryPart[0] == '-')
            {
                imaginaryPart = String.Join("", imaginaryPart.Split(' ', 2));
            }

            if (realPart[0] == ' ')
            {
                realPart = String.Join("", realPart.Skip(1));
            }
            if (realPart[0] == '+')
            {
                realPart = String.Join("", realPart.Skip(2));
            }
            if (realPart[0] == '-')
            {
                realPart = String.Join("", realPart.Split(' ', 2));
            }

            #endregion

            // Если есть деление.
            if (isHaveDivided == true)
            {
                // Добавляет скобки вокруг мнимых элементов и выносит i за них.
                ImaginaryPart = $"({String.Join("", imaginaryPart.Split('i'))} / {dividedValue})";
            }
            else
            {
                // Добавляет скобки вокруг мнимых элементов и выносит i за них.
                ImaginaryPart = $"({String.Join("", imaginaryPart.Split('i'))})";
            }           

            // Добавляет скобки вокруг действительных элементов.
            RealPart = $"({realPart})";
        }


        /// <summary>
        /// Переопределение ToString().
        /// </summary>
        /// <returns> string. </returns>
        public override string ToString()
        {
            return string.Format("{0} + {1}i", RealPart, ImaginaryPart);
        }
    }
}
