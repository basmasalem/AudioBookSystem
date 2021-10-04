using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Model
{
    public class User :BaseData
    {
        
        public int UserId { get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; }
        [ForeignKey("UserType")]
        public int UserTypeId { get; set; }
        [Required, MaxLength(200)]
        public string Email { get; set; }
        [Required, MaxLength(50)]
        public string Password { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }

        public DateTime? LoginDate { get; set; }
        [ForeignKey("UserCreated")]
        public int? CreatedBy { get; set; }
        [MaxLength(100)]

        public string Image { get; set; }
        [MaxLength(200)]
        public string BioAr { get; set; }
        [MaxLength(200)]
        public string BioEn { get; set; }
        [ForeignKey("City")]
        public int? CityId { get; set; }
        public virtual UserType UserType { get; set; }
        public virtual User UserCreated { get; set; }

        public virtual City City { get; set; }



    }
}
