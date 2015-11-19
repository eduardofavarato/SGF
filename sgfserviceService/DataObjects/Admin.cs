using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Mobile.Service;
using System.ComponentModel.DataAnnotations.Schema;

namespace sgfserviceService.DataObjects
{
	public class Admin : EntityData
	{
		public string UsuarioId { get; set; }

		[ForeignKey("UsuarioId")]
		public virtual Usuario Usuario { get; set; }
		
		public string Matricula { get; set; }
	}
}
