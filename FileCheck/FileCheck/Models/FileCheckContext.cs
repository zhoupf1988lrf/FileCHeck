using System;
using System.Collections.Generic;
using System.Text;
using FileCheck.Enums;
using System.IO;

namespace FileCheck
{
    /// <summary>
    /// 文件检查的上下文
    /// </summary>
    public class FileCheckContext
    {
        /// <summary>
        /// 文件的绝对地址(FileStream!=null时，FileAbsoluteUrl允许为null)
        /// </summary>
        public string FileAbsoluteUrl { get; set; }
        /// <summary>
        /// 文件的字节序列(优先使用字节序列)
        /// </summary>
        public byte[] FileBytes { get; set; }
        /// <summary>
        /// 验证的文件扩展名
        /// </summary>
        public FileExt[] ValidateFileExts { get; set; }
        /// <summary>
        /// 文件二进制流的头文件
        /// </summary>
        public FileStreamHeaderExt FileStreamHeaderExt { get; set; }
        /// <summary>
        /// 该扩展名的文件是否合法
        /// </summary>
        public bool IsValid { get; set; } = false;
        /// <summary>
        /// 如果是扩展名是非法的，显示具体信息
        ///               合法的，显示空
        /// </summary>
        public string ErrorMsg { get; set; }
    }
}
