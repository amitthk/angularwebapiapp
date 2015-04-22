using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AngularWebApiApp.Domain.Entities
{

   public class Proj
    {
       [BsonId]
        public int Id { get; set; }

       [BsonElement("Title")]
        public string Title { get; set; }

       [BsonElement("Summary")]
        public string Summary { get; set; }

       [BsonElement("Goals")]
        public ICollection<Goal> Goals { get; set; }

       [BsonElement("Stories")]
        public ICollection<Story> Stories { get; set; }

    }

   public class Goal
   {
       [BsonId]
       public int Id { get; set; }

       [BsonElement("Name")]
       public string Name { get; set; }
       [BsonElement("Summary")]
       public string Summary { get; set; }
   }

   public class Story
   {
       [BsonId]
       public int Id { get; set; }

       [BsonElement("Name")]
       public string Name { get; set; }
       [BsonElement("Summary")]
       public string Summary { get; set; }
   }
}
