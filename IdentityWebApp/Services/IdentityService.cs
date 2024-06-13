using IdentityWebApp.Helper;
using IdentityWebApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWebApp.Services
{
    public class IdentityService
    {
        private readonly HttpClient client;

        public IdentityService(IdentityWebAPI api)
        {
            //this.client = api.Client;
            this.client = api.Initial();
        }

        public async Task<List<Identity>> GetIdentitiesAsync()
        {
            HttpResponseMessage response = await client.GetAsync("/api/Identities");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Identity>>(json);
            }
            return null;
        }

        public async Task<Identity> GetIdentityAsync(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"/api/Identities/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Identity>(json);
            }
            return null;
        }

        public async Task CreateIdentityAsync(Identity identity)
        {
            var json = JsonConvert.SerializeObject(identity);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PostAsync("/api/Identities", content);
        }

        public async Task UpdateIdentityAsync(int id, Identity identity)
        {
            var json = JsonConvert.SerializeObject(identity);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PutAsync($"/api/Identities/{id}", content);
        }

        public async Task DeleteIdentityAsync(int id)
        {
            var response = await client.DeleteAsync($"/api/Identities/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}

