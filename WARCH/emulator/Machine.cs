using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WARCH.emulator
{
    internal class Machine
    {
        internal bool halt;
        CPU cpu;
        RAM ram;
        Storage storage;

        public Machine()
        {
            storage = new Storage();
            ram = new RAM();
            cpu = new CPU(8);
        }

        internal void Update()
        {
            cpu.compute(0, ref storage);
        }
    }
}
