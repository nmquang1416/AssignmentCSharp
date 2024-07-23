using System.Collections;
using AssignmentCSharp.Entity;

namespace AssignmentCSharp.Repository.admin;

public interface iAdminRepository
{
    void signupAdmin(String connectToDB,String account, String password);
    String loginAdmin(String account, String password);
    List<AdminEntity> findAll();
    AdminEntity findById(long id);
    AdminEntity save(AdminEntity adminEntity);
    AdminEntity update(AdminEntity adminEntity);
    void delete(long id);
}