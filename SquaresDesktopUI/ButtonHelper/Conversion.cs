using SquaresUI.Library.Models.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SquaresDesktopUI.ButtonHelper
{
    public static class Conversion
    {
        public static PointModel ButtonNameToPointModel(string buttonName)
        {
            if (Validation.CheckButtonNameCanBeConvertedToPointModel(buttonName))
            {
                throw new Exception($"Invalid button name {buttonName}");
            }

            //The name should by in the for x0y7
            //So the 1st and 3rd index should be x and y respectiveley 
            return new PointModel() { XCoord = (buttonName[1] - '0'), YCoord = (buttonName[3] - '0') };
        }
    }
}
