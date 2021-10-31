using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupItConsole.Commands
{
	public enum Command
	{
		InvalidCommand,
		Track
	}

	public abstract class CommandBase : ICommandInterface
	{
		protected string[] CommandArguments { get; set; }

		public CommandBase(string[] commandArgs)
		{
			CommandArguments = commandArgs;
		}

		public abstract void Execute();
	}
}
