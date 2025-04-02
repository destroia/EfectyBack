using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaz
{
    public interface IPersonaBusiness
    {
        Task<List<Persona>> GetAll();
        Task<Persona> Get(int id);
        Task<bool> Save(Persona persona);
        Task<bool> Delete(int id);
        Task<bool> Update(Persona persona);
    }
}
