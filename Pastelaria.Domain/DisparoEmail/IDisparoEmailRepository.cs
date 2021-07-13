using Pastelaria.Domain.DisparoEmail.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastelaria.Domain.DisparoEmail
{
    public interface IDisparoEmailRepository
    {
        void Post(DisparoEmailDto disparoEmail);
        DisparoEmailDto GetDisparoEmailPorIdTarefa(int idTarefa);
    }
}
