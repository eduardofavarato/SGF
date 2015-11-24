using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.Model
{
	public class TurmaDisciplina
	{
		public string Id { get; set; }

        public string TurmaId { get; set; }
        public Turma Turma { get; set; }

        public string DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }

        public string ProfessorId { get; set; }
        public Professor Professor { get; set; }
		
	}
}
