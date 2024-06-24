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

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public async Task<IActionResult> OnGet(int currentPage = 1)
        {
            HttpClient client = api.Initial();

            List<Identity> identities = null;

            const int pageSize = 100;
            int itemsPerPage = 9;
            CurrentPage = currentPage;

            HttpResponseMessage response = await client.GetAsync("https://localhost:44373/api/Identities");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                var allIdentities = JsonConvert.DeserializeObject<List<Identity>>(result);
                identities = allIdentities.Skip((CurrentPage - 1) * itemsPerPage).Take(itemsPerPage) .ToList();

                //TotalPages = (int)Math.Ceiling(identities.Count() / (double)pageSize);
                //TotalPages = (int)(allIdentities.Count() / itemsPerPage);
                TotalPages = (int)Math.Ceiling(allIdentities.Count / (double)itemsPerPage);
            }
          
            ViewData["identities"] = identities;
            return Page();
        }
    }
}
