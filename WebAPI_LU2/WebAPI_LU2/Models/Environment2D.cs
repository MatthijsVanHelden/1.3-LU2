namespace WebAPI_LU2.Models
{
    public class Environment2D
    {
        public Guid Id { get; set; }
        public Guid OwnerUserId { get; set; }
        public string Name { get; set; }
        public int MaxLength { get; set; }
        public int MaxHeight { get; set; }
    }
}
