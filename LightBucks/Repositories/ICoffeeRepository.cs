using LightBucks.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
namespace LightBucks.Repositories
{
    public interface ICoffeeRepository
    {
        List<Coffee> GetAllCoffee();
        Coffee GetCoffeeById(int id);
        List<Coffee> GetCoffeesByUserId(int id);
        public void AddCoffee(Coffee coffee);
        public void UpdateCoffee(Coffee coffee);
        public void DeleteCoffee(int id);
    }
}
