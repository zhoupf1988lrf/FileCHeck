using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FileCheck.Responsibility
{
    /// <summary>
    /// 压缩(Zipped)文件夹真实格式的检测
    /// </summary>
    public class ZipCheck : AbsCheck
    {
        public override void Check(FileCheckContext context)
        {
            if (context.ValidateFileExts.Contains(Enums.FileExt.ZIP)
                && context.FileStreamHeaderExt == Enums.FileStreamHeaderExt.ZIP)
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
