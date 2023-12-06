
using ObuvnayaFabrika.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObuvnayaFabrika
{
    public class Helper
    {
        private static ObuvnajaFabricaEntity obuvnayaFabrikaModel;

        public static ObuvnajaFabricaEntity GetContext()
        {
            if(obuvnayaFabrikaModel == null)
            {
                obuvnayaFabrikaModel = new ObuvnajaFabricaEntity();
            }
            return obuvnayaFabrikaModel;
        }
    }
}
