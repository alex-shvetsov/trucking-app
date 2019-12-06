using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trucking_app
{
    public class ArrayString
    {
        private List<string> array;

        public ArrayString(List<string> array)
        {
            this.array = array;
        }

        public override string ToString()
        {
            string result = "(";

            foreach (string e in array)
            {
                result += ("'" + e + "', ");
            }

            result = result.Substring(0, result.Length - 2) + ")";

            return result;
        }
    }
}
