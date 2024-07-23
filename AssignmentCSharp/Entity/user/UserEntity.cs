using System.Runtime.InteropServices.JavaScript;

namespace AssignmentCSharp.Entity;

public class UserEntity : BaseEntity
{
    public long userId { get; set; }
    public String userName { get; set; }
    public String userPassword { get; set; }
    public String accountNumber { get; set; }
    public double blance { get; set; }

    public UserEntity()
    {
        
    }

    public UserEntity(long userId, string accountNumber, double blance, string userName, string userPassword)
    {
        this.userId = userId;
        this.accountNumber = accountNumber;
        this.blance = blance;
        this.userName = userName;
        this.userPassword = userPassword;
    }
}