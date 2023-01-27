using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using WSConvertisseur.Models;

namespace ClientConvertisseurV1.Services
{
    public class WSService : IService
    {
        private System.Net.Http.HttpClient client;
        public WSService(string url) {
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Devise>> GetDevisesAsync(string nomControleur)
        {
            try
            {
                return await client.GetFromJsonAsync<List<Devise>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
