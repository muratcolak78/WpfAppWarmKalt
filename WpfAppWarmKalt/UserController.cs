using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAppWarmKalt
{
    public static class UserController
    {
        public static bool Controller(string  userName)
        {
            var foundUser = UserManager.Users.FirstOrDefault(u => u.userName == userName);

            if (foundUser != null && UserManager.IsRadioButtonsSelected)
            {
                UserManager.User = foundUser;
                return true;
            }
            else
            {
               
                return false;
            }
        }
    }
}
