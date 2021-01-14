using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FileCheck.Responsibility
{
    /// <summary>
    /// Microsoft Word 文档 真实格式的检测
    /// </summary>
    public class DocxCheck : AbsCheck
    {
        public override void Check(FileCheckContext context)
        {
            if (context.ValidateFileExts.Contains(Enums.FileExt.DOCX)
                && context.FileStreamHeaderExt == Enums.FileStreamHeaderExt.DOCX)
            {
                context.IsValid = true;
                context.ErrorMsg = "";
            }
            else
            {
                base.CheckNext(context);
            }
        }
    }
}
