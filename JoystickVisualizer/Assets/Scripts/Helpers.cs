using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpers
{
    public static class Convert
    {
        public static float Range(
                double value, // value to convert
                double originalStart, double originalEnd, // original range
                double newStart, double newEnd) // desired range
        {
            double scale = (double)(newEnd - newStart) / (originalEnd - originalStart);
            return (float)(newStart + ((value - originalStart) * scale));
        }
    }
}
