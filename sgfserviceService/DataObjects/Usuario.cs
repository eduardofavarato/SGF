﻿using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgfserviceService.DataObjects
{
    public class Usuario : EntityData
    {
        public string Nome { get; set; }
        
        public string Login { get; set; }
        
        public string Senha { get; set; }
    }
}
