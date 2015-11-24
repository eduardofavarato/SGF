using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.Model
{
	public class Aula
	{
		public string Id { get; set; }

		[JsonProperty(PropertyName = "presenca")]
		public bool Presenca { get; set; }

        public string FrequenciaId { get; set; }
        public Frequencia Frequencia { get; set; }
	}
}
