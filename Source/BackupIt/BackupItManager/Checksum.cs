using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupItLogic
{
	public class Checksum
	{
		private string directoryPath;
		private byte[] hash;

		public Checksum(string directoryPath, byte[] hash)
		{
			this.directoryPath = directoryPath;
			this.hash = hash;
		}

		public void Save()
		{
			string backupItDirectoryPath = directoryPath + @"\.backupit";
			if (!Directory.Exists(backupItDirectoryPath))
			{
				DirectoryInfo backupItDirectory = Directory.CreateDirectory(backupItDirectoryPath);
				backupItDirectory.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
			}
			File.WriteAllBytes(directoryPath + @"\.backupit\.backupit", hash);
		}
	}
}
