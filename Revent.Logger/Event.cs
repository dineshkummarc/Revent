using System;

namespace Revent.Logger
{
	public class Event
	{
		public string Message { get; set; }

		public DateTime CreatedOn{ get; set; }

		public string Application { get; set;}

		public object Metadata { get; set; }

		public string EventLevel { get; set; }

		public Event()
		{
			this.CreatedOn = DateTime.Now;
		}
	}
}
