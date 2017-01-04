using System;

namespace Bruce.Paln.Entity.ViewModel
{
    public class WeeklyViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime WeekDate { get; set; }
        public string Title { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
