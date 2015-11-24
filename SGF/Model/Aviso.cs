using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.Model
{
	public class Aviso
	{
		public string Id { get; set; }

        public string TurmaDisciplinaId { get; set; }
        public TurmaDisciplina TurmaDisciplina { get; set; }
	}
}
