using Pastelaria.Domain.Usuario.Dto;
using ProjetoBanco.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace _5_Pastelaria.Repository
{
    public class UsuarioRepository
    {
        private readonly Conexao conexao;
        public UsuarioRepository()
        {
            conexao = new Conexao();

        }

        private enum Procedures
        {
            PSP_SelUsuarioPorEmaileSenha,
            PSP_InsUsuario
        }

        public UsuarioDto GetLogin(string email, string senha)
        {
            var usuario = new UsuarioDto();
            conexao.ExecuteProcedure(Procedures.PSP_SelUsuarioPorEmaileSenha);
            conexao.AddParameter("@email", email);
            conexao.AddParameter("@senha", senha);
            using (var r = conexao.ExecuteReader())
            {
                if (r.Read())
                {
                    usuario.Id = int.Parse(r["Id"].ToString());
                    usuario.Nome = r["Nome"].ToString();
                    usuario.Email = r["Email"].ToString();
                    usuario.Senha = r["Senha"].ToString();
                }
            }
            return usuario;
        }

        public void Post(UsuarioDto usuario)
        {
            conexao.ExecuteProcedure(Procedures.PSP_InsUsuario);
            conexao.AddParameter("@CodigoTipoUsuario", usuario.CodigoTipoUsuario);
            conexao.AddParameter("@Email", usuario.Email);
            conexao.AddParameter("@Senha", usuario.Senha);
            conexao.AddParameter("@Nome", usuario.Nome);
            conexao.AddParameter("@DataNascimento", usuario.DataNascimento);
            conexao.AddParameter("@TelefoneFixo", usuario.Telefonefixo);
            conexao.AddParameter("@TelefoneCelular", usuario.TelefoneCelular);
            conexao.AddParameter("@Logradouro", usuario.Logradouro);
            conexao.AddParameter("@Bairro", usuario.Bairro);
            conexao.AddParameter("@Cidade", usuario.Cidade);
            conexao.AddParameter("@Uf", usuario.Uf);
            conexao.AddParameter("@Cep", usuario.Cep);
            conexao.AddParameter("@Foto", usuario.Foto);
            conexao.ExecuteNonQuery();
        }
    }
}
