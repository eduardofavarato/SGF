using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.Model
{
	class TurmaDisciplina
	{
		public string Id { get; set; }

		public Turma Turma { get; set; }
	
		public Disciplina Disciplina { get; set; }

		public Professor Professor { get; set; }
		
	}
}
