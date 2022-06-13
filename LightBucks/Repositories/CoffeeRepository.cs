using LightBucks.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace LightBucks.Repositories
{
   public class CoffeeRepository : ICoffeeRepository
    {
        private readonly IConfiguration _config;

        public CoffeeRepository(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }
        public List<Coffee> GetAllCoffee()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                      SELECT
                                      Id,
                                      Name,
                                      Price,
                                      Descriptions,
                                      ImgUrl,
                                      UserId
                                      FROM Coffee
                                      ";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Coffee> coffees = new List<Coffee>();
                    while (reader.Read())
                    {
                        Coffee coffee = new Coffee
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Price = reader.GetInt32(reader.GetOrdinal("Price")),
                            Descriptions = reader.GetString(reader.GetOrdinal("Descriptions")),
                            ImgUrl = reader.GetString(reader.GetOrdinal("ImgUrl")),
                            UserId = reader.GetInt32(reader.GetOrdinal("UserId"))
                        };

                        coffees.Add(coffee);
                    }

                    reader.Close();

                    return coffees;
                }
            }
        }

        public Coffee GetCoffeeById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                      SELECT
                                      Id,
                                      Name,
                                      Price,
                                      Descriptions,
                                      ImgUrl,
                                      UserId
                                      FROM Coffee WHERE Id = @id
                                      ";

                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Coffee coffee = new Coffee
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Price = reader.GetInt32(reader.GetOrdinal("Price")),
                            Descriptions = reader.GetString(reader.GetOrdinal("Descriptions")),
                            ImgUrl = reader.GetString(reader.GetOrdinal("ImgUrl")),
                            UserId = reader.GetInt32(reader.GetOrdinal("UserId"))
                        };

                        reader.Close();
                        return coffee;
                    }
                    else
                    {
                        reader.Close();
                        return null;
                    }
                }
            }
        }

        public List<Coffee> GetCoffeesByUserId(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                      SELECT
                                      Id,
                                      Name,
                                      Price,
                                      Descriptions,
                                      ImgUrl,
                                      UserId
                                      FROM Coffee WHERE UserId = @id
                                      ";

                    cmd.Parameters.AddWithValue("id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Coffee> coffees = new List<Coffee>();
                    while (reader.Read())
                    {
                        Coffee coffee = new Coffee
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Price = reader.GetInt32(reader.GetOrdinal("Price")),
                            Descriptions = reader.GetString(reader.GetOrdinal("Descriptions")),
                            ImgUrl = reader.GetString(reader.GetOrdinal("ImgUrl")),
                            UserId = reader.GetInt32(reader.GetOrdinal("UserId"))
                        };
                        coffees.Add(coffee);

                    }
                    reader.Close();
                    return coffees;
                }
            }
        }

        public void UpdateCoffee(Coffee coffee)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        Update Coffee
                        SET
                            Name = @name
                            Price = @price
                            Descriptions = @description
                            ImgUrl = @imgUrl
                            UserId = @UserId
                        WHERE Id = @id";

                    cmd.Parameters.AddWithValue("@name", coffee.Name);
                    cmd.Parameters.AddWithValue("@price", coffee.Price);
                    cmd.Parameters.AddWithValue("@descriptions", coffee.Descriptions);
                    cmd.Parameters.AddWithValue("@imgUrl", coffee.ImgUrl);
                    cmd.Parameters.AddWithValue("@userId", coffee.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCoffee(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        DELETE FROM Coffee
                        WHERE Id = @id
                        ";

                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void AddCoffee(Coffee coffee)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Coffee 
                                                (Name,
                                                Price,
                                                Descriptions,
                                                ImgUrl,
                                                UserId)
                    OUTPUT Inserted.Id
                    VALUES (@name, @price, @description, @imgUrl, @userId)";

                    cmd.Parameters.AddWithValue("@name", coffee.Name);
                    cmd.Parameters.AddWithValue("@price", coffee.Price);
                    cmd.Parameters.AddWithValue("@descriptions", coffee.Descriptions);
                    cmd.Parameters.AddWithValue("@userId", coffee.UserId);

                    int id = (int)cmd.ExecuteScalar();

                    coffee.Id = id;
                }
            }
        }

    }

}
