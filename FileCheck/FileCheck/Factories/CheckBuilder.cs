using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using FileCheck.Enums;
using FileCheck.Responsibility;

namespace FileCheck.Factories
{
    public class CheckBuilder
    {
        /// <summary>
        /// 获取AbsCheck.
        /// 
        /// 文件的二进制流的前两个字节判断文件的真实格式
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static AbsCheck Builder(FileCheckContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (string.IsNullOrWhiteSpace(context.FileAbsoluteUrl) && context.FileStream == null)
            {
                throw new Exception($"{nameof(context.FileAbsoluteUrl)}和{nameof(context.FileStream)}不能同时为null");
            }
            FileStream fileStream = null;
            if (context.FileStream == null || context.FileStream.Length == 0)
            {
                try
                {
                    fileStream = new FileStream(context.FileAbsoluteUrl, FileMode.Open, FileAccess.Read);
                    context.FileStream = fileStream;
                }
                catch (Exception ex)
                {
                    throw new Exception("获取文件流失败", ex);
                }
            }
            if (context.FileStream == null || context.FileStream.Length == 0)
            {
                throw new ArgumentNullException(nameof(context.FileStream));
            }

            string fileType = string.Empty;
            using (BinaryReader reader = new BinaryReader(context.FileStream))
            {
                for (int i = 0; i < 2; i++)
                {
                    fileType += reader.ReadByte().ToString();
                }
            }
            fileStream.Dispose();

            FileStreamHeaderExt headerExt = FileStreamHeaderExt.VALIDFILE;
            if (Enum.TryParse(fileType, out FileStreamHeaderExt result))
            {
                headerExt = result;
            }
            context.FileStreamHeaderExt = headerExt;


            AbsCheck jpgCheck = new JpgCheck();
            AbsCheck pngCheck = new PngCheck();
            AbsCheck bmpCheck = new BmpCheck();
            AbsCheck gifCheck = new GifCheck();
            AbsCheck txtCheck = new TxtCheck();
            AbsCheck xlsCheck = new XlsCheck();
            AbsCheck xlsxCheck = new XlsxCheck();
            jpgCheck.SetNext(pngCheck);
            pngCheck.SetNext(bmpCheck);
            bmpCheck.SetNext(gifCheck);
            gifCheck.SetNext(txtCheck);
            txtCheck.SetNext(xlsCheck);
            xlsCheck.SetNext(xlsxCheck);
            return jpgCheck;
        }
    }
}
