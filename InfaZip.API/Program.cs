using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using InfaZip.API;

namespace InfaZip.API
{

    class Program
    {
        static string[] args;
        static string TempPath1 = Environment.CurrentDirectory + @"\Temp1";
        static string TempPath2 = Environment.CurrentDirectory + @"\Temp2";
        static string TempPath3 = Environment.CurrentDirectory + @"\Temp3";
        static string MainPath = Environment.CurrentDirectory;
        static string SafeName = File.ReadAllText(MainPath + @"\ZipName.txt");

        static int layers = 200;
       
        static void Main()
        {
            Console.WriteLine("Working....");
            args = Environment.GetCommandLineArgs();
            Directory.CreateDirectory(TempPath1);
            Directory.CreateDirectory(TempPath2);
            Directory.CreateDirectory(TempPath3);
            File.Copy(MainPath + @"\endmsg.txt", TempPath3 + @"\end.txt");
            LONGGG();
        }
        static void one()
        {
            if (File.Exists(TempPath2 + @"\" + SafeName) == true)
            {
                File.Delete(TempPath2 + @"\" + SafeName);
            }
            if (File.Exists(TempPath3 + @"\end.txt") == true)
            {
                ZipFile.CreateFromDirectory(TempPath3, TempPath1 + @"\" + SafeName);
                File.Delete(TempPath3 + @"\end.txt");
                Directory.Delete(TempPath3);
            }
            ZipFile.CreateFromDirectory(TempPath1, TempPath2 + @"\" + SafeName);
        }
        static void two()
        {
            if (File.Exists(TempPath1 + @"\" + SafeName) == true)
            {
                File.Delete(TempPath1 + @"\" + SafeName);
            }

            ZipFile.CreateFromDirectory(TempPath2, TempPath1 + @"\" + SafeName);
        }
        static void enddd()
        {
            Console.WriteLine("Done!");
            
            Directory.Delete(TempPath1);
            Directory.Delete(TempPath2);
            Directory.Delete(TempPath3);
            Console.Write("Done!");
            return;
        }
        static void LONGGG()
        {
            
            
                for (int i = 0; i < layers; i++)
                {
                    one();
                    two();
                    if (i == layers)
                    {
                        enddd();

                    }
                }
            
        }
    }
}