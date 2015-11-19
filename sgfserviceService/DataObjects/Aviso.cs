using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgfserviceService.DataObjects
{
	public class Aviso : EntityData
	{
		[ForeignKey("TurmaDisciplinaId")]
		public virtual TurmaDisciplina TurmaDisciplina { get; set; }
	}
}
