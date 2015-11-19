using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgfserviceService.DataObjects
{
	public class Professor : EntityData
	{
		public string UsuarioId { get; set; }

		[ForeignKey("UsuarioId")]
		public virtual Usuario Usuario { get; set; }

		public string Matricula { get; set; }
	}
}
