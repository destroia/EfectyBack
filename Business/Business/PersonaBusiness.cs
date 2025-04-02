using Business.Interfaz;
using Data.Interfaz;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business
{
    public class PersonaBusiness : IPersonaBusiness
    {
        private readonly IPersonaData Repo;
        public PersonaBusiness(IPersonaData repo)
        {
            Repo = repo;
        }

        public async Task<bool> Delete(int id)
        {
            return await Repo.Delete(id);
        }

        public async Task<Persona> Get(int id)
        {
            return await Repo.Get(id);
        }

        public async Task<List<Persona>> GetAll()
        {
            return await Repo.GetAll();
        }

        public async Task<bool> Save(Persona persona)
        {
            return await Repo.Save(persona);
        }
        public async Task<bool> Update(Persona persona)
        {
            return await Repo.Update(persona);
        }
    }
}
