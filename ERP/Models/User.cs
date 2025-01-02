using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        [MaxLength(50)] // Username maksimum 50 karakter
        public string Username { get; set; } 

        [Required]
        [MaxLength(256)] // PasswordHash maksimum 256 karakter (hash için geniş bir alan)
        public string PasswordHash { get; set; }  // kullanıcıdan aldığımız plain text şifreyi hashleme fonskiyonu ile şifeleyip kayıt esnasında DB ye yükelriz. Loginde de tam tersi.

        [Required]
        [MaxLength(100)] // Email maksimum 100 karakter
        [EmailAddress] // Geçerli bir email formatı kontrolü
        public string Email { get; set; }

        [Required]
        [MaxLength(50)] // Username maksimum 50 karakter
        public string Name { get; set; }

        [Required]
        [MaxLength(50)] // Username maksimum 50 karakter
        public string Surname { get; set; }

        //[MaxLength(20)] // Role maksimum 20 karakter
        //public string Role { get; set; } = "User"; // Varsayılan olarak "User"

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        //[Timestamp] // RowVersion için Concurrency kontrolü.BU sayede DB ye yakın zaman aralıklarında farklı kullanıcılar aynı kayıtta işlem yaptıklarında karışıklığı önler . Exception döndürtür. DB de bu değer otomotaik oalrak artıp artmadığını kontrol et!
        //public byte[]? RowVersion { get; set; }
    }
}
