using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FileCheck.Responsibility
{
    /// <summary>
    /// ASP.NET Server Page真实格式的检测
    /// </summary>
    public class AspxCheck : AbsCheck
    {
        public override void Check(FileCheckContext context)
        {
            if (context.ValidateFileExts.Contains(Enums.FileExt.ASPX)
                && context.FileStreamHeaderExt == Enums.FileStreamHeaderExt.ASPX)
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
