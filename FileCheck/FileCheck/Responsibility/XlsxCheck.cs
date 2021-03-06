﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FileCheck.Responsibility
{
    /// <summary>
    /// Microsoft Excel工作表(.xlsx)的真实格式检测
    /// </summary>
    public class XlsxCheck : AbsCheck
    {
        public override void Check(FileCheckContext context)
        {
            if (context.ValidateFileExts.Contains(Enums.FileExt.XLSX)
                && context.FileStreamHeaderExt == Enums.FileStreamHeaderExt.XLSX)
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
