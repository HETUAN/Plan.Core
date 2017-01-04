using System;

namespace Bruce.Paln.Entity
{
    public class LeetAnswerEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int LeetCodeId { get; set; }
        public int Status { get; set; }
        public string Answer { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
