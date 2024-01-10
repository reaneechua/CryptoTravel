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
    public class IndexModel : PageModel
    {
        private readonly CryptoTravel.Data.CryptoTravelContext _context;

        public IndexModel(CryptoTravel.Data.CryptoTravelContext context)
        {
            _context = context;
        }

        public IList<ConversionRate> ConversionRate { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ConversionRate = await _context.ConversionRate.ToListAsync();
        }
    }
}
