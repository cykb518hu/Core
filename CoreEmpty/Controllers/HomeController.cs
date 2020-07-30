using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreEmpty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace CoreEmpty.Controllers
{
    public class HomeController : Controller
    {
        private readonly MongoDBBase _context = null;
        private readonly IMyDependency _myDependency;
        private readonly IConfiguration _configuration;
        public HomeController(IOptions<MongoDBString> settings, IMyDependency myDependency, IConfiguration configuration )
        {
            _context = new MongoDBBase(settings.Value.connectionString, settings.Value.database);
            _myDependency = myDependency;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            
            _myDependency.WriteMessage(
          "IndexModel.OnGetAsync created this message.");
            var data = _configuration["MongoDBString:database"];
            ViewData["test"] = data;
           
            var memery = _configuration.GetValue<string>("MemoryCollectionKey1", "memory");
            ViewData["memory"] = memery;
            return View();
            List<MongoDBPostTest> list = new List<MongoDBPostTest>()
            {
                new MongoDBPostTest()
                {
                    Id = "4",
                    Body = "Test note 3",
                    UpdatedOn = DateTime.Now,
                    UserId = 1,
                    HeaderImage = new NoteImage
                    {
                        ImageSize = 10,
                        Url = "http://localhost/image1.png",
                        ThumbnailUrl = "http://localhost/image1_small.png"
                    }
                },
                new MongoDBPostTest()
                {
                    Id = "5",
                    Body = "Test note 4",
                    UpdatedOn = DateTime.Now,
                    UserId = 1,
                    HeaderImage = new NoteImage
                    {
                        ImageSize = 14,
                        Url = "http://localhost/image3.png",
                        ThumbnailUrl = "http://localhost/image3_small.png"
                    }
                }
            };

            _context.InsertMany(list);
            return View();
        }
    }
}