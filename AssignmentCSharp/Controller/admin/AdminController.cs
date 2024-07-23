using System.ComponentModel;
using System.Runtime.InteropServices.JavaScript;
using AssignmentCSharp.Entity;
using AssignmentCSharp.Repository.admin;
using MySqlConnector.Logging;

namespace AssignmentCSharp.Controller.admin;

public class AdminController
{
     public String loginAdmin()
     {
          AdminRepository _adminRepository = new AdminRepository();
          Console.WriteLine("Account: ");
          var account = Console.ReadLine();
          Console.WriteLine("password: ");
          var password = Console.ReadLine();
          
          return _adminRepository.loginAdmin(account, password);
     }
     
     public void createAdmin()
     {
          AdminEntity adminEntity = new AdminEntity();
          
          AdminRepository _adminRepository = new AdminRepository();

          Console.WriteLine("Admin name:");
          String adminName = Console.ReadLine();
          
          Console.WriteLine("Password:");
          String adminPassword = Console.ReadLine();
          
          Console.WriteLine("First name:");
          String firstName = Console.ReadLine();
          
          Console.WriteLine("last name:");
          String lastName = Console.ReadLine();
          
          Console.WriteLine("Email:");
          String email = Console.ReadLine();
          
          Console.WriteLine("Phone:");
          String phone = Console.ReadLine();
          
          Console.WriteLine("Birth:");
          var birth = Console.ReadLine();
          
          adminEntity.adminName = adminName;
          adminEntity.adminPassword = adminPassword;
          adminEntity.fisrtName = firstName;
          adminEntity.lastName = lastName;
          adminEntity.email = email;
          adminEntity.phone = phone;
          adminEntity.birth = birth;
          adminEntity.transaction = "";
          adminEntity.isAdmin = true;
          adminEntity.status = 1;
          
          String connectToDB = "server=127.0.0.1;uid=root;pwd=;database=springherobank";
          _adminRepository.signupAdmin(connectToDB, adminName, adminPassword);
          _adminRepository.save(adminEntity);
          Console.WriteLine("done");
     }
}