using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tradetool.Utilities
{
    public static class ConvertHelper
    {
        public static decimal ToDecimal(string value)
        {
            try
            {
                return decimal.Parse(value);
            }
            catch
            {
                return 0;
            }
        }
    }
}
