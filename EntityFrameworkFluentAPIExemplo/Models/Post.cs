using System;
using System.Collections.Generic;

namespace EntityFrameworkFluentAPIExemplo.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public bool Pusblished { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}