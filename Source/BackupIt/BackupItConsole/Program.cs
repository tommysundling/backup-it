using BackupItLogic;
using System;


namespace BackupItConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			Checksum checksum = BackupItManager.GetChecksumForDirectory(@"D:\Repos\backup-it");
			checksum.Save();
		}
	}
}
