using Pastelaria.Domain.DisparoEmail.Dto;
using ProjetoBanco.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_Pastelaria.Repository.Repositories
{
    public class DisparoEmailRepository
    {
        private readonly Conexao conexao;

        public DisparoEmailRepository()
        {
            conexao = new Conexao();
        }

        private enum Procedures
        {
            PSP_InsDisparoEmail,
            PSP_SelDisparoEmailPorIdTarefa
        }

        public void Post(DisparoEmailDto disparoEmail)
        {
            conexao.ExecuteProcedure(Procedures.PSP_InsDisparoEmail);
            conexao.AddParameter("@IdTarefa", disparoEmail.IdTarefa);
            conexao.AddParameter("@IdUsuarioDestinatario", disparoEmail.IdUsuarioDestinatario);
            conexao.AddParameter("@CodigoTipoEmail", disparoEmail.CodigoTipoEmail);
            conexao.AddParameter("@Mensagem", disparoEmail.Mensagem);
            conexao.AddParameter("@Assunto", disparoEmail.Assunto);
            conexao.ExecuteNonQuery();
        }

        public DisparoEmailDto GetDisparoEmailPorIdTarefa(int idTarefa)
        {
            conexao.ExecuteProcedure(Procedures.PSP_SelDisparoEmailPorIdTarefa);
            conexao.AddParameter("@IdTarefa", idTarefa);
            using (var r = conexao.ExecuteReader())
            {
                if(r.Read())
                {
                    return new DisparoEmailDto
                    {
                        IdTarefa = int.Parse(r["IdTarefa"].ToString()),
                        IdUsuarioDestinatario = int.Parse(r["IdUsuarioDestinatario"].ToString()),
                        CodigoTipoEmail = int.Parse(r["CodigoTipoEmail"].ToString()),
                        Mensagem = r["Mensagem"].ToString(),
                        Assunto = r["Assunto"].ToString()
                    };
                }
            }
            return null;
        }
    }
}
