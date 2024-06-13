using IdentityWebApp.Models;
using IdentityWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace IdentityWebApp.Pages.Admin.Identities
{
    public class CreateModel : PageModel
    {
        private readonly IdentityService identityService;

        [BindProperty]
        public Identity Identity { get; set; }

        public CreateModel(IdentityService identityService)
        {
            this.identityService = identityService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await identityService.CreateIdentityAsync(Identity);

            return RedirectToPage("./Index");
        }
    }
}
