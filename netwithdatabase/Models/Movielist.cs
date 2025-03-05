using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Globalization;
using SharpCompress.Writers;

namespace netwithdatabase.Models
{
    public class Movielist
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        public string plot { get; set; }

        public List<string> genres { get; set; }

        public int runtime { get; set; }

        public List<string> cast { get; set; }

        public string poster { get; set; }

        public string title { get; set; }

        public string fullplot { get; set; }

        public List<string> languages { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime released { get; set; }

        public List<string> directors { get; set; }
        public List<string> writers { get; set; }
        public string rated { get; set; }

        public Awards awards { get; set; }
        //public string metacritic { get; set; }
        //public DateTime lastupdated { get; set; }
        //
        public string lastupdated { get; set; } // Assuming the API response provides the date as a string

        public int year { get; set; }
        
        public Imdb imdb { get; set; }

        public List<string> countries { get; set; }

        public string type { get; set; }

        public Tomatoes tomatoes { get; set; }

        [BsonElement("num_mflix_comments")]
        public int numMflixComments { get; set; }
    }

    public class Awards
    {
        public int wins { get; set; }

        public int nominations { get; set; }

        public string text { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class Imdb
    {
        public double rating { get; set; }

        public int votes { get; set; }

        public int id { get; set; }
    }
    public class Tomatoes
    {
        public Viewer viewer { get; set; }

        public int fresh { get; set; }

        public Critic critic { get; set; }

        public int rotten { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime lastUpdated { get; set; }
        public DateTime dvd { get; set; }
        public string website { get; set; }
        public string production { get; set; }
        public string consensus { get; set; }
    }

    public class Viewer
    {
        public double rating { get; set; }

        public int numReviews { get; set; }

        public int meter { get; set; }
    }
    public class Critic
    {
        public double rating { get; set; }

        public int numReviews { get; set; }

        public int meter { get; set; }
    }
    //public class Writer
    //{
    //    public string name { get; set; }
    //    public string role { get; set; }
    //}
}
