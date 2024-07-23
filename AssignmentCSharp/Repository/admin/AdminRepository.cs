using System.Collections;
using System.Data;
using System.Runtime.InteropServices.JavaScript;
using AssignmentCSharp.Entity;
using MySqlConnector;

namespace AssignmentCSharp.Repository.admin;

public class AdminRepository : iAdminRepository
{
    public String MYSQL_CONNECTION_STRING;
    
    public string loginAdmin(String account, String password)
    {
        MYSQL_CONNECTION_STRING = "server=127.0.0.1;uid=" + account + ";pwd=" + password + ";database=springherobank";
        var connection = new MySqlConnection(MYSQL_CONNECTION_STRING);
        connection.Open();
        Console.WriteLine("log in success");
        connection.Close();
        return MYSQL_CONNECTION_STRING;
        throw new NotImplementedException();
    }
    
    public void signupAdmin(String connectToDB, String account, String password)
    {
        try
        {
            var connection = new MySqlConnection(connectToDB);
            Console.WriteLine(connectToDB);
            connection.Open();
            //create
            MySqlCommand command_create = new MySqlCommand("CREATE USER'" + account +"'@'%' IDENTIFIED BY '" + password +
                                                           "';\nGRANT ALL PRIVILEGES ON * . * TO '" + account + "'@'%';");
            command_create.Connection = connection;
            Console.WriteLine(account);
            Console.WriteLine(password);
            Console.WriteLine(command_create);
            command_create.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<AdminEntity> findAll()
    {
        var adminList = new List<AdminEntity>();
        try
        {
            var connection = new MySqlConnection(MYSQL_CONNECTION_STRING);
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from admins where status=1");
            command.Connection = connection;

            using MySqlDataReader dataReader = command.ExecuteReader();
            
            while (dataReader.HasRows)
            {
                dataReader.Read();
                AdminEntity adminEntity = new AdminEntity();
                adminEntity.adminId = dataReader.GetInt64("admin_id");
                adminEntity.adminName = dataReader.GetString("admin_name");
                adminEntity.fisrtName = dataReader.GetString("first_name");
                adminEntity.lastName = dataReader.GetString("last_name");
                adminEntity.email = dataReader.GetString("email");
                adminEntity.phone = dataReader.GetString("phone");
                adminEntity.birth = dataReader.GetString("birth");
                adminEntity.status = dataReader.GetInt32("status");

                adminList.Add(adminEntity);
            }

            Console.WriteLine("done!");
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return adminList;
        throw new NotImplementedException();
    }

    public AdminEntity findById(long id) //find account
    {
        throw new NotImplementedException();
    }

    public AdminEntity save(AdminEntity adminEntity) //create new account
    {
        try
        {
            MYSQL_CONNECTION_STRING = "server=127.0.0.1;uid=root;pwd=;database=springherobank";
            var connection = new MySqlConnection(MYSQL_CONNECTION_STRING);
            connection.Open();
            //insert
            MySqlCommand command_insert = new MySqlCommand(
                "insert into admins (admin_name, admin_password, first_name, last_name, email, phone, birth, transaction, is_admin, status) values (@admin_name, @admin_password, @first_name, @last_name, @email, @phone, @birth, @transaction, @is_admin, @status)");
            
            command_insert.Connection = connection;
            command_insert.Parameters.AddWithValue("@admin_name", adminEntity.adminName);
            command_insert.Parameters.AddWithValue("@admin_password", adminEntity.adminPassword);
            command_insert.Parameters.AddWithValue("@first_name", adminEntity.fisrtName);
            command_insert.Parameters.AddWithValue("@last_name", adminEntity.lastName);
            command_insert.Parameters.AddWithValue("@email", adminEntity.email);
            command_insert.Parameters.AddWithValue("@phone", adminEntity.phone);
            command_insert.Parameters.AddWithValue("@birth", adminEntity.birth);
            command_insert.Parameters.AddWithValue("@transaction", adminEntity.transaction);
            command_insert.Parameters.AddWithValue("@is_admin", adminEntity.isAdmin);
            command_insert.Parameters.AddWithValue("@status", adminEntity.status);
            command_insert.ExecuteNonQuery();
            
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return adminEntity;
        throw new NotImplementedException();
    }

    public AdminEntity update(AdminEntity adminEntity) //update account
    {
        throw new NotImplementedException();
    }

    public void delete(long id) 
    {
        throw new NotImplementedException();
    }
}