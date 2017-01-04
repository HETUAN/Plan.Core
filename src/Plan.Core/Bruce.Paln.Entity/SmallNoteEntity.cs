using System;

namespace Bruce.Paln.Entity
{
    public class SmallNoteEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Note { get; set; }
        public int NState { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
