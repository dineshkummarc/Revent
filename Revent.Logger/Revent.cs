using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revent.Logger
{
	using System.Configuration;

	public class Revent
	{
		private static readonly ReventConfig config;

		private static readonly Logger logger;
		
		static Revent()
		{
			//read in configuruation file
			var ravenUrl = ConfigurationManager.AppSettings["ReventStore"];
			var appName = ConfigurationManager.AppSettings["ReventApplicationName"];
			config = new ReventConfig();
			config.ApplicationName = appName;
			logger = new Logger(ravenUrl);
		}

		public static ReventConfig Configuration
		{
			get
			{
				return config;
			}
		}

		private static void Log(string message, string eventLevel, object metadata)
		{
			var sevent = new Event()
			{
				Application = config.ApplicationName,
				EventLevel = eventLevel,
				Message = message,
				Metadata = metadata
			};
			logger.Store(sevent);
		}

		public static void Warn(string message, object metadata = null )
		{
			Log(message, "Warn", metadata);
		}

		public static void Error(string message, object metadata = null)
		{
			Log(message, "Error", metadata);
		}

		public static void Info(string message, object metadata = null)
		{
			Log(message, "Info", metadata);
		}
	}
}
