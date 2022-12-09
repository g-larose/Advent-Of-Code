using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code._2015.Day4
{
    public class Day4 : Solution
    {
        public Day4() : base(2015, 4)
        {
            Part_One();
            Part_Two();
        }

        public void Part_One()
        {
            var hash = "";
            var count = 0;
            do
            {
                hash = CreateMD5Hash($"ckczppom{count}");
                Console.WriteLine(hash);
                count++;
            } while (hash.Substring(0, 5) != "00000");

            Console.WriteLine(count - 1);
        }

        public void Part_Two()
        {
            var hash = "";
            var count = 0;
            do
            {
                hash = CreateMD5Hash($"ckczppom{count}");
                Console.WriteLine(hash);
                count++;
                if (count > count + 100000)
                    Console.WriteLine(hash);
            } while (hash.Substring(0, 6) != "000000");

            Console.WriteLine(count - 1);
        }

        public string CreateMD5Hash(string input)
        {
            // Step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
