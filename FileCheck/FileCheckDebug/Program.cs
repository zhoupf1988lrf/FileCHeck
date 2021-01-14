using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileCheck;
using FileCheck.Enums;
using FileCheck.Factories;

namespace FileCheckDebug
{
    class Program
    {
        static void Main(string[] args)
        {
            FileCheckContext fileCheckContext = new FileCheckContext
            {
                FileAbsoluteUrl = "C:\\Users\\Shinelon\\Desktop\\2.png",
                FileBytes = null,
                ValidateFileExts = new FileExt[] { FileExt.PNG },
                IsValid = false
            };
            var fileCheck = CheckBuilder.Builder(fileCheckContext);
            fileCheck.Check(fileCheckContext);

            if (fileCheckContext.IsValid)
            {
                Console.WriteLine("合法的格式");
            }
            else
            {
                Console.WriteLine(fileCheckContext.ErrorMsg);
            }
            Console.ReadLine();
        }
    }
}
