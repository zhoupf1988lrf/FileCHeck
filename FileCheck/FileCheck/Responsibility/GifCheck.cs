using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FileCheck.Responsibility
{
    /// <summary>
    /// GIF图片的真实格式检测
    /// </summary>
    public class GifCheck : AbsCheck
    {
        public override void Check(FileCheckContext context)
        {
            if (context.ValidateFileExts.Contains(Enums.FileExt.GIF)
                && context.FileStreamHeaderExt == Enums.FileStreamHeaderExt.GIF)
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
