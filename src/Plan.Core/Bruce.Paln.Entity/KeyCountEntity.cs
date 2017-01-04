using System;

namespace Bruce.Paln.Entity
{
    public class KeyCountEntity
    {
        public int Id { get; set; }
        public int WorkId { get; set; }
        public int MacAddr { get; set; }
        public DateTime Day { get; set; }
        public DateTime TimeStamp { get; set; }
        public int KCount { get; set; }
        public int UserId { get; set; }
        public DateTime AddTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
