using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesTask
{
    class UsersRepository : IRepository<User>
    {
        private SqlConnectionManager sqlConnectionManager;

        public UsersRepository(SqlConnectionManager sqlConnectionManager)
        {
            this.sqlConnectionManager = sqlConnectionManager;
        }

        public User Add(User entity)
        {
            try
            {
                using (var connection = sqlConnectionManager.CreateSqlConnection())
                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "INSERT INTO users(name, last_name, email, user_role) " +
                        "VALUES(@name, @lastName, @email, @userRole)";
                    command.Parameters.AddWithValue("@name", entity.Name);
                    command.Parameters.AddWithValue("@lastName", entity.LastName);
                    command.Parameters.AddWithValue("@email", entity.Email);
                    command.Parameters.AddWithValue("@userRole", entity.UserRole.ToString());
                    command.ExecuteNonQuery();
                    return entity;
                }
            }
            catch (Exception e)
            {
                throw new DatabaseException($"Error adding user entity", e);
            }
        }

        public void Delete(long id)
        {
            try
            {
                using (var connection = sqlConnectionManager.CreateSqlConnection())
                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "DELETE FROM users WHERE id = @userId";
                    command.Parameters.AddWithValue("@userId", id);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw new DatabaseException($"Error deleting user with id {id}", e);
            }

        }

        public User Get(long id)
        {
            try
            {
                using (var connection = sqlConnectionManager.CreateSqlConnection())
                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "SELECT * FROM users WHERE id = @userId";
                    command.Parameters.AddWithValue("@userId", id);
                    SqlDataReader reader = null;
                    try
                    {
                        reader = command.ExecuteReader();
                        if (!reader.HasRows)
                        {
                            return null;
                        }

                        while (reader.Read())
                        {
                            return new User(
                                (long)reader["id"],
                                (string)reader["name"],
                                (string)reader["last_name"],
                                (string)reader["email"],
                                (UserRole)Enum.Parse(typeof(UserRole), (string)reader["user_role"]));
                        }

                        return null;
                    }
                    finally
                    {
                        if (reader != null)
                        {
                            reader.Close();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new DatabaseException($"Error geting user with id {id}", e);
            }
        }

        public List<User> GetAll()
        {
            try
            {
                List<User> allUsers = new List<User>();
                using (var connection = sqlConnectionManager.CreateSqlConnection())
                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "SELECT * FROM users";
                    SqlDataReader reader = null;
                    try
                    {
                        reader = command.ExecuteReader();
                        if (!reader.HasRows)
                        {
                            return new List<User>();
                        }

                        while (reader.Read())
                        {
                            allUsers.Add(new User(
                                (long)reader["id"],
                                (string)reader["name"],
                                (string)reader["last_name"],
                                (string)reader["email"],
                                (UserRole)Enum.Parse(typeof(UserRole), (string)reader["user_role"]))
                                );
                        }
                        return allUsers;
                    }
                    finally
                    {
                        if (reader != null)
                        {
                            reader.Close();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new DatabaseException($"Error getting all users", e);
            }
        }



        public User Update(long id, User entityToUpdate)
        {
            try
            {
                using (var connection = sqlConnectionManager.CreateSqlConnection())
                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText =
                        "UPDATE users SET " +
                        "name=@name, " +
                        "last_name = @lastName, " +
                        "email = @email, " +
                        "user_role = @userRole " +
                        "WHERE id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", entityToUpdate.Name);
                    command.Parameters.AddWithValue("@lastName", entityToUpdate.LastName);
                    command.Parameters.AddWithValue("@email", entityToUpdate.Email);
                    command.Parameters.AddWithValue("@userRole", entityToUpdate.UserRole.ToString());
                    command.ExecuteNonQuery();
                    return entityToUpdate;
                }
            }
            catch (Exception e)
            {
                throw new DatabaseException($"Error updating user with id {id}", e);
            }
        }
    }
}
