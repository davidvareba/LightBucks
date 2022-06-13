using LightBucks.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace LightBucks.Repositories
{
    public interface ITeaRepository
    {
        List<Tea> GetAllTea();
        Tea GetTeaById(int id);
        List<Tea> GetTeasByUserId(int id);
        public void AddTea(Tea tea);
        public void UpdateTea(Tea tea);
        public void DeleteTea(int id);
        
    }
}
