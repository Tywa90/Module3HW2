using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    public class User : IComparable<User>
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }

        public int CompareTo(User? other)
        {
            return string.Compare(Name, other.Name);
        }
    }
}
