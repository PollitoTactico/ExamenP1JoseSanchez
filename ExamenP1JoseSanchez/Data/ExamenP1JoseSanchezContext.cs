using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExamenP1JoseSanchez.Models;

namespace ExamenP1JoseSanchez.Data
{
    public class ExamenP1JoseSanchezContext : DbContext
    {
        public ExamenP1JoseSanchezContext (DbContextOptions<ExamenP1JoseSanchezContext> options)
            : base(options)
        {
        }

        public DbSet<ExamenP1JoseSanchez.Models.JSanchez> JSanchez { get; set; } = default!;
        public DbSet<ExamenP1JoseSanchez.Models.Carrera> Carrera { get; set; } = default!;
    }
}
