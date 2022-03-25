using Sistema.Detran.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Detran.Infra.Repositories
{
    public class InMemoryRepository : IVeiculoRepository
    {
        private readonly IList<Veiculo> entities = new List<Veiculo>();
        public void Add(Veiculo veiculo)
        {
            entities.Add(veiculo);
        }

        public void Delete(Veiculo veiculo)
        {
            entities.Remove(veiculo);
        }

        public IEnumerable<Veiculo> GetAll()
        {
            return entities.ToList();
        }

        public Veiculo GetVeiculo(Guid id)
        {
            return entities.SingleOrDefault(e => e.Id == id);
        }

        public void Update(Veiculo veiculo)
        {
            entities.Remove(GetVeiculo(veiculo.Id));
            entities.Add(veiculo);
        }
    }
}
