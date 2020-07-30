using CommonServiceLocator;
using SolrNet;
using SolrNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp1
{
    static class SolrTest
    {
        public static void SolrGet()
        {
            Startup.Init<User>("http://localhost:8983/solr/achilles");
            ISolrOperations<User> solr = ServiceLocator.Current.GetInstance<ISolrOperations<User>>();

            SolrQueryResults<User> phoneTaggedArticles = solr.Query("*:*");
        }
    }

    public class User
    {
        [SolrUniqueKey("id")]
        public string Id { get; set; }

        [SolrField("name")]
        public string Name { get; set; }
        [SolrField("description")]
        public string Description { get; set; }
        [SolrField("age")]
        public int Age { get; set; }
    }
}
