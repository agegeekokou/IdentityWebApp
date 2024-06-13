using IdentityWebApp.Models;
using IdentityWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityWebApp.Pages.Admin.Identities
{
    public class IndexModel : PageModel
    {
        private readonly IdentityService identityService;

        public IndexModel(IdentityService identityService)
        {
            this.identityService = identityService;
        }

        public IList<Identity> Identities { get; set; }

        public async Task OnGetAsync()
        {
            Identities = await identityService.GetIdentitiesAsync();
        }
    }
}
