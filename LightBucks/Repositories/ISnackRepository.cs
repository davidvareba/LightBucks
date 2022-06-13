using LightBucks.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace LightBucks.Repositories
{
    public interface ISnackRepository
    {
        List<Snack> GetAllSnack();
        Snack GetSnackById(int id);
        List<Snack> GetSnackByUserId(int id);
        public void AddSnack(Snack snack);
        public void UpdateSnack(Snack snack);
        public void DeleteSnack(int id);
    }
}
