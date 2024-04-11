using WebLivrariaAT.Models;
using WebLivrariaAT.Repositorios.Interfaces;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebLivrariaAT.Repositorios
{
    public class LivroRepositorio : ILivroRepositorio
    {
        private readonly string apiUrl = "https://localhost:7125/api/Livro";


        public async Task<bool> ApagarLivro(int id)
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

        public async Task<LivroViewModel> AtualizarLivro(LivroViewModel livro, int id)
        {
            try
            {
                using (var cliente = new HttpClient())
                {
                    livro.ultimaatt = DateTime.Now.ToString();
                    string jsonObj = JsonConvert.SerializeObject(livro);
                    var content = new StringContent(jsonObj, Encoding.UTF8, "application/json");
                    var resp = await cliente.PutAsync(apiUrl + "/" + id, content);

                    if (resp.IsSuccessStatusCode)
                    {
                        var retorno = await resp.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<LivroViewModel>(retorno);
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


        public async Task<LivroViewModel> BuscarLivroPorId(int id)
        {

            LivroViewModel livro = new LivroViewModel();
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
                        livro = JsonConvert.DeserializeObject<LivroViewModel>(retorno.Result);
                    }
                }
            }
            catch (Exception) { throw; }
            return livro;
        }
        
        public async Task<List<LivroViewModel>> BuscarTodosLivros()
        {
            var livros = new List<LivroViewModel>();
            try
            {
                using (var cliente = new HttpClient())
                {
                    var resp = cliente.GetAsync(apiUrl).Result;
                    if (resp.IsSuccessStatusCode)
                    {
                        var retorno = resp.Content.ReadAsStringAsync();
                        livros = JsonConvert.DeserializeObject<List<LivroViewModel>>(retorno.Result);
                    }
                }
            }
            catch (Exception) { throw; }
            return livros;
        }

        public async Task<LivroViewModel> CriarLivro(LivroViewModel livro)
        {
            LivroViewModel livroCriado = new LivroViewModel();
            livroCriado = livro;
            livroCriado.ultimaatt = DateTime.Now.ToString();
            try
            {
                using (var cliente = new HttpClient())
                {
                    string jsonObj = JsonConvert.SerializeObject(livroCriado);
                    var content = new StringContent(jsonObj, Encoding.UTF8, "application/json");
                    var resp = cliente.PostAsync(apiUrl, content).Result;
                    //resp.Wait();
                    if (resp.IsSuccessStatusCode)
                    {
                        var retorno = resp.Content.ReadAsStringAsync();
                        livroCriado = JsonConvert.DeserializeObject<LivroViewModel>(retorno.Result);
                    }
                }
            } catch (Exception) { throw; }
            return livroCriado;
        }
    }
}
