using System.Runtime.InteropServices.JavaScript;
using AssignmentCSharp.Entity;

namespace AssignmentCSharp.Repository;

public interface iUserRepository
{
    UserEntity save(UserEntity userEntity);
    void signUpUser(String account, String password);
    String loginUser(String account, String password);
    void sendMoney(double Monney,string MYSQL_CONNECTION_STRING);
    double transferPlus(double account01);
    double transferMinus(double account02);
    double blanceQuerry(String accoount_number);
    UserEntity editInfomation(UserEntity userEntity);
    UserEntity editPassword(UserEntity userEntity);
}