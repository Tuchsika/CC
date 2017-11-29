using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication5.Models
{
    public class ExampleClass
    {
        [AllowHtml]
        public string HtmlContent { get; set; }
        public string Title { get; set; }
    }
}