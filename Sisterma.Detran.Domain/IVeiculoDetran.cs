using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Detran.Domain
{
    public interface IVeiculoDetran
    {
        public Task AgendaVistoria(Guid id);
    }
}
