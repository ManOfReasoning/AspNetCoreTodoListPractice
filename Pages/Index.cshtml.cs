using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TodoListBreeze.Areas.Identity.Data;

namespace TodoListBreeze.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<UserData> _userManager;
        private readonly SignInManager<UserData> _signInManager;

        public IndexModel(UserManager<UserData> userManager, SignInManager<UserData> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        public List<Mission> Notes { get; set; }

        [BindProperty]
        public Mission NewNote{ get; set; }
        private async Task LoadAsync(System.Security.Claims.ClaimsPrincipal User)
        {
            UserData user = await _userManager.GetUserAsync(User);
            Notes = JsonSerializer.Deserialize<List<Mission>>(user.UserTasks);
        }

        public async Task<IActionResult> OnGet()
        {
            if (_signInManager.IsSignedIn(User))
            {
                await LoadAsync(User);
            }
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                UserData user = await _userManager.GetUserAsync(User);
                List<Mission> notes = JsonSerializer.Deserialize<List<Mission>>(user.UserTasks);
                notes.Add(NewNote);
                user.UserTasks = JsonSerializer.Serialize<List<Mission>>(notes);
                await _userManager.UpdateAsync(user);
                return LocalRedirect("~/");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            UserData user = await _userManager.GetUserAsync(User);
            List<Mission> notes = JsonSerializer.Deserialize<List<Mission>>(user.UserTasks);
            if (notes.Count > 0)
            {
                notes.RemoveAt(id);
                user.UserTasks = JsonSerializer.Serialize<List<Mission>>(notes);
                await _userManager.UpdateAsync(user);
                return LocalRedirect("~/");
            }
            return Page();
        }
    }
}
