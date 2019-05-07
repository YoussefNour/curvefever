using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing_point
{
    class KeyMnager
    {
        static Dictionary<System.Windows.Forms.Keys, bool> dict = new Dictionary<System.Windows.Forms.Keys, bool>();

        public static void setKey(System.Windows.Forms.Keys k , bool state)
        {
            dict[k] = state;
        }

        public static bool getKey(System.Windows.Forms.Keys k)
        {
            if (!dict.ContainsKey(k))
                return false;

            return dict[k];
        }
    }
}
