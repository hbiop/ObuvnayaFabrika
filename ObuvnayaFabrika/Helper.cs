
using ObuvnayaFabrika.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObuvnayaFabrika
{
    public class Helper
    {
        private static ObuvnajaFabrikaEntity obuvnayaFabrikaModel;

        public static ObuvnajaFabrikaEntity GetContext()
        {
            if(obuvnayaFabrikaModel == null)
            {
                obuvnayaFabrikaModel = new ObuvnajaFabrikaEntity();
            }
            return obuvnayaFabrikaModel;
        }
    }
}
