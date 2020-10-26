namespace Command_Management_Tool.Dtos
{
    public class CommandReadDto
    {
        public int Id { get; set; }
        public string HowTo { get; set; }
        public string Line { get; set; }

        // take up Platform property to make Dto different from Model
        // public string Platform { get; set; }
    }
}