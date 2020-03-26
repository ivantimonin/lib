using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds.test.impl
{
    public class Plugins : PluginFactory, IPlugin, IPluginFactory
    {
        /// <summary>
        /// Описание данного класса
        /// </summary>
        public string Description { get; private set; } = "класс " +
            "для выполнения арифметических операций и хранение данных" +
            "о изучаемых звездах на космическом корабле."+
            "Обратить внимание, что по умолчанию количество изучаемых звезд 1000"+
            "Если количество изучаемых звезд меньше или больше необходимо это указать при " +
            "создании объекта";

        /// <summary>
        /// версия класса
        /// </summary>     
        public string Version { get; private set; } = "1.0";

        /// <summary>
        /// Форма звезды
        /// </summary>
        public Image Image { get; set; }

        public Plugins() : this(100) { }

        /// <summary>
        /// Создание объекта
        /// </summary>
        /// <param name="PluginsCount">количество изучаемых звезд</param>

        public Plugins(int PluginsCount) : base(PluginsCount) { }
                                  
        /// <summary>
        /// Метод вернет результат арифметической операции
        /// </summary>
        /// <param name="input1">Первый член арифметичекой операции</param>
        /// <param name="input2">Второй член арифметичекой операции</param>        
        public int Run(int input1, int input2)
        {
            Console.WriteLine($"Первый член арифметической операции:{input1}");
            Console.WriteLine($"Второй член арифметической операции:{input2}");
            Console.WriteLine("Введите один из следующих знаков (* / + - ^):");
            if (!(char.TryParse(Console.ReadLine(), out char sign)))//если преобразование неуспешно           
            {
                throw new Exception("Ввести можно только один символ");
            }
            if (sign == '*')
            {
                return (input1 * input2);
            }
            else if (sign == '/')
            {
                return Division(input1, input2);
            }
            else if (sign == '+')
            {
                return (input1 + input2);
            }
            else if (sign == '-')
            {
                return (input1 - input2);
            }
            else if (sign == '^')
            {
                return Pow(input1, input2);                 
            }
            else throw new Exception("Введен недопутимый символ выражения");         
        }

        private int Pow(int x, int y)
        {
            int Rezult = 1;            
            if (y < 0)
            {
                if (x != 1 || x != -1)
                {
                    Console.WriteLine("Дробная часть будет отброшена");
                }
                for (int i = 0; i > y; i--)
                {
                    Rezult *= 1/x;
                }
            }
            if (y > 0)
            {
                for (int i = 0; i < y; i++)
                {
                    Rezult *= x;                   
                }                
            }
            return Rezult;
        }

        private int Division(int x, int y)
        {
            if (y == 0)
            {
                throw new Exception("Делить на ноль нельзя");
            }
            if (x % y != 0)
            {
                Console.WriteLine("Дробная часть числа отброшена!");
            }            
            return (x / y);
        }              
        
        IPlugin IPluginFactory.GetPlugin(string pluginName)
        {
            IPlugin new_Plugin = new Plugins();
            return new_Plugin;
        }
    }
}
