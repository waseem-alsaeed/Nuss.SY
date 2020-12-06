using App.Entity;
using App.Models;
using App.News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace App.News.API
{
    public class IndexController : ApiController
    {
        public static string conectionString =@"Data Source=DESKTOP-KED0CQ8\MSSQLSERVER2014;Initial Catalog=News;Integrated Security=False;User ID=sa;Password=sql;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public TData<App.Models.Slider> _Slider = new TData<App.Models.Slider>(conectionString);
        public TData<App.Models.News> _News = new TData<App.Models.News>(conectionString);
        public TData<App.Models.Videos> _Videos = new TData<App.Models.Videos>(conectionString);

        public async Task<Dashboard> Get()
        {
            // Get Lastest News
            var LastNews = await _News.SelectAsync(new Entity.Models.StoredProcedure()
            {
                StoredProcedureName = "SP_News"
            });

            // Get New that is Big and We'll put it in right Slider
            var IsMain = await _News.SelectAsync(new Entity.Models.StoredProcedure()
            {
                StoredProcedureName = "SP_IsMain"
            });


            return new Dashboard() { lstNews = LastNews.Data, IsMain = IsMain.Data  };
        }
    }
}
