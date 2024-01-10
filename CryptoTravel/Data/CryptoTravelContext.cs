using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CryptoTravel.Models;

namespace CryptoTravel.Data
{
    public class CryptoTravelContext : DbContext
    {
        public CryptoTravelContext (DbContextOptions<CryptoTravelContext> options)
            : base(options)
        {
        }

        public DbSet<CryptoTravel.Models.Wallet> Wallet { get; set; } = default!;
        public DbSet<CryptoTravel.Models.ConversionRate> ConversionRate { get; set; } = default!;
    }
}
