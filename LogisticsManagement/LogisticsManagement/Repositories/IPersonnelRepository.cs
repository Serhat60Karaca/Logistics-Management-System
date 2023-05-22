using LogisticsManagement.Models;

namespace LogisticsManagement.Repositories
{
    public interface IPersonnelRepository
    {
        IQueryable<Personnel> Personnels { get; }  // reading data
        Personnel GetById(int id);
        void CreatePersonnel(Personnel personnel);
        void UpdatePersonnel(Personnel personnel);
        void DeletePersonnel(int id);

    }
}
