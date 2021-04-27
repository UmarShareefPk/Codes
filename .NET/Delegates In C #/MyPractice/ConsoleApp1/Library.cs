using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Library
    {
        public delegate void ShowMaxBonus(string message);
        public static int Bonus(ShowMaxBonus showMaxBonus, int performance, Action<string> comment )
        {
            showMaxBonus("You need to show 90 or above performance to get max bonus");            
            if (performance >= 90)
            {
                comment("you performed excellent");
                return 100;
            }
            else if (performance >= 80)
            {
                comment("you performed good");
                return 75;
            }
            else if (performance >= 70)
            {
                comment("you performed average");
                return 50;
            }
            else if (performance >= 60)
            {
                comment("you performed below average");
                return 30;
            }
            else
            {
                comment("find new job.");
                return 10;
            }
        }
    }
}
