using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_Project
{
    public static class SharedMemoryManager
    {
        private const string MapName = "SharedTaskMap";
        private const long Capacity = 10000;  // Capacity of the memory-mapped file

        public static MemoryMappedFile mmf { get; private set; }
        public static MemoryMappedViewAccessor Accessor { get; private set; }

        static SharedMemoryManager()
        {
            InitializeMemory();
        }

        public static void InitializeMemory()
        {
            mmf = MemoryMappedFile.CreateOrOpen(MapName, Capacity);
            Accessor = mmf.CreateViewAccessor();
        }

        public static void ReinitializeAccessor(long newCapacity)
        {
            Accessor.Dispose(); // Dispose of the old accessor
            Accessor = mmf.CreateViewAccessor(0, newCapacity); // Create a new accessor with the updated capacity
        }
    }


}
