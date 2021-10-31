using BackupItLogic;
using BackupItConsole.Commands;
using System;


namespace BackupItConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello BackupIt!");

			// Exit if we don't have any arguments
			if (args.Length == 0)
			{
				CommandNotFound(args);
				return;
			}

			// Get the primary command
			Enum.TryParse<Command>(args[0], true, out Command command);

			ICommandInterface activeCommand = null;
			switch (command)
			{
				case Command.Track:
					activeCommand = new TrackCommand(args);
					break;
				// No valid command was found
				default:
					CommandNotFound(args);
					break;
			}

			if (activeCommand != null)
			{
				activeCommand.Execute();
			}

			// Checksum checksum = BackupItManager.GetChecksumForDirectory(@"D:\Repos\backup-it");
			// checksum.Save();
		}

		static void CommandNotFound(string[] args)
		{
			// Prepare arguments string for writing
			string arguments = null;
			foreach (string s in args)
			{
				arguments += s + " ";
			}
			if(arguments != null)
				arguments = arguments.Trim();

			Console.WriteLine($"The command '{arguments}' is not a valid command. Unfortunately no help is present at the moment so if you need it get in touch with developer.");
		}
	}
}
