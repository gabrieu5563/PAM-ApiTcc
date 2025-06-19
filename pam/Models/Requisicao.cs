using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pam.Models
{
    public class Requisicao
    {
        public int Id { get; set; }
        public string Prompt { get; set; }
        public DateTime CriadoEm { get; set; }
        public int UsuarioId { get; set; }
    }
}
