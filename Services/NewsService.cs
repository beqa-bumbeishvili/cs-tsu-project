using ComputerScienceTsu.Models.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerScienceTsu.Services
{
    public class NewsService
    {
        public static News SetNews(string title, string content, int created_by, string file_path)
        {
            News news = new News();
            news.Title = title;
            news.Content = content;
            news.Created_by = created_by;
            news.Image_path = file_path;
            return news;
        }
    }
}