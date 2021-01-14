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
        /// 不同的文件类型都有文件头签名
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static AbsCheck Builder(FileCheckContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (string.IsNullOrWhiteSpace(context.FileAbsoluteUrl) && context.FileBytes == null)
            {
                throw new Exception($"{nameof(context.FileAbsoluteUrl)}和{nameof(context.FileBytes)}不能同时为null");
            }

            if (context.FileBytes == null || context.FileBytes.Length == 0)
            {
                try
                {
                    using (FileStream fileStream = new FileStream(context.FileAbsoluteUrl, FileMode.Open, FileAccess.Read))
                    {
                        context.FileBytes = new byte[(int)fileStream.Length];
                        fileStream.Read(context.FileBytes, 0, context.FileBytes.Length);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("获取文件流失败", ex);
                }
            }
            if (context.FileBytes == null || context.FileBytes.Length == 0)
            {
                throw new ArgumentNullException(nameof(context.FileBytes));
            }

            string fileType = "";
            using (MemoryStream memoryStream = new MemoryStream(context.FileBytes))
            using (BinaryReader reader = new BinaryReader(memoryStream))
            {
                for (int i = 0; i < 2; i++)
                {
                    fileType += reader.ReadByte().ToString();
                }
            }

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
            AbsCheck docCheck = new DocCheck();
            AbsCheck docxCheck = new DocxCheck();
            AbsCheck pptCheck = new PptCheck();
            AbsCheck pptxCheck = new PptxCheck();
            AbsCheck pdfCheck = new PdfCheck();
            AbsCheck zipCheck = new ZipCheck();
            AbsCheck aspxCheck = new AspxCheck();
            jpgCheck.SetNext(pngCheck);
            pngCheck.SetNext(bmpCheck);
            bmpCheck.SetNext(gifCheck);
            gifCheck.SetNext(txtCheck);
            txtCheck.SetNext(xlsCheck);
            xlsCheck.SetNext(xlsxCheck);
            xlsxCheck.SetNext(docCheck);
            docCheck.SetNext(docxCheck);
            docxCheck.SetNext(pptCheck);
            pptCheck.SetNext(pptxCheck);
            pptxCheck.SetNext(pdfCheck);
            pdfCheck.SetNext(zipCheck);
            zipCheck.SetNext(aspxCheck);
            return jpgCheck;
        }
    }
}
