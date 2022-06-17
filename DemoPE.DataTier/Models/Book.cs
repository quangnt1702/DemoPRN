using System;
using System.Collections.Generic;

#nullable disable

namespace DemoEFCore.Models
{
    public partial class Book
    {
        public Guid BookId { get; set; }
        public string BookName { get; set; }
        public int? Quantity { get; set; }
        public string AuthorName { get; set; }
        public Guid? PublisherId { get; set; }

        public virtual Publisher Publisher { get; set; }
    }
}
