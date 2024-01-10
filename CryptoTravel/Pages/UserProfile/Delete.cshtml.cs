using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CryptoTravel.Data;
using CryptoTravel.Models;

namespace CryptoTravel.Pages.UserProfile
{
    public class DeleteModel : PageModel
    {
        private readonly CryptoTravel.Data.CryptoTravelContext _context;

        public DeleteModel(CryptoTravel.Data.CryptoTravelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Wallet Wallet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wallet = await _context.Wallet.FirstOrDefaultAsync(m => m.Id == id);

            if (wallet == null)
            {
                return NotFound();
            }
            else
            {
                Wallet = wallet;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wallet = await _context.Wallet.FindAsync(id);
            if (wallet != null)
            {
                Wallet = wallet;
                _context.Wallet.Remove(Wallet);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
