using System;
using System.Collections.Generic;

#nullable disable

namespace DemoEFCore.Models
{
    public partial class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        public Guid PublisherId { get; set; }
        public string PublisherName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
