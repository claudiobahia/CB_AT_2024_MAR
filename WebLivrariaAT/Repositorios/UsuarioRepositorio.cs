using WebLivrariaAT.Models;
using WebLivrariaAT.Repositorios.Interfaces;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebLivrariaAT.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly string apiUrl = "https://localhost:7125/api/Usuario";


        public async Task<bool> ApagarUsuario(int id)
        {
            try
            {
                using (var cliente = new HttpClient())
                {
                    var resp = await cliente.DeleteAsync(apiUrl + "/" + id);
                    if (resp.IsSuccessStatusCode)
                    {
                        var retorno = await resp.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<bool>(retorno);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public async Task<UsuarioViewModel> AtualizarUsuario(UsuarioViewModel usuario, int id)
        {
            try
            {
                using (var cliente = new HttpClient())
                {
                    string jsonObj = JsonConvert.SerializeObject(usuario);
                    var content = new StringContent(jsonObj, Encoding.UTF8, "application/json");
                    var resp = await cliente.PutAsync(apiUrl + "/" + id, content);

                    if (resp.IsSuccessStatusCode)
                    {
                        var retorno = await resp.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<UsuarioViewModel>(retorno);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<UsuarioViewModel> BuscarUsuarioPorId(int id)
        {

            UsuarioViewModel usuario = new UsuarioViewModel();
            try
            {
                using (var cliente = new HttpClient())
                {
                    string jsonObj = JsonConvert.SerializeObject(id);
                    var content = new StringContent(jsonObj, Encoding.UTF8, "application/json");
                    var resp = cliente.GetAsync(apiUrl+"/"+id).Result;
                    if (resp.IsSuccessStatusCode)
                    {
                        var retorno = resp.Content.ReadAsStringAsync();
                        usuario = JsonConvert.DeserializeObject<UsuarioViewModel>(retorno.Result);
                    }
                }
            }
            catch (Exception) { throw; }
            return usuario;
        }
        
        public async Task<List<UsuarioViewModel>> BuscarTodosUsuarios()
        {
            var usuarios = new List<UsuarioViewModel>();
            try
            {
                using (var cliente = new HttpClient())
                {
                    var resp = cliente.GetAsync(apiUrl).Result;
                    if (resp.IsSuccessStatusCode)
                    {
                        var retorno = resp.Content.ReadAsStringAsync();
                        usuarios = JsonConvert.DeserializeObject<List<UsuarioViewModel>>(retorno.Result);
                    }
                }
            }
            catch (Exception) { throw; }
            return usuarios;
        }

        public async Task<UsuarioViewModel> CriarUsuario(UsuarioViewModel usuario)
        {
            UsuarioViewModel usuarioCriado = new UsuarioViewModel();
            usuarioCriado = usuario;
            usuarioCriado.favoritos = new List<string>(["4"]);
            try
            {
                using (var cliente = new HttpClient())
                {
                    string jsonObj = JsonConvert.SerializeObject(usuarioCriado);
                    var content = new StringContent(jsonObj, Encoding.UTF8, "application/json");
                    var resp = cliente.PostAsync(apiUrl, content).Result;
                    //resp.Wait();
                    if (resp.IsSuccessStatusCode)
                    {
                        var retorno = resp.Content.ReadAsStringAsync();
                        usuarioCriado = JsonConvert.DeserializeObject<UsuarioViewModel>(retorno.Result);
                    }
                }
            } catch (Exception) { throw; }
            return usuarioCriado;
        }
    }
}
