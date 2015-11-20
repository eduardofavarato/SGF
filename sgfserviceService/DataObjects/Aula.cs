using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgfserviceService.DataObjects
{
	public class Aula : EntityData
	{
		public bool Presenca { get; set; }

        public string FrequenciaId { get; set; }

        [ForeignKey("FrequenciaId")]
		public virtual Frequencia Frequencia { get; set; }
	}
}
