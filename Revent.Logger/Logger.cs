using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revent.Logger
{
	using Raven.Client;
	using Raven.Client.Document;

	public class Logger: IDisposable
	{
		private DocumentStore store;

		//private IDocumentSession session;

		public Logger(string ravenUrl)
		{
			this.store = new DocumentStore{ Url = ravenUrl };
			this.store.Initialize();
			//this.session = store.OpenSession("LogStore");
		}

		public void Store(Event eventToStore)
		{
			var session = store.OpenSession("LogStore");
			session.Store(eventToStore);
			session.SaveChanges();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				//if (session != null)
				//{
				//	session.Dispose();
				//	session = null;
				//}
				
				if (store != null)
				{
					store.Dispose();
					store = null;
				}
			}
		}
	}
}
