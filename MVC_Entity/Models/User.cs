using System.ComponentModel.DataAnnotations;

namespace MVC_Entity.Models {
    public class User {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Campo nome tem de ser preenchido")]
        [StringLength(50)]
        [MinLength(2, ErrorMessage = "Nome muito pequeno")]
        [ScaffoldColumn(true)]
        public string nome { get; set; }
        [Display(Name = "Palavra passe")]
        [MinLength(5, ErrorMessage = "Palavra passe muito pequena")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirme a sua palavra passe")]
        [Compare("password", ErrorMessage = "Palavras passe não são iguais")]
        public string confirmaPassword { get; set; }
        //this should be a drop downlist
        public int perfil { get; set; }

        public bool estado { get; set; }
    }
}