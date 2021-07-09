using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastelaria.Domain.DisparoEmail.Dto
{
    public class DisparoEmailDto
    {
        public int Id { get; set; }
        public int IdTarefa { get; set; }
        public int IdUsuarioDestinatario { get; set; }
        public int CodigoTipoEmail { get; set; }
        public string Mensagem { get; set; }
        public string Assunto { get; set; }
    }
}
