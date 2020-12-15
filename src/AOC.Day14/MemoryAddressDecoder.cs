using System;
using System.Collections;
using System.Collections.Generic;

namespace AOC.Day14
{
    public class MemoryAddressDecoder
    {
        private BitArray Mask1 { get; set; } = new BitArray(64, false);
        private BitArray MaskX { get; set; } = new BitArray(64, false);

        public void Set(string mask)
        {
            Mask1 = new BitArray(64, false);
            MaskX = new BitArray(64, false);

            var revMask = mask.ToCharArray();
            Array.Reverse(revMask);
            for (var i = 0; i < mask.Length; i++)
            {
                if (revMask[i] == '1')
                {
                    Mask1[i] = true;
                }
                else if (revMask[i] == 'X')
                {
                    MaskX[i] = true;
                }
            }
        }

        public List<ulong> Decode(ulong value)
        {
            var valueBits = new BitArray(BitConverter.GetBytes(value));
            var valueBytes = new byte[8];
            var inter = valueBits.Or(Mask1);
            var setIndexes = GetSetIndexes(MaskX);
            var masks = Permutations.Generate(setIndexes.Length);
            var addresses = new List<ulong>();
            foreach (var mask in masks)
            {
                var address = new BitArray(inter);
                for(var i=0; i<setIndexes.Length; i++)
                {
                    address[setIndexes[i]] = mask[i];
                }

                address.CopyTo(valueBytes, 0);
                addresses.Add(BitConverter.ToUInt64(valueBytes, 0));
            }

            return addresses;
        }

        private static int[] GetSetIndexes(BitArray array)
        {
            var set = new List<int>();
            for (var i = 0; i < array.Count; i++)
            {
                if (array[i])
                {
                    set.Add(i);
                }
            }
            return set.ToArray();
        }
    }
}
