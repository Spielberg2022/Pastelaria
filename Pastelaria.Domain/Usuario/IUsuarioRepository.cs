using Pastelaria.Domain.Usuario.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastelaria.Domain.Usuario
{
    public interface IUsuarioRepository
    {
        UsuarioDto GetLogin(string email, string senha);
        UsuarioDto GetUsuarioPorId(int idUsuario);
        void Post(UsuarioDto usuario);
        UsuarioDto GetUsuarioPorEmail(string email);
        void Delete(int id);
    }
}
