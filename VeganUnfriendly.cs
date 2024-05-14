using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak3
{
    internal class VeganUnfriendly :Exception
    {
        public VeganUnfriendly(string poruka) : base(poruka) { }
    }
}
