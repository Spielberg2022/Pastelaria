using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Pastelaria.Domain.DisparoEmail.Dto
{
    class DisparoEmailDto
    {
        public int Id { get; }
        public int IdTarefa { get; set; }
        public int IdUsuarioDestinatario { get; set; }
        public int CodigoTipoEmail { get; set; }
        public string Mensagem { get; set; }
        public string Assunto { get; set; }
    }
}
