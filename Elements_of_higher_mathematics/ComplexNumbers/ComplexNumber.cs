using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;

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
        private string _imaginaryPart;
        public string ImaginaryPart
        {
            get 
            {
                if (_imaginaryPart == "i")
                {
                    _imaginaryPart = "1i";
                }
                if (_imaginaryPart == "-i")
                {
                    _imaginaryPart = "-1i";
                }

                return _imaginaryPart;
            }
            private set
            {
                _imaginaryPart = value ;
            }
        }

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

            //Добавляет i за скобку к мнимым элементам.
            ImaginaryPart += "i";
        }

        /// <summary>
        /// Метод возводящий комплексное число в степень.
        /// </summary>
        /// <param name="degree"> Степень. </param>
        /// <param name="isOutputToConsole"> Выводить ли информацию в консоль. </param>
        /// <returns> Комплексное число. </returns>
        public ComplexNumber Pow(int degree, bool isOutputToConsole = false)
        {
            // Создание переменной результат.
            var result = new ComplexNumber(RealPart, ImaginaryPart);

            //Цикл возводящий в степень degree.
            for (int i = 1; i < degree; i++)
            {
                result = Multiplication(result, result, isOutputToConsole);
            }
            
            //TODO: Вывод в консоль.

            //Возвращает результат.
            return result;
        }

        /// <summary>
        /// Метод сложения.
        /// </summary>
        /// <param name="a"> Первое число. </param>
        /// <param name="b"> Второе число. </param>
        /// <param name="isOutputToConsole"> Выводить ли информацию в консоль. </param>
        /// <returns> Сумма двух комплексных чисел. </returns>
        public static ComplexNumber Addition(ComplexNumber a, ComplexNumber b, bool isOutputToConsole = false)
        {
            //Убирает i из мнимых чисел.
            a.ImaginaryPart = String.Join("", a.ImaginaryPart.Split("i"));
            b.ImaginaryPart = String.Join("", b.ImaginaryPart.Split("i"));

            // Конвертирует числа в int и складывает.
            var realPart = Convert.ToInt32(a.RealPart) + Convert.ToInt32(b.RealPart);
            var imaginaryPart = Convert.ToInt32(a.ImaginaryPart) + Convert.ToInt32(b.ImaginaryPart);

            // Результат сложения.
            var result = new ComplexNumber(realPart, imaginaryPart + "i");

            //-------Вывод в консоль----------
            if (isOutputToConsole == true)
            {
                Console.WriteLine();
                Console.WriteLine("Сложение комплексных чисел");
                Console.WriteLine();
                Console.Write($"({a.RealPart} + {b.RealPart}) + ({a.ImaginaryPart} + {b.ImaginaryPart})i = {result}");
                Console.WriteLine();
            }
            //-------Вывод в консоль----------

            // Возвращает результат сложения.
            return result;
        }

        /// <summary>
        /// Метод вычитание.
        /// </summary>
        /// <param name="a"> Первое число. </param>
        /// <param name="b"> Второе число. </param>
        /// <param name="isOutputToConsole"> Выводить ли информацию в консоль. </param>
        /// <returns> Разность двух комплексных чисел. </returns>
        public static ComplexNumber Subtraction(ComplexNumber a, ComplexNumber b, bool isOutputToConsole = false)
        {
            //Убирает i из мнимых чисел.
            a.ImaginaryPart = String.Join("", a.ImaginaryPart.Split("i"));
            b.ImaginaryPart = String.Join("", b.ImaginaryPart.Split("i"));

            // Конвертирует числа в int и вычитает.
            var realPart = Convert.ToInt32(a.RealPart) - Convert.ToInt32(b.RealPart);
            var imaginaryPart = Convert.ToInt32(a.ImaginaryPart) - Convert.ToInt32(b.ImaginaryPart);

            // Результат вычитания.
            var result = new ComplexNumber(realPart, imaginaryPart + "i");

            //-------Вывод в консоль----------
            if (isOutputToConsole == true)
            {
                Console.WriteLine();
                Console.WriteLine("Вычитание комплексных чисел");
                Console.WriteLine();
                Console.Write($"({a.RealPart} - {b.RealPart}) + ({a.ImaginaryPart} - {b.ImaginaryPart})i = {result}");
                Console.WriteLine();
            }
            //-------Вывод в консоль----------

            // Возвращает результат вычитания.
            return result;
        }

        /// <summary>
        /// Метод умножить.
        /// </summary>
        /// <param name="a"> Первое число. </param>
        /// <param name="b"> Второе число. </param>
        /// <param name="isOutputToConsole"> Выводить ли информацию в консоль. </param>
        /// <returns> Произведение двух комплексных чисел. </returns>
        public static ComplexNumber Multiplication(ComplexNumber a, ComplexNumber b, bool isOutputToConsole = false)
        {
            //Убирает i из мнимых чисел.
            a.ImaginaryPart = String.Join("", a.ImaginaryPart.Split("i"));
            b.ImaginaryPart = String.Join("", b.ImaginaryPart.Split("i"));

            // Конвертирует числа в int.
            var a1 = Convert.ToInt32(a.RealPart);
            var a2 = Convert.ToInt32(b.RealPart);
            var b1 = Convert.ToInt32(a.ImaginaryPart);
            var b2 = Convert.ToInt32(b.ImaginaryPart);

            // Перемножает комплексные числа по формуле z = (a1a2 - b1b2) + (a1b2 + a2b1)i.
            var realPart = a1 * a2 - b1 * b2;
            var imaginaryPart = a1 * b2 + a2 * b1;

            // Результат перемножения.
            var result = new ComplexNumber(realPart, imaginaryPart + "i");

            //-------Вывод в консоль----------
            if (isOutputToConsole == true)
            {
                Console.WriteLine();
                Console.WriteLine("Перемножение комплексных чисел");
                Console.WriteLine();
                Console.Write($"({a1 * a2} - {b1 * b2}i) + ({a1 * b2}i + {a2 * b1}i) = {result}");
                Console.WriteLine();
            }
            //-------Вывод в консоль----------

            // Возвращает результат перемножения.
            return result;
        }

        /// <summary>
        /// Метод деления.
        /// </summary>
        /// <param name="a"> Первое число. </param>
        /// <param name="b"> Второе число. </param>
        /// <param name="isOutputToConsole"> Выводить ли информацию в консоль. </param>
        /// <returns> Частное двух комплексных чисел. </returns>
        public static ComplexNumber Division(ComplexNumber a, ComplexNumber b, bool isOutputToConsole = false)
        {
            //Убирает i из мнимых чисел.
            a.ImaginaryPart = String.Join("", a.ImaginaryPart.Split("i"));
            b.ImaginaryPart = String.Join("", b.ImaginaryPart.Split("i"));

            // Конвертирует числа в int.
            var a1 = Convert.ToInt32(a.RealPart);
            var a2 = Convert.ToInt32(b.RealPart);
            var b1 = Convert.ToInt32(a.ImaginaryPart);
            var b2 = Convert.ToInt32(b.ImaginaryPart);

            // Делит комплексные числа по формуле z = ((a1 + b1i)*(a2 - b2i)) / (a2^2 + b2^2).
            var dividend = new ComplexNumber(a1, b1) * new ComplexNumber(a2, -1 * b2);
            var divider = new ComplexNumber(a2, b2) * new ComplexNumber(a2, -1 * b2);

            // Результат деления.
            var result = CutBackMethod(dividend, divider);

            //-------Вывод в консоль----------
            if (isOutputToConsole == true)
            {
                Console.WriteLine();
                Console.WriteLine("Деление комплексных чисел");
                Console.WriteLine();
                Console.Write($"({a1 * a2} + {a1 * b2}i + {a2 * b1}i + {b1 * b2}i^2) / ({a2 * a2} + {b2 * b2}) = {result}");
                Console.WriteLine();
            }
            //-------Вывод в консоль----------

            // Возвращает результат деления.
            return result;
        }

        /// <summary>
        /// Метод находящий степень мнимой еденицы.
        /// </summary>
        /// <param name="degree"> Степень. </param>
        /// <param name="isOutputToConsole"> Выводить ли информацию в консоль. </param>
        /// <returns> Число возведенное в степень. </returns>
        public string PowImaginaryPart(int degree, bool isOutputToConsole = false)
        {
            // Результат.
            var result = "";

            // Проверка является ли степень четным.
            if (degree % 2 == 0)
            {
                // Если да то в ответе получается число.
                result = Math.Pow(-1, degree / 2).ToString();
            }
            else
            {
                // Если нет то в ответе получается i.
                result = $"{Math.Pow(-1, (degree - 1) / 2)}i";
            }

            //-------Вывод в консоль----------
            if (isOutputToConsole == true)
            {
                Console.WriteLine();
                Console.WriteLine("Найти степень мнимой еденицы");
                Console.WriteLine();

                if (degree % 2 == 0)
                {
                    Console.Write($"i^{degree} = (i^2)^{degree / 2} = (-1)^{degree / 2} = {result}");
                }
                else
                {
                    Console.Write($"i^{degree} = (i^2)^{(degree - 1) / 2} * i = (-1)^{(degree - 1) / 2} * i = {result}");
                }

                Console.WriteLine();
            }
            //-------Вывод в консоль----------

            // Возвращает ответ.
            return result;
        }

        /// <summary>
        /// Метод нахдящий корень отрицательного числа.
        /// </summary>
        /// <param name="number"> Число. </param>
        /// <param name="isOutputToConsole"> Выводить ли информацию в консоль. </param>
        /// <returns> Результат вычислений. </returns>
        public string Sqrt(double number, bool isOutputToConsole = false)
        {
            //-------Вывод в консоль----------
            if (isOutputToConsole == true)
            {
                Console.WriteLine();
                Console.WriteLine("Найти корень отрицательного числа");
                Console.WriteLine();

                if (number < 0)
                {
                    Console.Write($"Sqrt({number}) = Sqrt({number * -1} * (-1)) = Sqrt({number * -1} * (i^2)) = {Sqrt(number)}");
                }
                else
                {
                    Console.Write($"Sqrt({number}) = {Sqrt(number)}");
                }

                Console.WriteLine();
            }
            //-------Вывод в консоль----------

            // Результат.
            var result = "";

            // Если число отрицательное.
            if (number < 0)
            {
                // Убирает -.
                number *= -1;

                // Находит корень действительной части и добавляет i.
                result = Math.Sqrt(number).ToString() + "i";
            }
            else
            {
                // Находит корень действительной части.
                result = Math.Sqrt(number).ToString();
            }

            // Возвращает результат.
            return result;
        }

        /// <summary>
        /// Метод находящий модуль комплексного числа.
        /// </summary>
        /// <param name="isOutputToConsole"> Выводить ли информацию в консоль. </param>
        /// <returns> Модуль. </returns>
        public string FindModule(bool isOutputToConsole = false)
        {
            // Действительная часть.
            var realPart = RealPart;

            // Мнимая часть.
            var imaginaryPart = ImaginaryPart;

            // Убирает i из мнимой части.
            imaginaryPart = String.Join("", imaginaryPart.Split("i"));

            // Действительная часть.
            var a = Convert.ToDouble(realPart);

            // Мнимая часть.
            var b = Convert.ToDouble(imaginaryPart);

            // Результат. 
            var result = "";

            // Расчитывает модуль по формуле Sqrt(Pow(a, 2) + Pow(b, 2)).
            var module = Math.Sqrt(Math.Round(Math.Pow(a, 2) + Math.Pow(b, 2)));

            // Является ли число целым.
            if (Convert.ToInt32(module) == Convert.ToDouble(module))
            {
                // Модуль в виде целого числа.
                result = module.ToString();
            }
            else
            {
                // Модуль в виде корня.
                result = $"Sqrt({Math.Pow(a, 2) + Math.Pow(b, 2)})";
            }

            //-------Вывод в консоль----------
            if (isOutputToConsole == true)
            {
                Console.WriteLine();
                Console.WriteLine("Найти модуль комплексного числа");
                Console.WriteLine();

                Console.WriteLine($"|z| = Sqrt(Pow({a}, 2) + Pow({b}, 2) = Sqrt({Math.Round(Math.Pow(a, 2), 2)} + {Math.Round(Math.Pow(b, 2), 2)}) = {result}");

                Console.WriteLine();
            }
            //-------Вывод в консоль----------

            // Возвращает модуль.
            return result;
        }

        /// <summary>
        /// Метод находящий агрумент комплексного числа.
        /// </summary>
        /// <param name="isOutputToConsole"> Выводить ли информацию в консоль. </param>
        /// <returns> Агрумент комплексного числа. </returns>
        public string FindArg(bool isOutputToConsole = false)
        {
            // Действительная часть.
            var realPart = Convert.ToDouble(RealPart);

            // Мнимая часть.
            var imaginaryPart = Convert.ToDouble(String.Join("", ImaginaryPart.Split("i")));

            // Аргумент.
            var arg = "";

            // Радианы.
            var radians = 0.0;

            #region Выбор формулы.

            if (realPart > 0 && imaginaryPart >= 0)
            {
                radians = Math.Atan(imaginaryPart / realPart);
            }
            else if (realPart < 0 && imaginaryPart >= 0)
            {
                radians = (Math.PI - Math.Atan(Math.Abs(imaginaryPart / realPart)));
            }
            else if (realPart < 0 && imaginaryPart < 0)
            {
                radians = (Math.PI + Math.Atan(Math.Abs(imaginaryPart / realPart)));
            }
            else if (realPart > 0 && imaginaryPart < 0)
            {
                radians = (2 * Math.PI - Math.Atan(Math.Abs(imaginaryPart / realPart)));
            }
            else if (realPart == 0 && imaginaryPart > 0)
            {
                radians = (Math.PI / 2);
            }
            else if (realPart == 0 && imaginaryPart < 0)
            {
                radians = (3 * Math.PI / 2);
            }

            #endregion

            // Перевод из числа с плавающей точкой в дробное.
            arg = ConversionFromRadiansToFractions(radians);

            //-------Вывод в консоль----------
            if (isOutputToConsole == true)
            {
                Console.WriteLine();
                Console.WriteLine("Найти агрумент комплексного числа");
                Console.WriteLine();

                #region Выбор формулы.

                if (realPart > 0 && imaginaryPart >= 0)
                {
                    Console.Write($"Atan({imaginaryPart} / {realPart})");
                }
                else if (realPart < 0 && imaginaryPart >= 0)
                {
                    Console.Write($"PI - Atan(Abs({imaginaryPart} / {realPart}))");
                }
                else if (realPart < 0 && imaginaryPart < 0)
                {
                    Console.Write($"PI + Atan(Abs({imaginaryPart} / {realPart}))");
                }
                else if (realPart > 0 && imaginaryPart < 0)
                {
                    Console.Write($"2 * PI - Atan(Abs({imaginaryPart} / {realPart}))");
                }
                else if (realPart == 0 && imaginaryPart > 0)
                {
                    Console.Write("PI / 2)");
                }
                else if (realPart == 0 && imaginaryPart < 0)
                {
                    Console.Write("3 * PI / 2)");
                }

                #endregion

                Console.Write($" = {arg}");

                Console.WriteLine();
            }
            //-------Вывод в консоль----------

            // Возвращает аргумент.
            return arg;
        }

        public void GettingSystem(ComplexNumber z1, ComplexNumber z2)
        {
            // Приведение Комплексных чисел к стандартному виду.
            z1.MethodLeadingToStandardView();
            z2.MethodLeadingToStandardView();


        }

        /// <summary>
        /// Метод конвертирующий число с плавающей точкой в дробное.
        /// </summary>
        /// <param name="radians"> Радиана. </param>
        /// <returns> Радиана в виде дроби. </returns>
        private string ConversionFromRadiansToFractions(double radians)
        {
            // Градусы.
            var degrees = 0.0;

            // НОД.
            var gcf = 0.0;

            // Результат.
            var result = "";

            // Перевод из радиан в градусы.
            degrees = Math.Round((radians * 180) / Math.PI, 2);

            // нахождение НОД.
            gcf = GCF(degrees, 180);

            result = $"({degrees / gcf} PI) / {180 / gcf}";

            // Возвращает результат.
            return result;
        }

        /// <summary>
        /// Сокращает дробь если возможно.
        /// </summary>
        /// <param name="dividend"> Делимое. </param>
        /// <param name="divider"> Делитель. </param>
        private static ComplexNumber CutBackMethod(ComplexNumber dividend, ComplexNumber divider)
        {
            //Убирает i из мнимых чисел.
            dividend.ImaginaryPart = String.Join("", dividend.ImaginaryPart.Split("i"));

            //Получает НОД действительных чисел.
            var gcfRealPart = GCF(Convert.ToDouble(dividend.RealPart), Convert.ToDouble(divider.RealPart));

            //Получает НОД мнимых чисел.
            var gcfImaginaryPart = GCF(Convert.ToDouble(dividend.ImaginaryPart), Convert.ToDouble(divider.RealPart));

            //Сокращает дробь.
            dividend.RealPart = (Convert.ToDouble(dividend.RealPart) / gcfRealPart).ToString();
            dividend.ImaginaryPart = (Convert.ToDouble(dividend.ImaginaryPart) / gcfImaginaryPart).ToString();
            divider.RealPart = (Convert.ToDouble(divider.RealPart) / gcfRealPart).ToString();

            //Задает действительную часть.
            var realPart = $"{dividend.RealPart} / {divider.RealPart} + {divider.ImaginaryPart}";

            //Задает мнимую часть.
            var imaginaryPart = $"{dividend.ImaginaryPart} / {divider.RealPart} + {divider.ImaginaryPart}";

            //Если мнимое число равно 0.
            if (divider.ImaginaryPart == "0i")
            {
                realPart = $"{dividend.RealPart} / {divider.RealPart}";
                imaginaryPart = $"{dividend.ImaginaryPart + "i"} / {divider.RealPart}";

                //Если делитель равен 1.
                if (divider.RealPart == "1")
                {
                    realPart = $"{dividend.RealPart}";
                    imaginaryPart = $"{dividend.ImaginaryPart + "i"}";
                }
            }
            
            //Возвращает результат.
            return new ComplexNumber(realPart, imaginaryPart);
        }

        /// <summary>
        /// Метод нахождения НОД.
        /// </summary>
        /// <param name="a"> Первое число. </param>
        /// <param name="b"> Второе число. </param>
        /// <returns> НОД. </returns>
        private static double GCF(double a, double b)
        {
            while (b != 0)
            {
                double temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        /// <summary>
        /// Переопределение оператора сложения.
        /// </summary>
        /// <param name="a"> Первое число. </param>
        /// <param name="b"> Второе число. </param>
        /// <returns> Сумма двух комплексных чисел. </returns>
        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
        {
            return Addition(a, b);
        }

        /// <summary>
        /// Переопределение оператора вычитание.
        /// </summary>
        /// <param name="a"> Первое число. </param>
        /// <param name="b"> Второе число. </param>
        /// <returns> Разность двух комплексных чисел. </returns>
        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
        {
            return Subtraction(a, b);
        }

        /// <summary>
        /// Переопределение оператора умножить.
        /// </summary>
        /// <param name="a"> Первое число. </param>
        /// <param name="b"> Второе число. </param>
        /// <returns> Произведение двух комплексных чисел. </returns>
        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        {
            return Multiplication(a, b);
        }

        /// <summary>
        /// Переопределение оператора разделить.
        /// </summary>
        /// <param name="a"> Первое число. </param>
        /// <param name="b"> Второе число. </param>
        /// <returns> Частное двух комплексных чисел. </returns>
        public static ComplexNumber operator /(ComplexNumber a, ComplexNumber b)
        {
            return Division(a, b);
        }

        /// <summary>
        /// Переопределение ToString().
        /// </summary>
        /// <returns> string. </returns>
        public override string ToString()
        {
            return string.Format("{0} + {1}", RealPart, ImaginaryPart);
        }
    }
}
