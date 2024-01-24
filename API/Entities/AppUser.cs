using System.ComponentModel.DataAnnotations;

namespace API.Entities;
public class AppUser
{

    public  int Id{ get;set;}
    public string UserName { get; set; }  //optional
    public byte[] PasswordHash {get;set;}
    public byte[] PasswordSalt {get;set;}

}
