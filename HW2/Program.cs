namespace HW2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            // N1
            double[] A = new double[5];
            double[,] B = new double[3, 4];

            for (int i = 0; i < 5; i++)
            {
                Console.Write("A[" + i + "] = ");
                A[i] = double.Parse(Console.ReadLine());
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    B[i, j] = Math.Round(rnd.NextDouble() * 9 + 1, 1);
                }
            }

            Console.WriteLine("Массив A:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(A[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Массив B:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(B[i, j] + "\t");
                }
                Console.WriteLine();
            }

            double max1 = A[0], min1 = A[0], sum1 = 0, product1 = 1;
            double evenSum = 0, oddColumnsSum = 0;

            for (int i = 0; i < 5; i++)
            {
                if (A[i] > max1) max1 = A[i];
                if (A[i] < min1) min1 = A[i];
                sum1 += A[i];
                product1 *= A[i];
                if (A[i] % 2 == 0) evenSum += A[i];
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (B[i, j] > max1) max1 = B[i, j];
                    if (B[i, j] < min1) min1 = B[i, j];
                    sum1 += B[i, j];
                    product1 *= B[i, j];
                    if (j % 2 == 0) oddColumnsSum += B[i, j];
                }
            }

            Console.WriteLine("Максимум: " + max1);
            Console.WriteLine("Минимум: " + min1);
            Console.WriteLine("Сумма: " + sum1);
            Console.WriteLine("Произведение: " + product1);
            Console.WriteLine("Сумма чётных элементов A: " + evenSum);
            Console.WriteLine("Сумма нечётных столбцов B: " + oddColumnsSum);

            // N2
            int[,] arr2 = new int[5, 5];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    arr2[i, j] = rnd.Next(-100, 101);
                    Console.Write(arr2[i, j] + "\t");
                }
                Console.WriteLine();
            }

            int minIndex = 0, maxIndex = 0;
            for (int k = 0; k < 25; k++)
            {
                if (arr2[k / 5, k % 5] < arr2[minIndex / 5, minIndex % 5]) minIndex = k;
                if (arr2[k / 5, k % 5] > arr2[maxIndex / 5, maxIndex % 5]) maxIndex = k;
            }

            int fromPos = Math.Min(minIndex, maxIndex);
            int toPos = Math.Max(minIndex, maxIndex);
            int sum2 = 0;
            for (int k = fromPos + 1; k < toPos; k++)
            {
                sum2 += arr2[k / 5, k % 5];
            }
            Console.WriteLine("Сумма между минимумом и максимумом: " + sum2);

            // N3
            Console.Write("Введите строку: ");
            string text3 = Console.ReadLine();
            Console.Write("Введите ключ сдвига: ");
            int shift3 = ((int.Parse(Console.ReadLine()) % 26) + 26) % 26;

            string encrypted = "";
            for (int i = 0; i < text3.Length; i++)
            {
                char ch = text3[i];
                if (ch >= 'a' && ch <= 'z')
                {
                    encrypted += (char)('a' + (ch - 'a' + shift3) % 26);
                }
                else if (ch >= 'A' && ch <= 'Z')
                {
                    encrypted += (char)('A' + (ch - 'A' + shift3) % 26);
                }
                else
                {
                    encrypted += ch;
                }
            }
            Console.WriteLine("Зашифровано: " + encrypted);

            string decrypted = "";
            for (int i = 0; i < encrypted.Length; i++)
            {
                char ch = encrypted[i];
                if (ch >= 'a' && ch <= 'z')
                {
                    decrypted += (char)('a' + (ch - 'a' + 26 - shift3) % 26);
                }
                else if (ch >= 'A' && ch <= 'Z')
                {
                    decrypted += (char)('A' + (ch - 'A' + 26 - shift3) % 26);
                }
                else
                {
                    decrypted += ch;
                }
            }
            Console.WriteLine("Расшифровано: " + decrypted);

            // N4
            int[,] a = new int[3, 3];
            int[,] b = new int[3, 3];
            int[,] res = new int[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    a[i, j] = rnd.Next(0, 10);
                    b[i, j] = rnd.Next(0, 10);
                }
            }

            Console.WriteLine("Матрица A:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Матрица B:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(b[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("1 - A * число, 2 - A + B, 3 - A * B");
            Console.Write("Ваш выбор: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Число: ");
                int number = int.Parse(Console.ReadLine());
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        res[i, j] = a[i, j] * number;
                    }
                }
            }
            else if (choice == 2)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        res[i, j] = a[i, j] + b[i, j];
                    }
                }
            }
            else if (choice == 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            res[i, j] += a[i, k] * b[k, j];
                        }
                    }
                }
            }

            if (choice < 1 || choice > 3)
            {
                Console.WriteLine("Ошибка! Нужно ввести 1, 2 или 3.");
            }
            else
            {
                Console.WriteLine("Результат:");
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(res[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }

            // N5
            Console.Write("Введите выражение: ");
            string expr = Console.ReadLine().Replace(" ", "");
            int result5 = 0, current = 0, sign = 1;

            for (int i = 0; i < expr.Length; i++)
            {
                if (expr[i] >= '0' && expr[i] <= '9')
                {
                    current = current * 10 + (expr[i] - '0');
                }
                else
                {
                    result5 += sign * current;
                    current = 0;
                    if (expr[i] == '+') sign = 1;
                    else sign = -1;
                }
            }
            result5 += sign * current;
            Console.WriteLine("Результат: " + result5);

            // N6
            Console.Write("Введите текст: ");
            string text6 = Console.ReadLine();
            string result6 = "";
            bool newSentence = true;

            for (int i = 0; i < text6.Length; i++)
            {
                char ch = text6[i];
                if (newSentence && char.IsLetter(ch))
                {
                    result6 += char.ToUpper(ch);
                    newSentence = false;
                }
                else
                {
                    result6 += ch;
                }
                if (ch == '.' || ch == '!' || ch == '?')
                {
                    newSentence = true;
                }
            }
            Console.WriteLine(result6);

            // N7
            Console.WriteLine("Введите текст (пустая строка - конец):");
            string text7 = "";
            string line = Console.ReadLine();
            while (line != "")
            {
                text7 += line + "\n";
                line = Console.ReadLine();
            }

            Console.Write("Недопустимое слово: ");
            string banned = Console.ReadLine().ToLower();
            string result7 = "", word = "";
            int count = 0;

            for (int i = 0; i <= text7.Length; i++)
            {
                if (i < text7.Length && char.IsLetter(text7[i]))
                {
                    word += text7[i];
                    continue;
                }

                if (word.ToLower() == banned)
                {
                    result7 += new string('*', word.Length);
                    count++;
                }
                else
                {
                    result7 += word;
                }
                word = "";

                if (i < text7.Length)
                {
                    result7 += text7[i];
                }
            }
            Console.WriteLine(result7);
            Console.WriteLine("Статистика: " + count + " замен слова " + banned);

            if (args.Length == 2)
            {
                // N8
                int shift8 = ((int.Parse(args[1]) % 26) + 26) % 26;
                string result8 = "";

                for (int i = 0; i < args[0].Length; i++)
                {
                    char ch = args[0][i];
                    if (ch >= 'a' && ch <= 'z')
                    {
                        result8 += (char)('a' + (ch - 'a' + shift8) % 26);
                    }
                    else if (ch >= 'A' && ch <= 'Z')
                    {
                        result8 += (char)('A' + (ch - 'A' + shift8) % 26);
                    }
                    else
                    {
                        result8 += ch;
                    }
                }
                Console.WriteLine(result8);
            }

            if (args.Length == 3)
            {
                // N9
                int rows9 = int.Parse(args[0]);
                int cols9 = int.Parse(args[1]);
                int mult9 = int.Parse(args[2]);
                int[,] arr9 = new int[rows9, cols9];

                for (int i = 0; i < rows9; i++)
                {
                    for (int j = 0; j < cols9; j++)
                    {
                        arr9[i, j] = rnd.Next(0, 10);
                        arr9[i, j] *= mult9;
                        Console.Write(arr9[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}