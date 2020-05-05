using Microsoft.EntityFrameworkCore;
using TalentMine.ItemBankService.Models;

namespace TalentMine.ItemBankService.Context
{
    /// <summary>
    /// Item Bank database Up and down
    /// </summary>
    public class ItemBankContext : DbContext
    {
        public ItemBankContext(DbContextOptions<ItemBankContext> options) : base(options)
        {
        }

        public DbSet<ItemBank> ItemBanks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemBank>().ToTable("ItemBank");
        }
    }
}
