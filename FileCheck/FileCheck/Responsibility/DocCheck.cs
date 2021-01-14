using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FileCheck.Responsibility
{
    /// <summary>
    /// Microsoft Word 97-2003文档真实格式的检测
    /// </summary>
    public class DocCheck : AbsCheck
    {
        public override void Check(FileCheckContext context)
        {
            if (context.ValidateFileExts.Contains(Enums.FileExt.DOC)
                && context.FileStreamHeaderExt == Enums.FileStreamHeaderExt.DOC)
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
