using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities.Concrete
{
    public class CategoryPost
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int PostId { get; set; }        
        public Post Post { get; set; }



    }
}
