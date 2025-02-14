using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_DBContext_Internal.Entity
{
    internal class Book
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int book_id { get; set; }

        public string book_title { get; set; } = string.Empty;

        public string? book_desciption { get; set; }

        public string Book_Genre { get; set; } = string.Empty;

        public DateTime Book_Publish_Date { get; set; }

        public string Book_Status { get; set; } = null!;
        public override string ToString()
        {
            return $"ID: [{book_id}], Title: {book_title}, Genre: {Book_Genre ?? "NA"}, ";
            //$"Published: {Book_Publish_Date:yyyy-MM-dd}, Status: {Book_Status}, " +
            //$"Description: {book_desciption ?? "N/A"}";
        }

    }
}
