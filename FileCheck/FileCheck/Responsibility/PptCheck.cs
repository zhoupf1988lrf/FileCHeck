using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FileCheck.Responsibility
{
    /// <summary>
    /// Microsoft PowerPoint 97-2003 演示文稿的真实格式检测
    /// </summary>
    public class PptCheck : AbsCheck
    {
        public override void Check(FileCheckContext context)
        {
            if(context.ValidateFileExts.Contains(Enums.FileExt.PPT)
                &&context.FileStreamHeaderExt==Enums.FileStreamHeaderExt.PPT)
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
