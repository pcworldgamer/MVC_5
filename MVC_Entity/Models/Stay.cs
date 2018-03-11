using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Entity.Models {
    public class Stay {
        [Key]
        public int StayId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Entrada")]
        [Required(ErrorMessage = "Data de entrada é obrigatória")]
        public DateTime EntryDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Saída")]
        public DateTime ExitDate { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Valor pago")]
        public decimal cost_paid { get; set; }
        //foreign keys
        public int ClientId { get; set; }
        public Client client { get; set; }
        public int nr { get; set; }
        public Room room { get; set; }
    }
}