﻿using System;
using System.IO;
using System.Threading.Tasks;
using FreeflyAcademy.Services.Contracts.Technical;

namespace FreeflyAcademy.Services.Technical
{
    internal class FileCopierService : IFileCopierService
    {
        public Task Copy(string sourcePath, string destPath, IProgress<double> progress = null)
        {
            return Task.Run(() =>
            {
                byte[] buffer = new byte[1024 * 1024]; // 1MB buffer

                using (FileStream source = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
                {
                    long fileLength = source.Length;
                    using (FileStream dest = new FileStream(destPath, FileMode.CreateNew, FileAccess.Write))
                    {
                        long totalBytes = 0;
                        int currentBlockSize;

                        while ((currentBlockSize = source.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            totalBytes += currentBlockSize;
                            double persentage = totalBytes * 100.0 / fileLength;

                            dest.Write(buffer, 0, currentBlockSize);

                            progress?.Report(persentage);
                        }
                    }
                }
            });
        }
    }
}
