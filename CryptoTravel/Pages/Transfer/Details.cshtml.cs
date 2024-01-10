using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CryptoTravel.Data;
using CryptoTravel.Models;

namespace CryptoTravel.Pages.Transfer
{
    public class DetailsModel : PageModel
    {
        private readonly CryptoTravel.Data.CryptoTravelContext _context;

        public DetailsModel(CryptoTravel.Data.CryptoTravelContext context)
        {
            _context = context;
        }

        public ConversionRate ConversionRate { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conversionrate = await _context.ConversionRate.FirstOrDefaultAsync(m => m.Id == id);
            if (conversionrate == null)
            {
                return NotFound();
            }
            else
            {
                ConversionRate = conversionrate;
            }
            return Page();
        }
    }
}
