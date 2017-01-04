using System.Collections.Generic;

namespace Bruce.Paln.Entity.LeetCode
{
    public class Stat
    {
        public int total_acs { get; set; }
        public string question__title { get; set; }
        public string question__article__slug { get; set; }
        public int total_submitted { get; set; }
        public string question__title_slug { get; set; }
        public bool? question__article__live { get; set; }
        public bool question__hide { get; set; }
        public int question_id { get; set; }
    }

    public class Difficulty
    {
        public int level { get; set; }
    }

    public class StatStatusPair
    {
        public object status { get; set; }
        public Stat stat { get; set; }
        public bool is_favor { get; set; }
        public bool paid_only { get; set; }
        public Difficulty difficulty { get; set; }
        public int frequency { get; set; }
        public int progress { get; set; }
    }

    public class LeetCodeEntity
    {
        public int frequency_mid { get; set; }
        public int num_solved { get; set; }
        public string category_slug { get; set; }
        public IList<StatStatusPair> stat_status_pairs { get; set; }
        public bool is_paid { get; set; }
        public int frequency_high { get; set; }
        public string user_name { get; set; }
        public int num_total { get; set; }
    }
}
