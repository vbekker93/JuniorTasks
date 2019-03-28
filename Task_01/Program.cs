using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace TaskOne
{

    /// задача №1
    /// необходимо просуммировать все найденные числа
    /// исправить потенциальную ошибку
    ///
    /// задачу необходимо реализовать, дописав код, чтобы data.GetDigits() стал работоспособным

    class Program
    {

        public static string RandomString(int length)
        {
            if(length < 1)
            {
                Console.WriteLine("Значение длинны генерируемой строки должно быть больше нуля!");
                return string.Empty;
            }

            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        static void Main(string[] args)
        {
            string data = RandomString(5);

            if(string.IsNullOrEmpty(data))
            {
                Console.WriteLine("Входная строка пустая!");
                return;
            }

            byte summary = 0;

            foreach (byte digit in data.GetDigits())
            {
                //Возможно переполнение и сдвиг значения переменной byte. В данном коде используется константа 5, что в сумме не будет более 255.
                //TODO: использовать int или long, если будет использование больших входных строк.
                summary += digit;
            }

            Console.WriteLine($"{data} => {summary}");
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
