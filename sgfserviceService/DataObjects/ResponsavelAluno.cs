using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Mobile.Service;
using System.ComponentModel.DataAnnotations.Schema;

namespace sgfserviceService.DataObjects
{
	public class ResponsavelAluno : EntityData
	{
		public string ResponsavelId { get; set; }

		[ForeignKey("ResponsavelId")]
		public virtual Responsavel Responsavel { get; set; }

		public string AlunoId { get; set; }

		[ForeignKey("AlunoId")]
		public virtual Aluno Aluno { get; set; }
	}
}
