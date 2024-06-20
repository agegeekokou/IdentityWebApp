using IdentityWebApp.Models;
using IdentityWebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace IdentityWebApp.Pages.Admin.Identities
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly IdentityService identityService;

        public DetailsModel(IdentityService identityService)
        {
            this.identityService = identityService;
        }

        public Identity Identity { get; set; }

        public async Task OnGetAsync(int id)
        {
            Identity = await identityService.GetIdentityAsync(id);
        }
    }
}
