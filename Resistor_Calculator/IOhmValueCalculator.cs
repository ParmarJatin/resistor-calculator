using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resistor_Calculator
{
    interface IOhmValueCalculator
    {
        int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor);
    }
}
