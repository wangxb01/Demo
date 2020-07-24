using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreDemoday01.Models;
using coreDemoday01.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace web1.Controllers
{
  
    public class ContentController : Controller
    {
        private readonly Content _contents;
        public ContentController(IOptions<Content> option)
        {
            _contents = option.Value;
        }
        public IActionResult Index()
        {
            //var contents = new List<Content>();
            //for (int i = 1; i < 11; i++)
            //{
            //    contents.Add(new Content { Id = i, title = $"{i}的标题", content = $"{i}的内容", status = 1, add_time = DateTime.Now.AddDays(-1) });
            //}
            return View(new ContentViewModel { Contents =new List<Content> { _contents } });
         
        }
    }
}
