using LogisticsManagement.Models;

namespace LogisticsManagement.Repositories
{
    public class PersonnelRepository : IPersonnelRepository
    {
        private ApplicationDbContext _context;

        public PersonnelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Personnel> Personnels => _context.Personnels;
        public Personnel GetById(int id)
        {
            return _context.Personnels.FirstOrDefault(i => i.Id == id);
        }

        public void CreatePersonnel(Personnel personnel)
        {
            _context.Personnels.Add(personnel);
            _context.SaveChanges();
        }
        public void UpdatePersonnel(Personnel personnel)
        {
            _context.Personnels.Update(personnel);
            _context.SaveChanges();
        }

        public void DeletePersonnel(int id)
        {
            var personnel = GetById(id);

            if (personnel != null)
            {
                _context.Personnels.Remove(personnel);
                _context.SaveChanges();
            }
        }

    }
}
