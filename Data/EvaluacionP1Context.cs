using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EvaluacionP1.Models;

namespace EvaluacionP1.Data
{
    public class EvaluacionP1Context : DbContext
    {
        public EvaluacionP1Context (DbContextOptions<EvaluacionP1Context> options)
            : base(options)
        {
        }

        public DbSet<EvaluacionP1.Models.MBaquero> MBaquero { get; set; } = default!;
        public DbSet<EvaluacionP1.Models.Carrera> Carrera { get; set; } = default!;
    }
}
