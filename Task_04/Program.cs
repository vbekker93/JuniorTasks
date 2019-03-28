using System;
using System.Collections.Generic;
using System.Threading;

namespace Task_04
{

    /// Задача - дорабатываем будильник
    /// необходимо написать метод, который позволит считать, сколько времени осталось до того, как зазвонит будильник


    class Program
    {
        /// <summary>
        /// Переменная даты, для которой производится операция
        /// </summary>
        static DateTime CurrentDateTime;

        /// <summary>
        /// Константа частоты срабатывания будильника (в милисекундах)
        /// </summary>
        const int alarmMilisecondsRate = 1000;

        static void Main(string[] args)
        {
            CurrentDateTime = DateTime.Now;

            var wakeUp = CurrentDateTime.AddSeconds(10);
            
            foreach (DateTime value in AlarmClockTimer(wakeUp))
            {
                Console.WriteLine((wakeUp - value).ToString(@"dd\.hh\:mm\:ss"));
                Thread.Sleep(alarmMilisecondsRate);
            }
        }

        /// <summary>
        /// Метод получения списка времени
        /// </summary>
        /// <param name="wakeUp">Дата срабатывания будильника</param>
        /// <returns>Коллекция времени будильника</returns>
        private static List<DateTime> AlarmClockTimer(DateTime wakeUp)
        {
            TimeSpan _ts = wakeUp - CurrentDateTime;
            int dateCount = (int)_ts.TotalMilliseconds / alarmMilisecondsRate;

            if (dateCount < 1)
                return new List<DateTime>();

            List<DateTime> resultDates = new List<DateTime>(dateCount);

            for(int i = 0; i<dateCount; i++)
                resultDates.Add(CurrentDateTime.AddMilliseconds(i*alarmMilisecondsRate));

            return resultDates;
        }
    }
}
