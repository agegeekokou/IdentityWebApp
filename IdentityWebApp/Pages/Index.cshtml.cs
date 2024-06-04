using IdentityWebApp.Helper;
using IdentityWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IdentityWebAPP.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;
        private readonly HttpClient client;
        private readonly IdentityWebAPI api = new IdentityWebAPI();

        public IndexModel(ILogger<IndexModel> logger, HttpClient client)
        {
            this.logger = logger;
            this.client = client;
        }

        public async Task<IActionResult> OnGet()
        {
            HttpClient client = api.Initial();

            List<Identity> identities = null;
           
            HttpResponseMessage response = await client.GetAsync("https://localhost:44373/api/Identities");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                identities = JsonConvert.DeserializeObject<List<Identity>>(result);
            }

            ViewData["identities"] = identities;
            return Page();
        }
    }
}
