using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoChat.Model
{
    public class Message
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }

        public override string ToString()
        {
            return Environment.NewLine + this.Text + " " + this.Date + " " + "User: " + this.User.Name;
        }
    }
}
