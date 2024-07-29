using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library_MVC.Models
{
    public class BorrowRecord
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Book")]
        public int BookId { get; set; }
        [Required]
        [ForeignKey("Member")]
        public int MemberId { get; set; }
        [Required]
        public DateTime BorrowDate { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public Book Book { get; set; }
        public Member Member { get; set; }
    }
}
