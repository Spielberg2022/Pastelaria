using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Pastelaria.Domain
{
    class UsuarioDto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string UsuarioId { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; }
        public DateTime Nascimento { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
        public Byte[] Foto { get; set; }
    }
}
