using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Page_About_Me.Models;

namespace Page_About_Me.Controllers
{
    public class SkillsandKnowledge : Controller
    {
        public IActionResult mySkills()
        {

            MongoClient dbClient = new MongoClient();
            var database = dbClient.GetDatabase("Skills");
            var collection = database.GetCollection<Skill>("skills");
            
            List<Skill> skills = collection.Find(s => true).ToList();
            
            return View(skills);
        }
       
        public IActionResult CreateSkill()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSkill(Skill skills) 
        {
            MongoClient dbClient = new MongoClient();
            var database = dbClient.GetDatabase("Skills");
            var collection = database.GetCollection<Skill>("skills");

            collection.InsertOne(skills);
            return Redirect("/Home/Skill");
        }
        public IActionResult ShowSkills()
        {

            MongoClient dbClient = new MongoClient();
            var database = dbClient.GetDatabase("Skills");
            var collection = database.GetCollection<Skill>("skills");

            List<Skill> skills = collection.Find(s => true).ToList();
            return View(skills);
        }
        public IActionResult ShowSkill(string Id)
        {
            ObjectId objectId = new ObjectId(Id);
            MongoClient dbClient = new MongoClient();
            var database = dbClient.GetDatabase("Skills");
            var collection = database.GetCollection<Skill>("skilllist");

            Skill skills = collection.Find(s => s.Id == objectId).FirstOrDefault();
            return View(skills);
        }


        public IActionResult myKnowledge()
        {
            return View();
        }
    }
}
