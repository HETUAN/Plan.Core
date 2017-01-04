using System;

namespace Bruce.Paln.Entity.ViewModel
{
    public class NoteViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; } 
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
