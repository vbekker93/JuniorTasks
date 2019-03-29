using System;

namespace TaskTwo
{
    /// Есть базовый класс с реалиазцией двух интерфейсов, имеющих одинаковый метод
    /// строка var @base = new Base(); - создаёт объект типа Base
    /// вызов @base.WriteExecutor()    - выводит на экран строку I base Executor!
    ///
    /// Дополните код так, чтобы не создавая новый объект на экран было выведено
    ///
    /// I base Executor!
    /// I one Executor!
    /// I two Executor!

    internal interface IOneExecutor
    {
        void WriteExecutor();
    }

    internal interface ITwoExecutor
    {
        void WriteExecutor();
    }

    internal class Base : IOneExecutor, ITwoExecutor
    {
        public void WriteExecutor()
        {
            Console.WriteLine("I base Executor!");
        }

        void IOneExecutor.WriteExecutor()
        {
            Console.WriteLine("I one Executor!");
        }

        void ITwoExecutor.WriteExecutor()
        {
            Console.WriteLine("I two Executor!");
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var @base = new Base();
                @base.WriteExecutor();
                (@base as IOneExecutor).WriteExecutor();
                (@base as ITwoExecutor).WriteExecutor();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }
    }
}