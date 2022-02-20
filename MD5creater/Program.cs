using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MD5creater
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
          
            string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*", SearchOption.AllDirectories);

            Console.WriteLine("Pfad: " + AppDomain.CurrentDomain.BaseDirectory);

            foreach (var fileName in files)
            {
                string hash = CalculateMD5(fileName);
                Console.WriteLine(fileName + "   Hash: " + hash);
                sb.Append(hash + "\n");
            }


            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "hashlist.txt", sb.ToString());

            Console.ReadLine();
        }

        static string CalculateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
    }

   

   
}
