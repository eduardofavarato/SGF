using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgfserviceService.DataObjects
{
	public class Turma : EntityData
	{
		public string Nome { get; set; }

		public string SerieId { get; set; }

		[ForeignKey("SerieId")]
		public virtual Serie Serie { get; set; }
	}
}
