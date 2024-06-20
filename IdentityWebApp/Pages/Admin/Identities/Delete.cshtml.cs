using IdentityWebApp.Models;
using IdentityWebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace IdentityWebApp.Pages.Admin.Identities
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly IdentityService identityService;

        [BindProperty]
        public Identity Identity { get; set; }

        public DeleteModel(IdentityService identityService)
        {
            this.identityService = identityService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Identity = await identityService.GetIdentityAsync(id); 
            if (Identity == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await identityService.DeleteIdentityAsync(id);
            return RedirectToPage("./Index");
        }
    }
}
