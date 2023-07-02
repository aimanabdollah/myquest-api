namespace MyQuestAPI.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public string QuestionText { get; set; }

        public List<Option> Options { get; set; }
    }
}
