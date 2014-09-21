using MongoChat.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MongoChatClient
{
    /// <summary>
    /// Interaction logic for MongoChat.xaml
    /// </summary>
    public partial class MongoChat : Window
    {
        private const string path = "mongodb://mongochattelerik:mongochattelerik@ds035290.mongolab.com:35290/mongotelerikchat";

        public MongoChat()
        {
            InitializeComponent();
            var ctx = GetMongoContext();
        }

        public string User { get; set; }

        public MongoDatabase GetMongoContext()
        {
            MongoClient client = new MongoClient(path);
            MongoServer server = client.GetServer();
            MongoDatabase dbContext = server.GetDatabase("mongotelerikchat");
            return dbContext;
        }

        public MongoCollection<Message> GetMongolabMessages(MongoDatabase dbContext)
        {
            var messages = dbContext.GetCollection<Message>("Messages");
            return messages;
        }

        public MongoCollection<User> GetMongolabUsers(MongoDatabase dbContext)
        {
            var users = dbContext.GetCollection<User>("Users");
            return users;
        }

        private void OnSendBtnClick(object sender, RoutedEventArgs e)
        {
            var dbContext = GetMongoContext();
            var messages = GetMongolabMessages(dbContext);
            var users = GetMongolabUsers(dbContext);

            var text = this.Message.Text;
            var messageToInsert = new Message()
            {
                Date = DateTime.Now,
                Text = text,
                User = new User()
                {
                    Name = this.User,
                },
            };

            messages.Insert(messageToInsert);
            ShowMessages(dbContext);
        }

        public void ShowMessages(MongoDatabase dbContext)
        {
            var messages = GetMongolabMessages(dbContext).FindAll();
            foreach (var m in messages)
            {
                this.Messages.Text += m.ToString();
            }
        }


    }
}
