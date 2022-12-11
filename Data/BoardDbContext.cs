using BoardCalculator.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardCalculator.Data
{
    public class BoardDbContext : DbContext
    {
        public BoardDbContext(DbContextOptions options) : base(options)
        {
            
            
        }

        public DbSet<Project> Project { get; set; }
        public DbSet<CutByBoard> CutByBoard { get; set; }
        public DbSet<CutListByPiece> CutListByPiece { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<CommonSize> CommonSize { get; set; }
    }
}
