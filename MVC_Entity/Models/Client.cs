using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Entity.Models {
    public class Client {
        [Key]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Tem de indicar o nome do cliente")]
        [StringLength(50)]
        [MinLength(5, ErrorMessage = "O nome é muito pequeno")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Tem de indicar a morada do cliente")]
        [StringLength(50)]
        [MinLength(5, ErrorMessage = "Morada muito pequena")]
        public string morada { get; set; }

        [Required(ErrorMessage = "Tem de indicar o código postal do cliente")]
        [StringLength(8)]
        [MinLength(7, ErrorMessage = "O código postal é muito pequeno")]
        [Display(Name = "Código Postal")]
        public string cp { get; set; }

        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        public string telefone { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Tem de indicar a data de nascimento do cliente")]
        public DateTime data_nascimento { get; set; }
    }
}