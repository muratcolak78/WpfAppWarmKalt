using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppWarmKalt
{
    public static class RadioButtonController
    {
        public static bool CheckRadioButton(RadioButton radioButton)
        {
            if (radioButton.Content.ToString()== "neue spieler")
            {

                UserManager.UserType = "neue spieler";
                UserManager.IsRadioButtonsSelected = true;
                return true;
                
            }
            else if (radioButton.Content.ToString() == "vorhanden")
            {
                UserManager.UserType = "vorhanden";
                UserManager.IsRadioButtonsSelected = true;
                return true;


             }
            else if (radioButton.Content.ToString() == "normal")
            {
                UserManager.SpielMode = "normal";
                 return true;


            }
            else if (radioButton.Content.ToString() == "hard")
            {
                UserManager.SpielMode = "hard";
                return true;


            }
            
            UserManager.IsRadioButtonsSelected = false;
            return false;
        }
    }
}
