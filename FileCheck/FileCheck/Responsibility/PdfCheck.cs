using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FileCheck.Responsibility
{
    /// <summary>
    /// Mirosoft Edge PDF Document的真实格式的检测
    /// </summary>
    public class PdfCheck : AbsCheck
    {
        public override void Check(FileCheckContext context)
        {
            if (context.ValidateFileExts.Contains(Enums.FileExt.PDF)
                && context.FileStreamHeaderExt == Enums.FileStreamHeaderExt.PDF)
            {
                context.IsValid = true;
                context.ErrorMsg = "";
            }
            else
            {
                CheckNext(context);
            }
        }
    }
}
