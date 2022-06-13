using LightBucks.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace LightBucks.Repositories
{
    public class SnackRepository:ISnackRepository
    {
        private readonly IConfiguration _config;

        public SnackRepository(IConfiguration config)
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
        public List<Snack> GetAllSnack()
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
                                      FROM Snack
                                      ";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Snack> snacks = new List<Snack>();
                    while (reader.Read())
                    {
                        Snack snack = new Snack
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Price = reader.GetInt32(reader.GetOrdinal("Price")),
                            Descriptions = reader.GetString(reader.GetOrdinal("Descriptions")),
                            ImgUrl = reader.GetString(reader.GetOrdinal("ImgUrl")),
                            UserId = reader.GetInt32(reader.GetOrdinal("UserId"))
                        };

                        snacks.Add(snack);
                    }

                    reader.Close();

                    return snacks;
                }
            }
        }

        public Snack GetSnackById(int id)
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
                                      FROM Snack WHERE Id = @id
                                      ";

                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Snack snack = new Snack
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Price = reader.GetInt32(reader.GetOrdinal("Price")),
                            Descriptions = reader.GetString(reader.GetOrdinal("Descriptions")),
                            ImgUrl = reader.GetString(reader.GetOrdinal("ImgUrl")),
                            UserId = reader.GetInt32(reader.GetOrdinal("UserId"))
                        };

                        reader.Close();
                        return snack;
                    }
                    else
                    {
                        reader.Close();
                        return null;
                    }
                }
            }
        }

        public List<Snack> GetSnackByUserId(int id)
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
                                      FROM  WHERE UserId = @id
                                      ";

                    cmd.Parameters.AddWithValue("id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Snack> snacks = new List<Snack>();
                    while (reader.Read())
                    {
                        Snack snack = new Snack
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Price = reader.GetInt32(reader.GetOrdinal("Price")),
                            Descriptions = reader.GetString(reader.GetOrdinal("Descriptions")),
                            ImgUrl = reader.GetString(reader.GetOrdinal("ImgUrl")),
                            UserId = reader.GetInt32(reader.GetOrdinal("UserId"))
                        };
                        snacks.Add(snack);

                    }
                    reader.Close();
                    return snacks;
                }
            }
        }

        public void UpdateSnack(Snack snack)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        Update Snack
                        SET
                            Name = @name
                            Price = @price
                            Descriptions = @description
                            ImgUrl = @imgUrl
                            UserId = @UserId
                        WHERE Id = @id";

                    cmd.Parameters.AddWithValue("@name", snack.Name);
                    cmd.Parameters.AddWithValue("@price", snack.Price);
                    cmd.Parameters.AddWithValue("@descriptions", snack.Descriptions);
                    cmd.Parameters.AddWithValue("@imgUrl", snack.ImgUrl);
                    cmd.Parameters.AddWithValue("@userId", snack.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteSnack(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        DELETE FROM Snack
                        WHERE Id = @id
                        ";

                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void AddSnack(Snack snack)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Snack 
                                                (Name,
                                                Price,
                                                Descriptions,
                                                ImgUrl,
                                                UserId)
                    OUTPUT Inserted.Id
                    VALUES (@name, @price, @description, @imgUrl, @userId)";

                    cmd.Parameters.AddWithValue("@name", snack.Name);
                    cmd.Parameters.AddWithValue("@price", snack.Price);
                    cmd.Parameters.AddWithValue("@descriptions", snack.Descriptions);
                    cmd.Parameters.AddWithValue("@userId", snack.UserId);

                    int id = (int)cmd.ExecuteScalar();

                    snack.Id = id;
                }
            }
        }

    }
}
