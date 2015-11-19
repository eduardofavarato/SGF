using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.Model
{
	class ResponsavelAluno
	{
		public string Id { get; set; }

		public Responsavel Responsavel { get; set; }

		public Aluno Aluno { get; set; }
	}
}
