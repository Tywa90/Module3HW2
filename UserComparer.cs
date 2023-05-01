using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    public class UserComparer : IComparer<User>
    {
        private CultureInfo _culture;

        public UserComparer(CultureInfo culture)
        {
            _culture = culture;
        }

        public int Compare(User? x, User? y)
        {
            return string.Compare(x.Name, y.Name, _culture, CompareOptions.IgnoreCase);
        }
    }
}
