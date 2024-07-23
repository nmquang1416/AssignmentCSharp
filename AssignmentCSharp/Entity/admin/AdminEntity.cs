namespace AssignmentCSharp.Entity;

public class AdminEntity : BaseEntity
{
    public long adminId { get; set; }
    public String adminName { get; set; }
    public String adminPassword { get; set; }
   
    public AdminEntity()
    {
    }

    public AdminEntity(long adminId, string adminName, string adminPassword)
    {
        this.adminId = adminId;
        this.adminName = adminName;
        this.adminPassword = adminPassword;
        
    }
}