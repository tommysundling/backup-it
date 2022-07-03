using BackupItLogic;
using System;


namespace BackupItConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello Me!");

			Checksum checksum = BackupItManager.GetChecksumForDirectory(@"D:\Repos\backup-it");
			checksum.Save();
		}
	}
}
