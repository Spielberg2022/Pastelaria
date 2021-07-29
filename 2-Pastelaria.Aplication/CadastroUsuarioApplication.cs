using _4_Pastelaria.Api.Controllers;
using _5_Pastelaria.Repository;
using _6_Pastelaria.Services;
using Pastelaria.Domain.Usuario;
using Pastelaria.Domain.Usuario.Dto;
using Pastelaria.Domain.Usuario.Services;
using ProjetoBanco.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Pastelaria.Aplication
{
    public class CadastroUsuarioApplication
    {
        UsuarioDto usuarioDto;
        private readonly Conexao conexao;

        public CadastroUsuarioApplication(string tipoUsuario, string email, string senha, string nome,
            string dataNascimento, string telefoneFixo, string telefoneCelular, string logradouro, string bairro, string cidade,
            string uf, string cep, string foto)
        {
            if (string.IsNullOrEmpty(dataNascimento))
                dataNascimento = "1753-01-01";
            usuarioDto = new UsuarioDto
            {
                CodigoTipoUsuario = int.Parse(tipoUsuario),
                Email = email,
                Senha = senha,
                Nome = nome,
                DataNascimento = DateTime.Parse(dataNascimento),
                Telefonefixo = telefoneFixo,
                TelefoneCelular = telefoneCelular,
                Logradouro = logradouro,
                Bairro = bairro,
                Cidade = cidade,
                Uf = uf,
                Cep = cep,
                Foto = foto
            };

            IUsuarioRepository usuarioRepository = new UsuarioRepository(conexao);
            usuarioRepository.Post(usuarioDto);
            //IUsuarioService usuarioService = new UsuarioService(usuarioRepository);
        }
    }
}
