using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FileCheck.Responsibility
{
    /// <summary>
    /// JPG文件的检测
    /// </summary>
    public class JpgCheck : AbsCheck
    {
        public override void Check(FileCheckContext context)
        {
            if (context.ValidateFileExts.Contains(Enums.FileExt.JPG)
                && context.FileStreamHeaderExt == Enums.FileStreamHeaderExt.JPG)
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
