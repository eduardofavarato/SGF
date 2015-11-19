using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.Model
{
	class Disciplina
	{
		public string Id { get; set; }

		[JsonProperty(PropertyName = "nome")]
		public string Nome { get; set; }
	}
}
