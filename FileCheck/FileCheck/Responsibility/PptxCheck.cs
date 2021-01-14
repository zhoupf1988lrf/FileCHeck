using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FileCheck.Responsibility
{
    /// <summary>
    /// Microsoft PowerPoint 演示文稿 真实格式的检测
    /// </summary>
    public class PptxCheck : AbsCheck
    {
        public override void Check(FileCheckContext context)
        {
            if(context.ValidateFileExts.Contains(Enums.FileExt.PPTX)
                && context.FileStreamHeaderExt==Enums.FileStreamHeaderExt.PPTX)
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
