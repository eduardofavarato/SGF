using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.Model
{
	public class Usuario
	{
		public string Id { get; set; }

		[JsonProperty(PropertyName = "nome")]
		public string Nome { get; set; }

		[JsonProperty(PropertyName = "login")]
		public string Login { get; set; }

		[JsonProperty(PropertyName = "senha")]
		public string Senha { get; set; }
	}
}
