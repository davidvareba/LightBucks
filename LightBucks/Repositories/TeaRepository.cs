using LightBucks.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace LightBucks.Repositories
{
    public class TeaRepository : ITeaRepository
    {
        private readonly IConfiguration _config;

        public TeaRepository(IConfiguration config)
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
        public List<Tea> GetAllTea()
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
                                      FROM Tea
                                      ";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Tea> teas = new List<Tea>();
                    while (reader.Read())
                    {
                        Tea tea = new Tea
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Price = reader.GetInt32(reader.GetOrdinal("Price")),
                            Descriptions = reader.GetString(reader.GetOrdinal("Descriptions")),
                            ImgUrl = reader.GetString(reader.GetOrdinal("ImgUrl")),
                            UserId = reader.GetInt32(reader.GetOrdinal("UserId"))
                        };

                        teas.Add(tea);
                    }

                    reader.Close();

                    return teas;
                }
            }
        }

        public Tea GetTeaById(int id)
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
                                      FROM Tea WHERE Id = @id
                                      ";

                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Tea tea = new Tea
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Price = reader.GetInt32(reader.GetOrdinal("Price")),
                            Descriptions = reader.GetString(reader.GetOrdinal("Descriptions")),
                            ImgUrl = reader.GetString(reader.GetOrdinal("ImgUrl")),
                            UserId = reader.GetInt32(reader.GetOrdinal("UserId"))
                        };

                        reader.Close();
                        return tea;
                    }
                    else
                    {
                        reader.Close();
                        return null;
                    }
                }
            }
        }

        public List<Tea> GetTeasByUserId(int id)
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
                                      FROM Tea WHERE UserId = @id
                                      ";

                    cmd.Parameters.AddWithValue("id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Tea> teas = new List<Tea>();
                    while (reader.Read())
                    {
                        Tea listing = new Tea
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Price = reader.GetInt32(reader.GetOrdinal("Price")),
                            Descriptions = reader.GetString(reader.GetOrdinal("Descriptions")),
                            ImgUrl = reader.GetString(reader.GetOrdinal("ImgUrl")),
                            UserId = reader.GetInt32(reader.GetOrdinal("UserId"))
                        };
                        teas.Add(listing);

                    }
                    reader.Close();
                    return teas;
                }
            }
        }

        public void UpdateTea(Tea tea)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        Update Tea
                        SET
                            Name = @name
                            Price = @price
                            Descriptions = @description
                            ImgUrl = @imgUrl
                            UserId = @UserId
                        WHERE Id = @id";

                    cmd.Parameters.AddWithValue("@name", tea.Name);
                    cmd.Parameters.AddWithValue("@price", tea.Price);
                    cmd.Parameters.AddWithValue("@descriptions", tea.Descriptions);
                    cmd.Parameters.AddWithValue("@imgUrl", tea.ImgUrl);
                    cmd.Parameters.AddWithValue("@userId", tea.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteTea(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        DELETE FROM Tea
                        WHERE Id = @id
                        ";

                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void AddTea(Tea tea)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Tea 
                                                (Name,
                                                Price,
                                                Descriptions,
                                                ImgUrl,
                                                UserId)
                    OUTPUT Inserted.Id
                    VALUES (@name, @price, @description, @imgUrl, @userId)";

                    cmd.Parameters.AddWithValue("@name", tea.Name);
                    cmd.Parameters.AddWithValue("@price", tea.Price);
                    cmd.Parameters.AddWithValue("@descriptions", tea.Descriptions);
                    cmd.Parameters.AddWithValue("@userId", tea.UserId);

                    int id = (int)cmd.ExecuteScalar();

                    tea.Id = id;
                }
            }
        }

    }
}
