#nullable disable

using CrewLogApi.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace CrewLogApi.Areas.Identity.Pages.Account.Manage
{
    public class ChangeNameModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public ChangeNameModel(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound();

            Input = new InputModel
            {
                NewName = User.FindFirstValue("real_name")
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound();

            if (!ModelState.IsValid)
                return Page();

            var name = User.FindFirstValue("real_name");

            if (Input.NewName != name)
            {
                await _userManager.ReplaceClaimAsync(user, User.FindFirst("real_name"), new Claim("real_name", Input.NewName.Trim()));
                await _signInManager.RefreshSignInAsync(user);
                return RedirectToPage("./Index", new { state = "name-updated" });
            }

            return RedirectToPage("./Index");
        }

        public class InputModel
        {
            [Required]
            [Display(Name = "New Name")]
            public string NewName { get; set; }
        }
    }
}
