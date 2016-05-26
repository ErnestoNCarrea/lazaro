using System;
using System.Collections.Generic;
using System.Text;

namespace Lfx.Services
{
	public class Task
	{
		public int Id, Status;
		public string Command, ComputerName, Creator, CreatorComputerName, Component;
		public DateTime Schedule;
	}
}
