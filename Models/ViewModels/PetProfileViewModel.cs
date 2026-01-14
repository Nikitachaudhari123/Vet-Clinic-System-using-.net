namespace VetClinic.Models.ViewModels
{
    public class PetProfileViewModel
    {
        public int Id { get; set; }
        public int PetId { get; set; }

        public string VetNotes { get; set; } = string.Empty;

        public IFormFile? NotesFile { get; set; }
    }
}
