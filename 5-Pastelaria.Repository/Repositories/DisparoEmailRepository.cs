using Pastelaria.Domain.DisparoEmail;
using Pastelaria.Domain.DisparoEmail.Dto;
using ProjetoBanco.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_Pastelaria.Repository.Repositories
{
    public class DisparoEmailRepository : IDisparoEmailRepository
    {
        private readonly Conexao _conexao;

        public DisparoEmailRepository(Conexao conexao)
        {
            _conexao = conexao;
        }

        private enum Procedures
        {
            PSP_InsDisparoEmail,
            PSP_SelDisparoEmailPorIdTarefa,
            PSP_SelTarefaPorId
        }

        public void Post(DisparoEmailDto disparoEmail)
        {
            _conexao.ExecuteProcedure(Procedures.PSP_InsDisparoEmail);
            _conexao.AddParameter("@IdTarefa", disparoEmail.IdTarefa);
            _conexao.AddParameter("@IdUsuarioDestinatario", disparoEmail.IdUsuarioDestinatario);
            _conexao.AddParameter("@CodigoTipoEmail", disparoEmail.CodigoTipoEmail);
            _conexao.AddParameter("@Mensagem", disparoEmail.Mensagem);
            _conexao.AddParameter("@Assunto", disparoEmail.Assunto);
            _conexao.AddParameter("@Email", disparoEmail.Email);
            _conexao.ExecuteNonQuery();
        }

        public DisparoEmailDto GetDisparoEmailPorIdTarefa(int idTarefa)
        {
            _conexao.ExecuteProcedure(Procedures.PSP_SelDisparoEmailPorIdTarefa);
            _conexao.AddParameter("@IdTarefa", idTarefa);
            using (var r = _conexao.ExecuteReader())
            {
                if (r.Read())
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
