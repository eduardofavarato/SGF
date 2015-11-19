using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgfserviceService.DataObjects
{
	public class Nota : EntityData
	{
		public float VA1 { get; set; }
		
		public float VA2 { get; set; }
		
		public float VA3 { get; set; }

		[ForeignKey("TurmaDisciplinaId")]
		public virtual TurmaDisciplina TurmaDisciplina { get; set; }

		[ForeignKey("AlunoId")]
		public virtual Aluno Aluno { get; set; }
	}
}
