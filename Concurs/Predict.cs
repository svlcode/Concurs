using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurs
{
    public class Predict
    {
        UserMenu _userMenu;

        public Predict(UserMenu usermenu)
        {
            _userMenu = usermenu;
        }

        public UserMenu Generate()
        {
            var result = new UserMenu();

            SetData();
            result = RunPrediction();

            return result;
        }

        public void SetData()
        {

        }

        UserMenu RunPrediction()
        {
            return new UserMenu();
        }
}
