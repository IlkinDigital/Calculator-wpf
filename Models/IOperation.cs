using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    public interface IOperation<Ty>
    {
        public Ty Item1 { get; set; }
        public Ty Item2 { get; set; }

        public Ty Operate();
    }
}
