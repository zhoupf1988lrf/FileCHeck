using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FileCheck.Responsibility
{
    /// <summary>
    /// Microsoft Excel 97-2003工作表(.xls)真实格式的检测
    /// </summary>
    public class XlsCheck : AbsCheck
    {
        public override void Check(FileCheckContext context)
        {
            if (context.ValidateFileExts.Contains(Enums.FileExt.XLS)
               && context.FileStreamHeaderExt == Enums.FileStreamHeaderExt.XLS)
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
