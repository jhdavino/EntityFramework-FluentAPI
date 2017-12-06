using System;
using System.Collections.Generic;

namespace EntityFrameworkFluentAPIExemplo.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}