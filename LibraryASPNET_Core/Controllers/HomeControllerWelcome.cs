using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace LibraryASPNET_Core.Controllers
{
    public class HomeControllerWelcome : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string Welcome (string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hellp {name}, ID : {ID}");
        }
    }
}
