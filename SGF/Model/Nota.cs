using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.Model
{
	public class Nota
	{
		public string Id { get; set; }

		[JsonProperty(PropertyName = "VA1")]
		public float VA1 { get; set; }

		[JsonProperty(PropertyName = "VA2")]
		public float VA2 { get; set; }

		[JsonProperty(PropertyName = "VA3")]
		public float VA3 { get; set; }

        public string TurmaDisciplinaId { get; set; }
        public TurmaDisciplina TurmaDisciplina { get; set; }

        public string AlunoId { get; set; }
        public Aluno Aluno { get; set; }
	}
}
