using Microsoft.EntityFrameworkCore;
using Sistema.Detran.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Detran.Infra.Repositories.EF
{
    public class SistemaDetranRepository : IVeiculoRepository
    {
        private readonly SistemaDetranContext dbContext;

        public SistemaDetranRepository(SistemaDetranContext dbContext) => this.dbContext = dbContext;
        public void Add(Veiculo veiculo)
        {
            dbContext.Veiculos.Add(veiculo);
            dbContext.SaveChanges();
        }

        public void Delete(Veiculo veiculo)
        {
            dbContext.Veiculos.Remove(veiculo);
            dbContext.SaveChanges();
        }

        public IEnumerable<Veiculo> GetAll() => dbContext.Veiculos.ToListAsync().Result;

        //public Veiculo GetById(Guid Id) => dbContext.Veiculos.SingleOrDefaultAsync().Result;

        public Veiculo GetVeiculo(Guid id) => dbContext.Veiculos.SingleOrDefaultAsync().Result;

        public void Update(Veiculo veiculo)
        {
            dbContext.Entry(veiculo).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
