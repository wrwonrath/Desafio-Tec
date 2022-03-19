using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.DataStore.InMemory
{
    public class CardContext : DbContext
    {
        public CardContext(DbContextOptions<CardContext> options)
            : base(options)
        {

        }
        public DbSet<Card> Cards { get; set; }
    }
}
