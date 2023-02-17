using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace WebApi.Models
{
    public class Person
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string MailAdress { get; set; }
        [Required]
        public string Password { get; set; }

        

    }

}
