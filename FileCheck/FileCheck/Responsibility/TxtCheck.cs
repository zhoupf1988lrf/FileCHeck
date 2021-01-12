using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FileCheck.Responsibility
{
    /// <summary>
    /// txt文本文档的检测
    /// </summary>
    public class TxtCheck : AbsCheck
    {
        public override void Check(FileCheckContext context)
        {
            if (context.ValidateFileExts.Contains(Enums.FileExt.TXT)
                && context.FileStreamHeaderExt == Enums.FileStreamHeaderExt.TXT)
            {
                context.IsValid = true;
                context.ErrorMsg = string.Empty;
            }
            else
            {
                base.CheckNext(context);
            }
        }
    }
}
