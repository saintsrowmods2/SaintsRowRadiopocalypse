using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ThomasJepp.SaintsRow;

namespace RadioSwapper
{
    public static class DurationCalculator
    {
        public static decimal GetDuration(string file)
        {
            decimal sampleRate = 0;
            decimal samples = 0;
            using (Stream s = File.OpenRead(file))
            {
                s.Seek(12, SeekOrigin.Begin); // start of chunks
                while (s.Position < s.Length)
                {
                    uint chunkType = s.ReadUInt32();
                    uint chunkSize = s.ReadUInt32();
                    long chunkStart = s.Position;

                    switch (chunkType)
                    {
                        case 0x20746D66:
                            // fmt
                            if (chunkSize == 0x42)
                            {
                                s.ReadUInt16(); // codec id
                                s.ReadUInt16(); // channells
                                sampleRate = s.ReadUInt32(); // sample rate
                                s.Seek(chunkStart + 0x18, SeekOrigin.Begin);
                                samples = s.ReadUInt32();
                            }
                            break;
                    }

                    s.Seek(chunkStart + chunkSize, SeekOrigin.Begin);
                }


            }

            if (sampleRate == 0 || samples == 0)
                return 0;

            decimal durationS = samples / sampleRate;
            decimal durationMs = durationS * 1000;

            return Math.Ceiling(durationMs);
        }
    }
}
