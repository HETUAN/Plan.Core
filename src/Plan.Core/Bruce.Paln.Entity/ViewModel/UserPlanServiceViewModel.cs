using System;

namespace Bruce.Paln.Entity.ViewModel
{
    public class UserPlanViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Importance { get; set; }
        public string Tag { get; set; }
        public string Detail { get; set; }
        public int IsRemind { get; set; }
        public int PerRemind { get; set; }
        public int perRemindTime { get; set; }
        public DateTime HappenTime { get; set; }
        public int UseTime { get; set; }
        public int HappenYear { get; set; }
        public int HappenMonth { get; set; }
        public int HappenDay { get; set; }
        public int HappenHour { get; set; }
        public int HappenMinute { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int Result { get; set; }
        public string Summary { get; set; }
    }
}
