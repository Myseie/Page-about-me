using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Page_About_Me.Models;
using System;

namespace Page_About_Me.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            MongoClient dbClient = new MongoClient();
            var database = dbClient.GetDatabase("Contacts");
            var collection = database.GetCollection<Contact>("contactlist");

            collection.InsertOne (contact);

            return View(contact);
        }

        public IActionResult ShowContacts()
        {
            MongoClient dbClient = new MongoClient();
            var database = dbClient.GetDatabase("Contacts");
            var collection = database.GetCollection<Contact>("contactlist");

            List<Contact> contacts = collection.Find(c => true).ToList();

            return View(contacts);
        }
        public IActionResult ShowContact(string Id)
        {
            ObjectId objectId = new ObjectId(Id);
            MongoClient dbClient = new MongoClient();
            var database = dbClient.GetDatabase("Contacts");
            var collection = database.GetCollection<Contact>("contactlist");

            Contact contacts = collection.Find(c => c.Id == objectId).FirstOrDefault();
            return View(contacts);
        }
        [HttpPost]
        public IActionResult DeleteContact(string Id)
        {
            ObjectId contactId = new ObjectId(Id);
            MongoClient dbClient = new MongoClient();
            var database = dbClient.GetDatabase("Contacts");
            var collection = database.GetCollection<Contact>("contactlist");

            collection.DeleteOne(c => c.Id == contactId);

            return Redirect("/Contact/ShowContacts");

        }

        
    }
}
