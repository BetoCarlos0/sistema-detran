using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Detran.Domain
{
    public interface IVeiculoRepository
    {
        IEnumerable<Veiculo> GetAll();
        Veiculo GetVeiculo(Guid id);
        void Add(Veiculo veiculo);
        void Update(Veiculo veiculo);
        void Delete(Veiculo veiculo);
    }
}
