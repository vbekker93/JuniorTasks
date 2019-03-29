using System;
using System.Collections.Generic;

namespace TaskThree
{
    /// Задача - перепишите данный код так, чтобы он работал через коллекции C#, вместо конструкции switch

    public enum ActionType
    {
        Create,

        Read,

        Update,

        Delete
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Dictionary<ActionType, Action<ActionType>> methodsDic;
                InitDictionary(out methodsDic);

                var type = ActionType.Read;

                if (methodsDic.ContainsKey(type))
                    methodsDic[type](type);
                else
                    Console.WriteLine("Метод " + type.ToString() + " не добавлен в коллекцию!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        /// <summary>
        /// Инициализация коллекции методов
        /// </summary>
        /// <param name="inputDic">Словарь методов</param>
        private static void InitDictionary(out Dictionary<ActionType, Action<ActionType>> inputDic)
        {
            inputDic = new Dictionary<ActionType, Action<ActionType>>();

            inputDic.Add(ActionType.Create,
               new Action<ActionType>(CreateMethod)
            );

            inputDic.Add(ActionType.Read,
               new Action<ActionType>(ReadMethod)
            );

            inputDic.Add(ActionType.Update,
               new Action<ActionType>(UpdateMethod)
            );

            inputDic.Add(ActionType.Delete,
               new Action<ActionType>(DeleteMethod)
            );
        }

        private static void CreateMethod(ActionType type)
        {
            Console.WriteLine(type.ToString());
        }

        private static void ReadMethod(ActionType type)
        {
            Console.WriteLine(type.ToString());
        }

        private static void UpdateMethod(ActionType type)
        {
            Console.WriteLine(type.ToString());
        }

        private static void DeleteMethod(ActionType type)
        {
            Console.WriteLine(type.ToString());
        }
    }
}