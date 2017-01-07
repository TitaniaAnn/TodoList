using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    class Task
    {
        private string notes;
        private string selfLink;

        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Parent { get; set; }
        public string Link { get; set; }
        public string Status { get; set; }
        public bool? Hidden { get; set; }
        public DateTime? Completed { get; set; }
        public DateTime? Due { get; set; }
        public DateTime? Updated { get; set; }
        //public bool Deleted { get; set; }


        public Task(string id, string title, string notes, string parent, string selfLink, string status, bool? hidden, DateTime? completed, DateTime? due, DateTime? updated)
        {
            Id = id;
            Title = title;
            Description = notes;
            Parent = parent;
            Link = selfLink;
            Status = status;
            Hidden = hidden;
            Completed = completed;
            Due = due;
            Updated = updated;
        }
    }
}
