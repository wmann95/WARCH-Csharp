using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WARCH.emulator
{
    internal class CPU
    {
        List<Int64> registers;
        Int64 pc;

        public bool halt
        {
            get;
            private set;
        }

        public CPU(int registerCount)
        {
            registers = new List<Int64>();

            for(int i = 0; i < registerCount; i++)
            {
                registers.Add(0);
            }
        }

        private UInt64 getBits(UInt64 inst, int width, int lsb)
        {
            return (UInt64)(((uint)inst & ((1 << width) - 1)) >> lsb);
        }

        public void compute(UInt64 instruction, ref Storage storage)
        {
            UInt64 op = getBits(instruction, 8, 56);
            UInt64 ra = getBits(instruction, 4, 8);
            UInt64 rb = getBits(instruction, 4, 4);
            UInt64 rc = getBits(instruction, 4, 0);
            UInt64 rl = getBits(instruction, 4, 52);
            UInt64 lv = getBits(instruction, 52, 0);

            switch (op)
            {
                case 0: cmov(ra, rb, rc); break;
                case 1: seg_load(ra, rb, rc, ref storage); break;
                case 2: seg_store(ra, rb, rc, ref storage); break;
                case 3: add(ra, rb, rc); break;
                case 4: mul(ra, rb, rc); break;
                case 5: div(ra, rb, rc); break;
                case 6: nand(ra, rb, rc); break;
                case 7: map_seg(ra, rb, rc); break;
                case 8: unmap_seg(ra, rb, rc); break;
                case 9: output(ra, rb, rc); break;
                case 10: input(ra, rb, rc); break;
                case 11: load_prog(ra, rb, rc); break;
                case 12: load_val(ra, rb, rc); break;
            }

        }

        private void cmov(UInt64 ra, UInt64 rb, UInt64 rc)
        {
            if(rc != 0)
            {
                registers[(int)ra] = registers[(int)rb];
            }
        }

        private void seg_load(UInt64 ra, UInt64 rb, UInt64 rc, ref Storage storage)
        {

        }

        private void seg_store(UInt64 ra, UInt64 rb, UInt64 rc, ref Storage storage)
        {

        }

        private void add(UInt64 ra, UInt64 rb, UInt64 rc)
        {

        }

        private void mul(UInt64 ra, UInt64 rb, UInt64 rc)
        {

        }

        private void div(UInt64 ra, UInt64 rb, UInt64 rc)
        {

        }

        private void nand(UInt64 ra, UInt64 rb, UInt64 rc)
        {

        }

        private void map_seg(UInt64 ra, UInt64 rb, UInt64 rc)
        {

        }

        private void unmap_seg(UInt64 ra, UInt64 rb, UInt64 rc)
        {

        }

        private void output(UInt64 ra, UInt64 rb, UInt64 rc)
        {

        }

        private void input(UInt64 ra, UInt64 rb, UInt64 rc)
        {

        }

        private void load_prog(UInt64 ra, UInt64 rb, UInt64 rc)
        {

        }

        private void load_val(UInt64 ra, UInt64 rb, UInt64 rc)
        {

        }

    }
}
