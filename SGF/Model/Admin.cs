using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.Model
{
	class Admin
	{
        public string Id { get; set; }
        public Usuario Usuario { get; set; }

		[JsonProperty(PropertyName = "matricula")]
		public string Matricula { get; set; }
	}
}
