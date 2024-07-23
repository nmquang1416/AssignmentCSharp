using System.Runtime.InteropServices.JavaScript;
using AssignmentCSharp.Entity;
using AssignmentCSharp.Repository;

namespace AssignmentCSharp.Controller.user;

public class UserController
{
    
    public static String signInUser()
    {
        UserRepository _userRepository = new UserRepository();
        
        Console.WriteLine("======Please Sign In======");
        
        Console.WriteLine("Account: ");
        var account = Console.ReadLine();
        Console.WriteLine("Password: ");
        var password = Console.ReadLine();

        String localhost = _userRepository.loginUser(account, password);
        return localhost;
    }
    
    public String signUpUser()
    {
        UserRepository _userRepository = new UserRepository();
        Console.WriteLine("======Please, enter your infomation to Sign Up======");

        Console.WriteLine("Your user name: ");
        String userName = Console.ReadLine();
        
        Console.WriteLine("Your password: ");
        String userPassword = Console.ReadLine();
        
        Console.WriteLine("Your first name: ");
        String firstName = Console.ReadLine();
        
        Console.WriteLine("Your last name: ");
        String lastName = Console.ReadLine();
        
        Console.WriteLine("Your email: ");
        String email = Console.ReadLine();
        
        Console.WriteLine("Your phone: ");
        String phone = Console.ReadLine();
        
        Console.WriteLine("Your birth: ");
        String birth = Console.ReadLine();

        UserEntity userEntity = new UserEntity();

        userEntity.userName = userName;
        userEntity.userPassword = userPassword;
        userEntity.accountNumber = "1903" + randomAccountNumber(5);
        userEntity.blance = 0;
        userEntity.transaction = "";
        userEntity.fisrtName = firstName;
        userEntity.lastName = lastName;
        userEntity.email = email;
        userEntity.phone = phone;
        userEntity.birth = birth;
        userEntity.isAdmin = true;
        userEntity.status = 1;
        
        _userRepository.signUpUser(userName, userPassword);
        _userRepository.save(userEntity);
        
        return _userRepository.loginUser(userName, userPassword);
    }

    public void sendMoney(String MYSQL_CONNECTION_STRING)
    {
        UserRepository _userRepository = new UserRepository(); 
        
        Console.WriteLine("Please, enter your money you want send to account: ");
        double amount = Convert.ToDouble(Console.ReadLine());

        _userRepository.sendMoney(amount, MYSQL_CONNECTION_STRING);
        Console.WriteLine("your current balance is: " + amount);
    }
    public string randomAccountNumber(int length)
    {
        var random = new Random();
        string accountNumber = "";
        
        for (int i = 0; i < length; i++)
            accountNumber = String.Concat(accountNumber, random.Next(10).ToString());
        return accountNumber;
    }
}