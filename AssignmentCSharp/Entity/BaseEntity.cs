using System.Collections;
using System.Runtime.InteropServices.JavaScript;

namespace AssignmentCSharp.Entity;

public class BaseEntity
{
    public String fisrtName { get; set; }
    public String lastName { get; set; }
    public String email { get; set; }
    public String phone { get; set; }
    public String birth { get; set; }
    public String transaction { get; set; }
    public bool isAdmin { get; set; } 
    public int status { get; set; }
    
    public BaseEntity()
    {
    }

    public BaseEntity(string fisrtName, string lastName, string email, string phone, string birth, string transaction, bool isAdmin, int status)
    {
        this.fisrtName = fisrtName;
        this.lastName = lastName;
        this.email = email;
        this.phone = phone;
        this.birth = birth;
        this.isAdmin = isAdmin;
        this.status = status;
        this.transaction = transaction;
    }
}