//Домашнее задание #7.
//https://edu.mmcs.sfedu.ru/mod/assign/view.php?id=19150

/*
Преобразовать арифметическое выражение в инфиксной записи в выражение в постфиксной. 
Говорят, что выражение записано в инфиксной форме, если знак операции 
(сложения, умножения, вычитания либо деления) стоит между своими аргументами, например, 5 + 7. 
Каждая операция имеет приоритет выполнения (сначала выполняются умножение и деление, 
затем сложение и вычитание). Для изменения приоритета выполнения операций используются круглые скобки. 

Вычислять значение выражения, записанного в инфиксной форме, неудобно.
Проще сначала перевести его в постфиксную, или обратную польскую запись, 
в которой знак операции записывается после своих операндов, например, 5 7 +. 

Для перевода выражения из инфиксной формы в постфиксную с учетом приоритетов операций и скобок 
существует простой алгоритм. 
Алгоритм работает со стеком, в котором хранятся знаки операций. 
Сначала стек пуст. 
На вход алгоритму подается последовательность лексем (числа, скобки или знаки операций),
представляющая некоторое арифметическое выражение, записанное в инфиксной форме. 
Результатом работы алгоритма является эквивалентное выражение в постфиксной форме. 
Вводятся приоритеты операций: открывающая скобка имеет приоритет 0, 
знаки + и – — приоритет 1 и знаки * и / — приоритет 2. 

Если не достигнут конец входной последовательности, прочитать очередную лексему. 
Если прочитан операнд (число), записать его в выходную последовательность. 
Если прочитана открывающая скобка, положить ее в стек. 
Если прочитана закрывающая скобка, вытолкнуть из стека в выходную последовательность всё до открывающей скобки. Сами скобки уничтожаются. 
Если прочитан знак операции, вытолкнуть из стека в выходную последовательность все операции с большим либо равным приоритетом, а прочитанную операцию положить в стек. 
Если достигнут конец входной последовательности, вытолкнуть все из стека в выходную последовательность и завершить работу.
Выходную последовательность удобно представлять списком, из которого в конце формируется выходная строка с исходным выражением в постфиксной записи. 

Вычислить значение выражения, заданного в инфиксной форме.
 */

using System.Text;

namespace HW_07
{
    static public class RPN
    {
        /// <summary>
        /// Преобразование выражения из инфиксной формы в постфиксную 
        /// </summary>
        /// <param name="expression">Выражение в инфиксной форме</param>
        /// <returns>Выражение в обратной польской записи (постфиксная форма)</returns>
        static public string InfixToRPN(string expression)
        {
            StringBuilder result = new();
            Stack<char> operations = new();

            //Перечень известных операций
            //Числа с унарным минусом (отрицательные) в этом решении будут заменяться
            //на ноль минус модуль числа
            Dictionary<char, int> operationsPriority = new()
            {
                {'(', 0 },
                {'+', 1 },
                {'-', 1 },
                {'*', 2 },
                {'/', 2 },
                {'^', 3 }
            };

            string[] words = expression
                .Trim()
                .Split(' ')
                .ToArray();

            foreach (string word in words)
            {
                //Операнды
                if (float.TryParse(word, out float number))
                    if (number >= 0)
                        result.Append(word + " ");
                    else
                    {
                        result.Append("0 " + float.Abs(number) + " ");
                        operations.Push('-');
                    }

                //Операции
                else
                {
                    if (!char.TryParse(word, out char op))
                        throw new Exception($"Операция '{word}' неизвестна");

                    switch (op)
                    {
                        case '(':
                            operations.Push(op);
                            break;

                        case ')':
                            while (operations.TryPeek(out char lastOp))
                            {
                                if (lastOp != '(')
                                    result.Append(operations.Pop() + " ");
                                else
                                {
                                    operations.Pop();
                                    break;
                                }
                            }
                            break;

                        default:
                            if (!operationsPriority.ContainsKey(op))
                                throw new Exception($"Операция '{op}' неизвестна");
                            result.Append(GetOpereationsFromStack(op));
                            break;
                    }
                }
            }

            //Операнды закончились, извлекаем все оставшиеся операции из стэка
            result.Append(GetOpereationsFromStack('('));

            //Извлекает из стека операции с равным или большим приоритетом,
            //отдаёт их в виде готовой строки.
            //Операцию со входа кладёт в стэк.
            string GetOpereationsFromStack(char operation)
            {
                StringBuilder result = new();

                while(operations.TryPeek(out char lastOp))
                {
                    if (Priority(operation) <= Priority(lastOp))
                        result.Append(operations.Pop() + " ");
                    else
                        break;     
                }

                int Priority(char op)
                {
                    if (!operationsPriority.TryGetValue(op, out int opPriority))
                        throw new Exception($"Операция '{op}' неизвестна");
                    return opPriority;
                }

                operations.Push(operation);
                return result.ToString();
            }

            return result.ToString().TrimEnd();
        }

        /// <summary>
        /// Вычисляет значение выражения, заданного в инфиксной форме
        /// </summary>
        static public double CalculateInfix(string expression) =>
            CalculateRPN(InfixToRPN(expression));

        /// <summary>
        /// Вычисляет значение выражения, заданного в постфиксной форме
        /// </summary>
        static public double CalculateRPN(string expression)
        {
            Stack<double> operands = new();

            string[] words = expression
                .Trim()
                .Split(' ')
                .ToArray();

            double firstOpd;
            double secondOpd;
            double resultOpd;
            foreach(string word in words)
            {
                if (double.TryParse(word, out double operand))
                    operands.Push(operand);
                //Извлекаем из стека два последних операнда, выполняем над ними операцию,
                //результат кладём обратно в стек
                else
                {
                    secondOpd = operands.Pop();
                    firstOpd = operands.Pop();

                    if (!char.TryParse(word, out char operation))
                        throw new Exception($"Операция '{word}' неизвестна");

                    resultOpd = operation switch
                    {
                        '+' => firstOpd + secondOpd,
                        '-' => firstOpd - secondOpd,
                        '*' => firstOpd * secondOpd,
                        '/' => firstOpd / secondOpd,
                        '^' => Math.Pow(firstOpd, secondOpd),
                        _ => throw new Exception($"Операция '{operation}' неизвестна")
                    };

                    operands.Push(resultOpd);
                }
            }

            return operands.Pop();
        }
    }
}
