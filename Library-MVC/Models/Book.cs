using System.ComponentModel.DataAnnotations;

namespace Library_MVC.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(300)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [StringLength(300)]
        public string Author_Name { get; set; }
        [Required]
        [StringLength(300)]
        public string Genre { get; set; }
        [Required]
        [StringLength(300)]
        public string Publiser_Name { get; set; }
        [Required]
        public string Publiser_Description { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Current_Stock { get; set; }
        public DateTime CreatedAt { get; set; }=DateTime.Now;
    }
}
