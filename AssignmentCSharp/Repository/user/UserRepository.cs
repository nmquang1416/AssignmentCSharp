using System.Runtime.InteropServices.JavaScript;
using AssignmentCSharp.Entity;
using MySqlConnector;

namespace AssignmentCSharp.Repository;

public class UserRepository : iUserRepository
{
    public String MYSQL_CONNECTION_STRING;
    public UserEntity save(UserEntity userEntity)
    {
        try
        {
            MYSQL_CONNECTION_STRING = "server=127.0.0.1;uid="+userEntity.userName+";pwd="+ userEntity.userPassword +";database=springherobank";
            var connection = new MySqlConnection(MYSQL_CONNECTION_STRING);
            Console.WriteLine(MYSQL_CONNECTION_STRING);
            connection.Open();
            MySqlCommand command = new MySqlCommand(
                "insert into users (user_name, user_password, account_number, blance, transaction, first_name, last_name, email, phone, birth, is_admin, status) values (@user_name, @user_password, @account_number, @blance, @transaction, @first_name, @last_name, @email, @phone, @birth, @is_admin, @status)");
            command.Connection = connection;

            command.Parameters.AddWithValue("@user_name", userEntity.userName);
            command.Parameters.AddWithValue("@user_password", userEntity.userPassword);
            command.Parameters.AddWithValue("@account_number", userEntity.accountNumber);
            command.Parameters.AddWithValue("@blance", userEntity.blance);
            command.Parameters.AddWithValue("@transaction", userEntity.transaction);
            command.Parameters.AddWithValue("@first_name", userEntity.fisrtName);
            command.Parameters.AddWithValue("@last_name", userEntity.lastName);
            command.Parameters.AddWithValue("@email", userEntity.email);
            command.Parameters.AddWithValue("@phone", userEntity.userName);
            command.Parameters.AddWithValue("@birth", userEntity.birth);
            command.Parameters.AddWithValue("@is_admin", userEntity.isAdmin);
            command.Parameters.AddWithValue("@status", userEntity.status);

            command.ExecuteNonQuery();

            return userEntity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        // throw new NotImplementedException();
    }

    public void signUpUser(string account, string password)
    {
        try
        {
            var connection = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=springherobank");
            connection.Open();
            //create
            MySqlCommand command_create = new MySqlCommand("CREATE USER'" + account +"'@'%' IDENTIFIED BY '" + password +
                                                           "';\nGRANT SELECT, INSERT, UPDATE, DELETE, CREATE, DROP, FILE, INDEX, ALTER, CREATE TEMPORARY TABLES, CREATE VIEW, EVENT, TRIGGER, SHOW VIEW, CREATE ROUTINE, ALTER ROUTINE, EXECUTE ON *.* TO '"+ account +"'@'%';");
            command_create.Connection = connection;
            command_create.ExecuteNonQuery();
            Console.WriteLine("done");
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public string loginUser(string account, string password)
    {
        try
        {
            MYSQL_CONNECTION_STRING =
                "server=127.0.0.1;uid=" + account + ";pwd=" + password + ";database=springherobank";
            var connection = new MySqlConnection(MYSQL_CONNECTION_STRING);
            connection.Open();
            Console.WriteLine("log in success");
            connection.Close();
            return MYSQL_CONNECTION_STRING;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void sendMoney(double Monney, String MYSQL_CONNECTION_STRING)
    {
        try
        {
            UserEntity userEntity = new UserEntity();
            
            var connection = new MySqlConnection(MYSQL_CONNECTION_STRING);
            connection.Open();
            MySqlCommand command = new MySqlCommand("UPDATE users SET blance = @blance WHERE user_name = @account_number");
            command.Connection = connection;
            
            double amount = userEntity.blance + Monney;
            var result = command.Parameters.AddWithValue("@blance", amount);
            command.Parameters.AddWithValue("@user_name", userEntity.accountNumber);
            Console.WriteLine(command);
            
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public double transferMinus(double account01)
    {
        try
        {
            var connection = new MySqlConnection(MYSQL_CONNECTION_STRING);
            connection.Open();

            UserEntity userEntity = new UserEntity();
            var result = userEntity.blance - account01;
            connection.Close();
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        throw new NotImplementedException();
    }

    public double transferPlus(double account02)
    {
        try
        {
            var connection = new MySqlConnection(MYSQL_CONNECTION_STRING);
            connection.Open();

            var command = new MySqlCommand("select blance from users where status = 1 and account_number = @account_number");
            command.Connection = connection;
            UserEntity userEntity = new UserEntity();
            var result = userEntity.blance + account02;
            command.ExecuteReader();
            
            connection.Close();
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public double blanceQuerry(String account_number)
    {
        try
        {
            var connection = new MySqlConnection(MYSQL_CONNECTION_STRING);
            connection.Open();

            UserEntity userEntity = new UserEntity();
            var command = new MySqlCommand("select blance from users where status = 1 and account_number = @account_number");
            command.Connection = connection;
            
            command.Parameters.AddWithValue("@account_number", account_number);
            double balance = userEntity.blance;
            command.ExecuteReader();
            
            connection.Close();
            return balance;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        throw new NotImplementedException();
    }

    public UserEntity editInfomation(UserEntity userEntity)
    {
        try
        {
            var connection = new MySqlConnection(MYSQL_CONNECTION_STRING);
            connection.Open();

            var command = new MySqlCommand("update users set first_name = @first_name, last_name = @last_name, email = @email, phone = @phone, birth = @birth where account_number = @account_number");
            command.Connection = connection;
            command.Parameters.AddWithValue("@account_number", userEntity.accountNumber);
            command.ExecuteReader();
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        throw new NotImplementedException();
    }

    public UserEntity editPassword(UserEntity userEntity)
    {
        throw new NotImplementedException();
    }
}