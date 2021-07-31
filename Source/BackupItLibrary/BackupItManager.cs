using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BackupItLogic
{
	public class BackupItManager
	{
		BackupItManager()
		{
		}

		public static Checksum GetChecksumForDirectory(string directoryPath)
		{
			string[] filePaths = Directory.GetFiles(directoryPath);
			List<byte> directoryByteList = new List<byte>();

			foreach (string filePath in filePaths)
			{
				string[] fileParts = filePath.Split('\\');
				string fileName = fileParts[fileParts.Length - 1];

				// Skip the ".backupit" file since this is where we store the checksum
				if (fileName == ".backupit")
					continue;

				// Get the file name bytes
				byte[] fileNameBytes = Encoding.Default.GetBytes(fileName);
				foreach (byte b in fileNameBytes)
				{
					directoryByteList.Add(b);
				}

				// Get the "Date modified" bytes
				byte[] dateModified = BitConverter.GetBytes(Directory.GetLastWriteTimeUtc(filePath).ToBinary());
				foreach (byte b in dateModified)
				{
					directoryByteList.Add(b);
				}
			}

			// Convert the array into a hash
			byte[] hash = MD5.HashData(directoryByteList.ToArray());

			Checksum checksum = new Checksum(directoryPath, hash);

			return checksum;
		}
	}
}
