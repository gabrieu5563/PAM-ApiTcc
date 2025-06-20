using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTcc.Models
{
    public class Requisicao
    {
        public int Id { get; set; }
        public string Prompt { get; set; }
        public DateTime CriadoEm { get; set; }
        public int UsuarioId { get; set; }
    }
}
