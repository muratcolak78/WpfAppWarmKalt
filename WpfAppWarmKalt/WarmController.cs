using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAppWarmKalt
{
    public static class WarmController
    {
        public static string Controller(int number1, int number2, int number3, int number4 ) {
            int fark1 = number1 - number2;
            int fark2= number3 - number4;

           
            if (fark1 < 0) fark1 = -fark1;
            if (fark2 < 0) fark2= -fark2;
            if (fark1 < fark2) return "Warm";
            
            else return "Kalt";
        }
    }
}
