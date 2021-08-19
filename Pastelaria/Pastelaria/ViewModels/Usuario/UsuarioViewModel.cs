using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Pastelaria.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        [DisplayName("Identificador")]
        public int Id { get; }

        [Required(ErrorMessage ="Especifique um tipo de usuario ")]
        [DisplayName("Tipo de Usuário")]
        public int CodigoTipoUsuario { get; set; }

        [Required(ErrorMessage = "Preencha o campo Email")]
        [MaxLength(70, ErrorMessage = "Máximo {0} caracteres")]
        [EmailAddress(ErrorMessage ="Preencha um e-mail válido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha o campo Senha")]
        [MaxLength(30, ErrorMessage = "Máximo {0} caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(80, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2,ErrorMessage ="Mínimo {0} caracteres")]
        public string Nome { get; set; }

        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [DisplayName("Telefone Fixo")]
        public string Telefonefixo { get; set; }

        [DisplayName("Celular")]
        public string TelefoneCelular { get; set; }

        public string Logradouro { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Uf { get; set; }

        public string Cep { get; set; }

        public string Foto { get; set; }

    }
}