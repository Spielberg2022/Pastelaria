using Pastelaria.Domain.DisparoEmail.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Pastelaria.Services
{
    public interface IDisparoEmailService
    {
        string Post(DisparoEmailDto disparoEmailDto);
    }
}
