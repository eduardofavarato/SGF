using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.Model
{
	public class Turma
	{
		public string Id { get; set; }

		[JsonProperty(PropertyName = "nome")]
		public string Nome { get; set; }

        public string SerieId { get; set; }
        public Serie Serie { get; set; }

	}
}
