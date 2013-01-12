using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revent.Logger.IntegrationTests
{
	using Xunit;

	public class Sandbox
    {
		[Fact]
		public void Play()
		{
			Revent.Error("Second test from static implementation", new {something = "yep, it's new"});
		}

		class ImportantBusinessObject
		{
			public int Id { get; set; }

			public string Name { get; set; }

			public DateTime DateCreated { get; set; }

			public string OtherInformation { get; set; }

			public ImportantBusinessObject()
			{
				this.Id = 1;
				this.Name = "I'm Important";
				this.DateCreated = DateTime.Now.AddYears(-40);
				this.OtherInformation = "Don't you know who I am?";
			}
		}
    }
}
