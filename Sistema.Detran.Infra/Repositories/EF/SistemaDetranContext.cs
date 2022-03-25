using Microsoft.EntityFrameworkCore;
using Sistema.Detran.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Detran.Infra.Repositories.EF
{
    public class SistemaDetranContext : DbContext
    {
        public SistemaDetranContext(DbContextOptions<SistemaDetranContext> options) : base(options)
        { }

        public DbSet<Veiculo> Veiculos { get; set; }
    }
}
