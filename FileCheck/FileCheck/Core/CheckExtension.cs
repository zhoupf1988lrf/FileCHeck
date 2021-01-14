using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileCheck.Core
{
    public static class CheckExtension
    {
        /// <summary>
        /// 把流转换为字节序列
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] ToFileBytes(this Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));
            byte[] fileBytes = new byte[(int)stream.Length];
            stream.Read(fileBytes, 0, fileBytes.Length);
            return fileBytes;
        }
        /// <summary>
        /// 把字节序列转换为流
        /// </summary>
        /// <param name="fileBytes"></param>
        /// <returns></returns>
        public static Stream ToStream(this byte[] fileBytes)
        {
            if (fileBytes == null || fileBytes.Length == 0)
                throw new ArgumentNullException(nameof(fileBytes));
            MemoryStream memoryStream = new MemoryStream(fileBytes);
            return memoryStream;
        }
    }
}
