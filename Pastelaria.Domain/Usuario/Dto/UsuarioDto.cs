using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastelaria.Domain.Usuario.Dto
{
    public class UsuarioDto
    {
        [Display(Name = "Identificador")]
        public int Id { get; set; }

        [Display(Name = "Tipo de Usuário")]
        [Required(ErrorMessage = "O tipo de usuário é obrigatório")]
        public int CodigoTipoUsuario { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Preencha o campo Email")]
        [MaxLength(70, ErrorMessage = "Máximo {0} caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um e-mail válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [MaxLength(30, ErrorMessage = "Máximo {0} caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(80, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Data de nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? DataNascimento { get; set; }

        [Display(Name = "Telefone fixo")]
        public string Telefonefixo { get; set; }

        [Display(Name = "Celular")]
        public string TelefoneCelular { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
        public string Foto { get; set; }
    }
}
