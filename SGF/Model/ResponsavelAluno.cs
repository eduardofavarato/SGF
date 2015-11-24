using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.Model
{
	public class ResponsavelAluno
	{
		public string Id { get; set; }

        public string ResponsavelId { get; set; }
        public Responsavel Responsavel { get; set; }

        public string AlunoId { get; set; }
        public Aluno Aluno { get; set; }
	}
}
