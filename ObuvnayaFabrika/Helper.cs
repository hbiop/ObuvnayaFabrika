
using ObuvnayaFabrika.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObuvnayaFabrika
{
    /// <summary>
    /// Класс для работы с контекстом базы данных
    /// </summary>
    public class Helper
    {
        private static ObuvnajaFabricaEntity obuvnayaFabrikaModel;
        /// <summary>
        /// Метод для получения контекста базы данных
        /// </summary>
        public static ObuvnajaFabricaEntity GetContext()
        {
            /*
             * 
             */
            if(obuvnayaFabrikaModel == null)
            {
                obuvnayaFabrikaModel = new ObuvnajaFabricaEntity();
            }
            return obuvnayaFabrikaModel;
        }
    }
}
