using WebLivrariaAT.Models;
using WebLivrariaAT.Repositorios.Interfaces;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebLivrariaAT.Repositorios
{
    public class CapituloRepositorio : ICapituloRepositorio
    {
        private readonly string apiUrl = "https://localhost:7125/api/Capitulo";


        public async Task<bool> ApagarCapitulo(int id)
        {
            CapituloViewModel capituloPorId = await BuscarCapituloPorId(id);
            if (capituloPorId == null)
            {
                throw new Exception($"Capitulo para ID: {id} não foi encontrado");
            }
            //.Capitulos.Remove(capituloPorId);
           // await _dbContex.SaveChangesAsync();
            return true;
        }
        
        public async Task<CapituloViewModel> AtualizarCapitulo(CapituloViewModel capitulo, int id)
        {
            CapituloViewModel capituloCriado = new CapituloViewModel();
            capituloCriado = capitulo;
            try
            {
                using (var cliente = new HttpClient())
                {
                    string jsonObj = JsonConvert.SerializeObject(capituloCriado);
                    var content = new StringContent(jsonObj, Encoding.UTF8, "application/json");
                    var resp = cliente.PostAsync(apiUrl, content).Result;
                    //resp.Wait();
                    if (resp.IsSuccessStatusCode)
                    {
                        var retorno = resp.Content.ReadAsStringAsync();
                        capituloCriado = JsonConvert.DeserializeObject<CapituloViewModel>(retorno.Result);
                    }
                }
            }
            catch (Exception) { throw; }
            return capituloCriado;
        }
        
        public async Task<CapituloViewModel> BuscarCapituloPorId(int id)
        {

            CapituloViewModel capitulo = new CapituloViewModel();
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
                        capitulo = JsonConvert.DeserializeObject<CapituloViewModel>(retorno.Result);
                    }
                }
            }
            catch (Exception) { throw; }
            return capitulo;
        }
        
        public async Task<List<CapituloViewModel>> BuscarTodosCapitulos()
        {
            var capitulos = new List<CapituloViewModel>();
            try
            {
                using (var cliente = new HttpClient())
                {
                    var resp = cliente.GetAsync(apiUrl).Result;
                    if (resp.IsSuccessStatusCode)
                    {
                        var retorno = resp.Content.ReadAsStringAsync();
                        capitulos = JsonConvert.DeserializeObject<List<CapituloViewModel>>(retorno.Result);
                    }
                }
            }
            catch (Exception) { throw; }
            return capitulos;
        }

        public async Task<List<CapituloViewModel>> BuscarTodosCapitulosDeLivro(int livroid)
        {
            var capitulos = new List<CapituloViewModel>();
            try
            {
                using (var cliente = new HttpClient())
                {
                    var resp = cliente.GetAsync(apiUrl + "/" + livroid).Result;
                    if (resp.IsSuccessStatusCode)
                    {
                        var retorno = await resp.Content.ReadAsStringAsync();
                        capitulos = JsonConvert.DeserializeObject<List<CapituloViewModel>>(retorno);
                    }
                }
            }
            catch (Exception) { throw; }
            return capitulos;
        }


        public async Task<CapituloViewModel> CriarCapitulo(CapituloViewModel capitulo)
        {
            CapituloViewModel capituloCriado = new CapituloViewModel();
            capituloCriado = capitulo;
            try
            {
                using (var cliente = new HttpClient())
                {
                    string jsonObj = JsonConvert.SerializeObject(capituloCriado);
                    var content = new StringContent(jsonObj, Encoding.UTF8, "application/json");
                    var resp = cliente.PostAsync(apiUrl, content).Result;
                    //resp.Wait();
                    if (resp.IsSuccessStatusCode)
                    {
                        var retorno = resp.Content.ReadAsStringAsync();
                        capituloCriado = JsonConvert.DeserializeObject<CapituloViewModel>(retorno.Result);
                    }
                }
            } catch (Exception) { throw; }
            return capituloCriado;
        }
    }
}
