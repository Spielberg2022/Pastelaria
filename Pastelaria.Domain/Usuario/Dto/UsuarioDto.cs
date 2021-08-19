using Pastelaria.Domain.Tarefa.Dto;
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
        private IList<TarefaDto> _tarefaDtos;
        //public UsuarioDto(int id, 
        //                    int codigoTipoUsuario, 
        //                    string email, 
        //                    string senha, 
        //                    string nome, 
        //                    DateTime? dataNascimento, 
        //                    string telefonefixo, 
        //                    string telefoneCelular, 
        //                    string logradouro, 
        //                    string bairro, 
        //                    string cidade, 
        //                    string uf, 
        //                    string cep, 
        //                    string foto)
        //{
        //    Id = id;
        //    CodigoTipoUsuario = codigoTipoUsuario;
        //    Email = email;
        //    Senha = senha;
        //    Nome = nome;
        //    DataNascimento = dataNascimento;
        //    Telefonefixo = telefonefixo;
        //    TelefoneCelular = telefoneCelular;
        //    Logradouro = logradouro;
        //    Bairro = bairro;
        //    Cidade = cidade;
        //    Uf = uf;
        //    Cep = cep;
        //    Foto = foto;
        //    _tarefaDtos = new List<TarefaDto>();
        //}

        public int Id { get; set; }
        public int CodigoTipoUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Telefonefixo { get; set; }
        public string TelefoneCelular { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
        public string Foto { get; set; }
        //public IReadOnlyCollection<TarefaDto> tarefa { get { return _tarefaDtos.ToArray(); } }

        //public void AddTarefa(TarefaDto tarefaDto)
        //{
        //    _tarefaDtos.Add(tarefaDto);
        //}
    }
}
