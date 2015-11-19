using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgfserviceService.DataObjects
{
	public class TurmaDisciplina : EntityData
	{
		[ForeignKey("TurmaId")]
		public virtual Turma Turma { get; set; }

		[ForeignKey("DisciplinaId")]
		public virtual Disciplina Disciplina { get; set; }

		[ForeignKey("ProfessorId")]
		public virtual Professor Professor { get; set; }
	}
}
