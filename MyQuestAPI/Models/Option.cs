﻿namespace MyQuestAPI.Models
{
    public class Option
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public bool Correct { get; set; }
    }
}
