﻿using AppRpgEtec.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace AppRpgEtec.Services.Usuarios
{
    public class UsuarioService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "https://bsite.net/luizfernando987/Usuarios";
        //xyz --> Site da sua API

        public UsuarioService()
        {
            _request = new Request();
        }

        private string _token;
        public UsuarioService(string token)
        {
            _request = new Request();
            _token = token;
        }

        public async Task<Usuario> PostRegistrarUsuarioAsync(Usuario u)
        {
            //Registrar: Rota para o método na API que registrar o usuário
            string urlComplementar = "/Registrar";
            u.Id = await _request.PostReturnIntAsync(apiUrlBase + urlComplementar, u);
            return u;
        }
        public async Task<Usuario> PostAutenticarUsuarioAsync(Usuario u)
        {
            //Autenticar: Rota para o método na API que autentica com login e senha
            string urlComplementar = "/Autenticar";
            u = await _request.PostAsync(apiUrlBase + urlComplementar, u, string.Empty);
            return u;
        }

        public async Task<ObservableCollection<Usuario>> GetUsuariosAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");
            ObservableCollection<Models.Usuario> listaUsuarios = await
                _request.GetAsync<ObservableCollection<Models.Usuario>>(apiUrlBase + urlComplementar, _token);
            return listaUsuarios;
        }
        
        public async Task<int> PutAtualizarLocalizacaoAsync(Usuario u)
        {
            string urlComplementar = "/AtualizarLocalizacao";
            var result = await _request.PutAsync(apiUrlBase + urlComplementar, u, _token);
            return result;
        }

    }
}
