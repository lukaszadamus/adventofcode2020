using System;
using System.Collections;

namespace AOC.Day14
{
    public class ValueMask
    {
        private BitArray Mask1 { get; set; } = new BitArray(64, false);
        private BitArray Mask0 { get; set; } = new BitArray(64, true);

        public void Set(string mask)
        {
            Mask1 = new BitArray(64, false);
            Mask0 = new BitArray(64, true);

            var revMask = mask.ToCharArray();
            Array.Reverse(revMask);
            for (var i = 0; i < mask.Length; i++)
            {
                if (revMask[i] == '1')
                {
                    Mask1[i] = true;
                }
                else if (revMask[i] == '0')
                {
                    Mask0[i] = false;
                }
            }
        }

        public ulong Apply(ulong value)
        {
            var valueBits = new BitArray(BitConverter.GetBytes(value));
            var valueBytes = new byte[8];
            valueBits.Or(Mask1).And(Mask0).CopyTo(valueBytes, 0);
            return BitConverter.ToUInt64(valueBytes, 0);
        }
    }
}
