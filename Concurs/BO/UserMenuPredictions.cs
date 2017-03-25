using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurs.BO
{
    public class UserMenuPredictions
    {
        public string UserId { get; set; }
        public List<MenuPrediction> MenuPredictionList { get; set; }


        public UserMenuPredictions()
        {
            MenuPredictionList = new List<MenuPrediction>();
        }
    }

}
