﻿using SosCivil.Mvc.Models.Auth;

namespace SosCivil.Mvc.Service.Interfaces
{
    public interface IAuthService
    {
        Task<UsuarioRespostaLogin> Login(UsuarioLoginViewModel userLogin);
        Task<UsuarioRespostaLogin> Registrar(UsuarioRegistroViewModel userRegistro);
    }
}
