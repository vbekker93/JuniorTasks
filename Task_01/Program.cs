using System;
using System.Linq;

namespace TaskOne
{
    /// задача №1
    /// необходимо просуммировать все найденные числа
    /// исправить потенциальную ошибку
    ///
    /// задачу необходимо реализовать, дописав код, чтобы data.GetDigits() стал работоспособным

    internal class Program
    {
        public static string RandomString(int length)
        {
            if (length < 1)
            {
                Console.WriteLine("Значение длинны генерируемой строки должно быть больше нуля!");
                return string.Empty;
            }

            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static void Main(string[] args)
        {
            try
            {
                string data = RandomString(5);

                if (string.IsNullOrEmpty(data))
                {
                    Console.WriteLine("Входная строка пуста!");
                    return;
                }

                //Возможно переполнение и сдвиг значения переменной byte, при сумме чисел, более 255.
                //TODO: использовать int или long, при использовании больших входных строк.
                byte summary = 0;

                foreach (byte digit in data.GetDigits())
                {
                    summary += digit;
                }

                Console.WriteLine($"{data} => {summary}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }
    }

    /// <summary>
    /// Класс расширения методов String
    /// </summary>
    public static class StringExtension
    {
        public static byte[] GetDigits(this string inputString)
        {
            string digitString = new string(inputString.Where(char.IsDigit).ToArray());
            byte[] result = new byte[digitString.Length];
            int i = 0;

            foreach (char digit in digitString)
            {
                result[i] = (byte)char.GetNumericValue(digit);
                i++;
            }

            return result;
        }
    }
}