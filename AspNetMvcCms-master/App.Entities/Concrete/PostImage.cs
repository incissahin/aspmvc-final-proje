using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities.Concrete
{
    public class PostImage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int PostId { get; set; }

        public string ImagePath { get; set; }

        public virtual Post Post { get; set; }
    }
}
