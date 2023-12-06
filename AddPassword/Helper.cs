using AddPassword.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddPassword
{
    internal class Helper
    {
        private static ObuvnajaFabricaEntities obuvnayaFabrikaModel;

        public static ObuvnajaFabricaEntities GetContext()
        {
            if (obuvnayaFabrikaModel == null)
            {
                obuvnayaFabrikaModel = new ObuvnajaFabricaEntities();
            }
            return obuvnayaFabrikaModel;
        }
    }
}
