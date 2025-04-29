using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using schedule_mvc.Data;
using schedule_mvc.Models;

namespace schedule_mvc.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ScheduleDBContext _context;

        public ClientRepository(ScheduleDBContext context)
        {
            _context = context;
        }

        public bool Exists(Guid? id)
        {
            return _context.Client.Any(e => e.Id == id);
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Client?> GetByIdAsync(Guid? id)
        {
            return await _context.Client.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await _context.Client.ToListAsync();
        }


        public void Add(Client client)
        {
            _context.Client.Add(client);
        }
        public void Update(Client client)
        {
            _context.Update(client);
        }
        public void Delete(Client client)
        {
            _context.Remove(client);
        }

        public List<Client> GetAll()
        {
            return _context.Client.ToList();
        }

        public Client? GetById(Guid? id)
        {
            return _context.Client.FirstOrDefault(x => x.Id == id);
        }


        public int GetTotal()
        {
            return _context.Client.Count();
            //RAW SQL
            //return _context.Client.FromSqlRaw("SELECT * FROM Client").Count();
        }

        public IQueryable<Client> QueryLikeName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return _context.Client.Where(element => EF.Functions.Like(element.Name, $"%{name}%"));

                //RAW SQL
                //var parameter = new SqlParameter("comparison", $"%{name}%");

                
                //return _context.Client.FromSqlRaw("SELECT * FROM Client WHERE name LIKE @comparison", parameter);
            }

            var clients = from client in _context.Client select client;
            return clients;
        }
    }
}
