using System.ComponentModel.DataAnnotations;

namespace Portfolio.Web.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        [MinLength(5, ErrorMessage = "Proje adı en az 5 karakter olmalıdır.")]
        [MaxLength(50, ErrorMessage = "Proje adı en fazla 50 karakter olmalıdır.")]
        [Required(ErrorMessage = "Proje adı boş bırakılamaz.")]
        public string ProjectName { get; set; }
        [Required(ErrorMessage = "Proje açıklaması boş bırakılamaz.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Proje Görsel Url boş bırakılamaz.")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Github Url boş bırakılamaz.")]
        public string GithubUrl { get; set; }
        [Required(ErrorMessage = "Kategori boş bırakılamaz.")]
        public int CategoryId { get; set; }

        // Navigation property to the Category entity
        public Category? Category { get; set; }

    }
}
