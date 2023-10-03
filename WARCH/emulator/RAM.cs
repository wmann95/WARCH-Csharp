using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WARCH.emulator
{
    internal class RAM
    {
        List<List<UInt64>> segments;
        Stack<UInt64> free_segs;

        public RAM()
        {
            segments = new List<List<UInt64>>();
            free_segs = new Stack<UInt64>();
        }

        public UInt64 RequestSeg(UInt64 size)
        {
            UInt64 id = 0;

            if (free_segs.Count > 0)
            {
                id = free_segs.Pop();
                segments[(int)id] = new List<UInt64>(new UInt64[size]);
            }
            else
            {
                id = (UInt64)segments.Count;
                segments.Add(new List<UInt64>(new UInt64[size]));
            }

            return id;
        }

        public void ReleaseSeg(UInt64 id)
        {
            free_segs.Push(id);
        }

        public void DuplicateSeg(UInt64 id, UInt64 to)
        {
            segments[(int)to] = segments[(int)id];
        }

        public UInt64 Get(UInt64 id, UInt64 index)
        {
            return segments[(int)id][(int)index];
        }

        public void Set(UInt64 id, UInt64 index, UInt64 value)
        {
            segments[(int)id][(int)index] = value;
        }
    }
}
