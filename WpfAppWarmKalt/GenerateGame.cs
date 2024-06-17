using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppWarmKalt
{
    public static class GenerateGame
    {
        public static int SpielMode(string mode)
        {
            Random rnd = new Random();
            if (mode == "normal")
            {
                return rnd.Next(0,100);
            
            }else return rnd.Next(0,1000);
            
        }
    }
}
