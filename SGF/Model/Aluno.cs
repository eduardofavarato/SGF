﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.Model
{
	public class Aluno
	{
        public string Id { get; set; }

        public string UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

		[JsonProperty(PropertyName = "matricula")]
		public string Matricula { get; set; }

        public string TurmaId { get; set; }

        public Turma Turma { get; set; }
	}
}
