using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedC_03
{
    internal interface CustomComparer
    {
        bool Compare(int x, int y);
    }
    class AscComparer : CustomComparer
    {
        public bool Compare(int x, int y)=> x > y;
        
    }
    class DescComparer : CustomComparer
    {
        public bool Compare(int x, int y)=> x < y;
        
    }
}
