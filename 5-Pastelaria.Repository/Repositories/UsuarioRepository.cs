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
            PSP_InsUsuario,
            PSP_SelUsuarioPorEmail
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

        public UsuarioDto GetUsuarioPorEmail(string Email)
        {
            conexao.ExecuteProcedure(Procedures.PSP_SelUsuarioPorEmail);
            conexao.AddParameter("@Email", Email);
            using (var r = conexao.ExecuteReader())
            {
                if (r.Read() )
                {
                    return new UsuarioDto
                    {
                        Id = int.Parse(r["Id"].ToString()),
                        CodigoTipoUsuario = int.Parse(r["CodigoTipoUsuario"].ToString()),
                        Email = r["Email"].ToString(),
                        Senha = r["Senha"].ToString(),
                        Nome = r["Nome"].ToString(),
                        DataNascimento = DateTime.Parse(r["DataNascimento"].ToString()),
                        Telefonefixo = r["TelefoneFixo"].ToString(),
                        TelefoneCelular = r["TelefoneCelular"].ToString(),
                        Logradouro = r["Logradouro"].ToString(),
                        Bairro = r["Bairro"].ToString(),
                        Cidade = r["Cidade"].ToString(),
                        Uf = r["Uf"].ToString(),
                        Cep = r["Cep"].ToString(),
                        Foto = r["Foto"].ToString()
                    };
                }
            }
            return null;
        }
    }
}
