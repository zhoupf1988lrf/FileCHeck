using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using FileCheck.Enums;

namespace FileCheck.Responsibility
{
    public abstract class AbsCheck
    {
        public abstract void Check(FileCheckContext context);
        private AbsCheck _nextCheck;
        public void SetNext(AbsCheck absCheck)
        {
            this._nextCheck = absCheck;
        }
        protected void CheckNext(FileCheckContext context)
        {
            if (this._nextCheck != null)
            {
                this._nextCheck.Check(context);
            }
            else
            {
                context.IsValid = false;
                context.ErrorMsg = "该文件已经被篡改，请上传合法的文件";
            }
        }
    }
}
