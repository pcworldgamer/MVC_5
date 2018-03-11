using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Entity.Models {
    public class Room {
        [Key]
        public int nr { get; set; }

        [Required(ErrorMessage = "Deve indicar o piso do quarto")]
        public int piso { get; set; }

        [Required(ErrorMessage = "Deve indicar a lotação")]
        public int lotacao { get; set; }

        [Required(ErrorMessage = "Deve indicar o estado do quarto")]
        public bool estado { get; set; }    //false room occupied true room available

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Deve indicar o preço por dia do quarto")]
        public decimal custo_dia { get; set; }
    }
}