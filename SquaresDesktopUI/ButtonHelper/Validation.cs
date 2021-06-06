using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresDesktopUI.ButtonHelper
{
    public static class Validation
    {
        public static bool CheckButtonNameCanBeConvertedToPointModel(string name)
        {
            if(name.Length != 4)
            {
                //throw new Exception($"Button name length is invalid {name}");
                return false;
            }

            if(!(char.IsDigit(name[1]) && char.IsDigit(name[3])))
            {
                //throw new Exception($"Name has invalid numerical terms {name}");
                return false;
            }

            if(!(name[0] == 'x' && name[3] == 'y'))
            {
                //throw new Exception($"Name has invalid x and y terms {name}");
                return false;
            }

            return true;
        }
    }
}
