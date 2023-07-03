namespace App.Entities.Concrete
{
    public class Department
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public List<Service> Services { get; set; }
    }
}
