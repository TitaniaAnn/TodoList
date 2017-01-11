using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    class List
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Link { get; set; }
        public string Color { get; set; }
        public DateTime? LastUpdated { get; set; }
        public IList<Task2> Tasks { get; set; }

        public List(string id, string title, string type, string link, DateTime? lastUpdated)
        {
            Id = id;
            Title = title;
            Type = type;
            Link = link;
            LastUpdated = lastUpdated;
            Tasks = new List<Task2>();
        }

        public List(string id, string title, string type, string link, DateTime? lastUpdated, IList<Task2> tasks)
        {
            Id = id;
            Title = title;
            Type = type;
            Link = link;
            LastUpdated = lastUpdated;
            Tasks = tasks;
        }
    }
}
