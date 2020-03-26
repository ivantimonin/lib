using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds.test.impl
{
    abstract public class PluginFactory
    {
        /// <summary>
        /// Количество всех изучаемых звезд в галактике
        /// </summary>
        public int PluginsCount { get; private set; }

        /// <summary>
        ///Название всех звезд
        /// </summary>
        public string[] GetPluginNames { get; private set; }

        protected int count = 0;
        /// <summary>
        /// назвние звезды
        /// </summary>
        public string PluginName { get; set; }

        public PluginFactory(int PluginsCount)
        {
            this.PluginsCount = PluginsCount;
            GetPluginNames = new string[PluginsCount];
        }
        /// <summary>
        /// Метод призводит учет изучаемых звезд
        /// </summary>
        /// <param name="NameStar">Название звезды</param>        
        public void WriteNewStar(string NameStar)
        {
            if (PluginsCount > count)
            {
                GetPluginNames[count] = NameStar + "; " ;
                count++;
            }
            else
            {
                Console.WriteLine("Изначально планировалось изучить меньше звезд");
            }
        }
        /// <summary>
        /// Метод призводит чтение всех изучаемых звезд
        /// </summary>
        public void Read_all_Star()
        {
            foreach (string Star in GetPluginNames)
            {
                Console.WriteLine(Star);
            }
        }
    }
}
