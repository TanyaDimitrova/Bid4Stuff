﻿namespace Bid4Stuff.Models
{
   public class Category
    {
       public Category()
       {
       }

       public Category(string name)
       {
            this.Name = name;
       }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
