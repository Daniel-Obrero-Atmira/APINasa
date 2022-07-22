using APINasa.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINasa.Context
{
    public class ContextDB : DbContext, IContextDB
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {

        }
        public DbSet<Meteorito> TopsMeteoritos { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Meteorito>().ToTable("TopsMeteoritos");
        }
    }
}
