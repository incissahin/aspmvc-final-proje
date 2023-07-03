using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities.Concrete
{
    public class Setting
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }

        public string Name { get; set; }
        public string Value { get; set; }

    }
}
