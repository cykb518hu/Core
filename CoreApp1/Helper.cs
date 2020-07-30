﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CoreApp1
{
    class MongoDBBase
    {
        private readonly IMongoDatabase _database = null;
        public MongoDBBase(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            if (client != null)
            {
                _database = client.GetDatabase(databaseName);
            }
        }


        public List<T> GetList<T>(Expression<Func<T,bool>> conditions = null)
        {
            var collections = _database.GetCollection<T>(typeof(T).Name);
            if (conditions != null)
            {
                return collections.Find(conditions).ToList();
            }
            return collections.Find(_ => true).ToList();
        }
        public List<T> InsertMany<T>(List<T> list)
        {
            var collection = _database.GetCollection<T>(typeof(T).Name);
            collection.InsertMany(list);
            return list;
        }
    }

    public class MongoDBPostTest
    {
        [BsonId]
        // standard BSonId generated by MongoDb
        public ObjectId InternalId { get; set; }
        public string Id { get; set; }

        public string Body { get; set; } = string.Empty;

        [BsonDateTimeOptions]
        public DateTime UpdatedOn { get; set; } = DateTime.Now;

        public NoteImage HeaderImage { get; set; }

        public int UserId { get; set; } = 0;
    }
    public class NoteImage
    {
        public string Url { get; set; } = string.Empty;
        public string ThumbnailUrl { get; set; } = string.Empty;
        public long ImageSize { get; set; } = 0L;
    }
}