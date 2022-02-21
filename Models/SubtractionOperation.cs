using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    public class SubtractionOperation : IOperation<float>
    {
        public float Item1 { get; set; }
        public float Item2 { get; set; }

        public SubtractionOperation(float item1, float item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        public float Operate()
        {
            return Item1 - Item2;
        }
    }
}
