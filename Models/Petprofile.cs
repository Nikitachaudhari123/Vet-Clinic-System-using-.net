namespace VetClinic.Models
{
    public class PetProfile
    {
        public int Id { get; set; }

        public int PetId { get; set; }
        public Pet? Pet { get; set; }   // allow null

        public string? VetNotes { get; set; }
    }
}
