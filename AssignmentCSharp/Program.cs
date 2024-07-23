// See https://aka.ms/new-console-template for more information

using AssignmentCSharp.Controller.admin;
using AssignmentCSharp.Controller.user;
using AssignmentCSharp.Entity;
using AssignmentCSharp.Repository;
using MySqlConnector;
// Console.WriteLine("---------Ngân hàng Spring Hero Bank----------");
// Console.WriteLine("01. Dang ky tai khoan");
// Console.WriteLine("02. Dang nhap he thong");
// Console.WriteLine("03. Thoát");
// Console.WriteLine("Your choice: ");

// AdminController adminController = new AdminController();
// AdminEntity adminEntity = new AdminEntity();
UserController userController = new UserController();
//
String MYSQL_CONNECTION_STRING = UserController.signInUser();
Console.WriteLine(MYSQL_CONNECTION_STRING);
// userController.signUpUser();
userController.sendMoney(MYSQL_CONNECTION_STRING);





// var quang = adminController.loginAdmin();
// Console.WriteLine(quang);
// adminController.createAdmin();


// adminController.createAdmin();
