namespace FIT5032_WebApplication.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RecipeModel : DbContext
    {
        public RecipeModel()
            : base("name=RecipeModel")
        {
        }

        public virtual DbSet<Recipe> Recipes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>()
                .Property(e => e.Path)
                .IsUnicode(false);

            modelBuilder.Entity<Recipe>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
