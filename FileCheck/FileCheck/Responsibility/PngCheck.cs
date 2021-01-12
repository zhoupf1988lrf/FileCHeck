using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FileCheck.Responsibility
{
    /// <summary>
    /// PNG文件的检测
    /// </summary>
    public class PngCheck : AbsCheck
    {
        public override void Check(FileCheckContext context)
        {
            if (context.ValidateFileExts.Contains(Enums.FileExt.PNG)
                && context.FileStreamHeaderExt == Enums.FileStreamHeaderExt.PNG)
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
