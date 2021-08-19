using Pastelaria.Domain.Usuario;
using Pastelaria.Domain.Usuario.Dto;
using ProjetoBanco.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace _5_Pastelaria.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Conexao _conexao;
        public UsuarioRepository(Conexao conexao)
        {
            _conexao = conexao;
        }

        private enum Procedures
        {
            PSP_SelUsuarioPorEmaileSenha,
            PSP_InsUsuario,
            PSP_SelUsuarioPorEmail,
            PSP_SelEmailUsuarioPorId,
            PSP_SelUsuarioPorId,
            PSP_DeleteUsuarioPorId
        }

        public UsuarioDto GetLogin(string email, string senha)
        {
            //var usuario = new UsuarioDto();
            _conexao.ExecuteProcedure(Procedures.PSP_SelUsuarioPorEmaileSenha);
            _conexao.AddParameter("@email", email);
            _conexao.AddParameter("@senha", senha);
            using (var r = _conexao.ExecuteReader())
            {
                if (r.Read())
                {
                    DateTime dataNascimento;
                    try
                    {
                        dataNascimento = Convert.ToDateTime(r["DataNascimento"].ToString());
                    }
                    catch (Exception)
                    {
                        dataNascimento = Convert.ToDateTime("1900-01-01");
                    }

                    return new UsuarioDto
                    {
                        Id = int.Parse(r["Id"].ToString()),
                        Nome = r["Nome"].ToString(),
                        Email = r["Email"].ToString(),
                        Senha = r["Senha"].ToString()
                    };
                }
            }
            return null;
        }

        public UsuarioDto GetUsuarioPorId(int idUsuario)
        {
            _conexao.ExecuteProcedure(Procedures.PSP_SelUsuarioPorId);
            _conexao.AddParameter("@Id", idUsuario);
            using (var r = _conexao.ExecuteReader())
            {
                if (r.Read())
                {
                    DateTime dataNascimento;
                    try
                    {
                        dataNascimento = Convert.ToDateTime(r["DataNascimento"].ToString());
                    }
                    catch (Exception)
                    {
                        dataNascimento = Convert.ToDateTime("1900-01-01");
                    }

                    return new UsuarioDto
                    {
                        Id = int.Parse(r["Id"].ToString()),
                        CodigoTipoUsuario = int.Parse(r["CodigoTipoUsuario"].ToString()),
                        Email = r["Email"].ToString(),
                        Senha = r["Senha"].ToString(),
                        Nome = r["Nome"].ToString(),
                        DataNascimento = dataNascimento,
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

        public void Post(UsuarioDto usuario)
        {
            _conexao.ExecuteProcedure(Procedures.PSP_InsUsuario);
            _conexao.AddParameter("@CodigoTipoUsuario", usuario.CodigoTipoUsuario);
            _conexao.AddParameter("@Email", usuario.Email);
            _conexao.AddParameter("@Senha", usuario.Senha);
            _conexao.AddParameter("@Nome", usuario.Nome);
            _conexao.AddParameter("@DataNascimento", usuario.DataNascimento);
            _conexao.AddParameter("@TelefoneFixo", usuario.Telefonefixo);
            _conexao.AddParameter("@TelefoneCelular", usuario.TelefoneCelular);
            _conexao.AddParameter("@Logradouro", usuario.Logradouro);
            _conexao.AddParameter("@Bairro", usuario.Bairro);
            _conexao.AddParameter("@Cidade", usuario.Cidade);
            _conexao.AddParameter("@Uf", usuario.Uf);
            _conexao.AddParameter("@Cep", usuario.Cep);
            _conexao.AddParameter("@Foto", usuario.Foto);
            _conexao.ExecuteNonQuery();
        }

        public UsuarioDto GetUsuarioPorEmail(string email)
        {
            _conexao.ExecuteProcedure(Procedures.PSP_SelUsuarioPorEmail);
            _conexao.AddParameter("@Email", email);

            using (var r = _conexao.ExecuteReader())
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

        public void Delete(int id)
        {
            _conexao.ExecuteProcedure(Procedures.PSP_DeleteUsuarioPorId);
            _conexao.AddParameter("@Id", id);
            _conexao.ExecuteNonQuery();
        }
    }
}
