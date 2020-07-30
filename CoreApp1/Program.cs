using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace CoreApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = File.ReadAllText(@"C:\Users\Achilles.Hu\Desktop\SitecoreUnusedImage-2020-07-13.txt");
            var taglist = JsonConvert.DeserializeObject<List<Tags>>(str);
            StringBuilder sb = new StringBuilder();
            var header = "Tag,Using,Refernece";
            sb.AppendLine(header);
            foreach (var tag in taglist)
            {
 
                if (tag.UsedList != null && tag.UsedList.Count > 0)
                {
                    for(int i=0;i< tag.UsedList.Count;i++)
                    {
                        var dataStr = "";
                        if (i == 0)
                        {
                             dataStr = string.Format("{0},{1},{2}", tag.Name, tag.Reference.ToString().ToLower(), tag.UsedList[i]);
                        }
                        else
                        {
                             dataStr = string.Format("{0},{1},{2}", "","", tag.UsedList[i]);
                        }
                        sb.AppendLine(dataStr);
                    }
                   
                }
                else
                {
                    var dataStr = string.Format("{0},{1},{2}", tag.Name, tag.Reference.ToString().ToLower(), "");
                    sb.AppendLine(dataStr);
                }
              
            }
            File.WriteAllText(@"C:\Users\Achilles.Hu\Desktop\SitecoreUnusedImage.csv", sb.ToString());

            str = RemoveSpecialChars(str);
           // str = str.Replace('"', ' ');

            //SolrTest.SolrGet();
            return;
            Console.WriteLine("Hello World!");

            var connectionString = "mongodb+srv://achilles:1989312hzw518@cluster0.q6yis.azure.mongodb.net/<dbname>?retryWrites=true&w=majority";
            var database = "test";
            var entiry = new MongoDBBase(connectionString, database);



            var data = entiry.GetList<MongoDBPostTest>(x => x.Body.Contains("3"));
            var data1 = entiry.GetList<MongoDBPostTest>();
           // Console.WriteLine(data);
            return;
            List<MongoDBPostTest> list = new List<MongoDBPostTest>()
            {
                new MongoDBPostTest()
                {
                    Id = "2",
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
                    Id = "3",
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

            entiry.InsertMany(list);
        }

        public static string RemoveSpecialChars(string str)
        {
            // Create  a string array and add the special characters you want to remove
            string[] chars = new string[] { "~", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", "=", "+", "{", "[", "}", "]", ":", ";", "'", "<", ">", ",", ".", "?", "/", "|", "\\", "\"" };
            //Iterate the number of times based on the String array length.
            for (int i = 0; i < chars.Length; i++)
            {
                if (str.Contains(chars[i]))
                {
                    str = str.Replace(chars[i], "");
                }
            }
            return str;
        }
    }

    public class Tags
    {
        public string Name { get; set; }
        public bool Reference { get; set; }
        public List<string> UsedList { get; set; }
    }
}
