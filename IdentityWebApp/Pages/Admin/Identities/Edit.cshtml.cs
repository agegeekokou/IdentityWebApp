using IdentityWebApp.Models;
using IdentityWebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace IdentityWebApp.Pages.Admin.Identities
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly IdentityService identityService;

        [BindProperty]
        public Identity Identity { get; set; }

        public EditModel(IdentityService identityService)
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await identityService.UpdateIdentityAsync(id, Identity);

            return RedirectToPage("./Index");
        }
    }
}
