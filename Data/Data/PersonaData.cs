using Data.Interfaz;
using Entity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.Data
{
    public class PersonaData : IPersonaData
    {
        private readonly EfectyContext DB;
        private const string Sp_Crud = "CRUD_Persona";
        public PersonaData(EfectyContext db)
        {
            DB = db;
        }
        private string sql = " @Accion, @Id, @Name, @LastName, @BirthDate, @ValueGain, @TipoDocumento, @EstadoCivil ";
        private SqlParameter[] SetParametros(Persona p , int accion)
        {
            SqlParameter para = new SqlParameter("@Accion", accion);
            SqlParameter param = new SqlParameter("@Id",p.Id);
            SqlParameter param2 = new SqlParameter("@Name", p.Name);
            SqlParameter param3 = new SqlParameter("@LastName", p.LastName);
            SqlParameter param4 = new SqlParameter("@BirthDate", p.BirthDate);
            SqlParameter param5 = new SqlParameter("@ValueGain", p.ValueGain);
            SqlParameter param6 = new SqlParameter("@TipoDocumento", p.TipoDocumento);
            SqlParameter param7 = new SqlParameter("@EstadoCivil", p.EstadoCivil);
            SqlParameter[] parames = new SqlParameter[] { para, param, param2, param3, param4 , param5, param6 , param7 };

            return parames;

        }
        public async Task<bool> Delete(int id)
        {
            SqlParameter para = new SqlParameter("@Accion", 4);
            SqlParameter param = new SqlParameter("@Id", id);
            SqlParameter[] parames = new SqlParameter[] { para, param };
            int result = await DB.Database.ExecuteSqlRawAsync(Sp_Crud + " @Accion, @Id", parames);
            return result == 1 ? true : false;
        }

        public async Task<Persona> Get(int id)
        {
            SqlParameter para = new SqlParameter("@Accion", 3);
            SqlParameter param = new SqlParameter("@Id", id);
            SqlParameter[] parames = new SqlParameter[] { para, param };
            var resulte = await DB.Personas.FromSqlRaw(Sp_Crud + " @Accion, @Id", parames).FirstOrDefaultAsync();
            return resulte;
        }

        public async Task<List<Persona>> GetAll()
        {
            SqlParameter para = new SqlParameter("@Accion", 2);
            SqlParameter[] parames = new SqlParameter[] { para };
            var resulte = await DB.Personas.FromSqlRaw(Sp_Crud + " @Accion ", parames).ToListAsync();
            return resulte;
        }

        public async Task<bool> Save(Persona persona)
        {
            var parameters = SetParametros(persona,1);
            var resulte = await DB.Database.ExecuteSqlRawAsync(Sp_Crud + sql, parameters);
            return resulte == 1 ? true : false;
        }
        public async Task<bool> Update(Persona persona)
        {
            var parameters = SetParametros(persona,5);
            var resulte = await DB.Database.ExecuteSqlRawAsync(Sp_Crud + sql, parameters);
            return resulte == 1 ? true : false;
        }
    }
}
