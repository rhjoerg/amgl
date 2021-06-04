using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amgl.action
{
    class ProgressRange
    {
        public readonly double Min;
        public readonly double Max;
        public readonly double Len;

        public ProgressRange(double min, double max)
        {
            Min = min;
            Max = max;
            Len = max - min;
        }

        public double Interpolate(int step, int count)
        {
            return Min + Len / Math.Max(1, count) * step;
        }
    }
}
