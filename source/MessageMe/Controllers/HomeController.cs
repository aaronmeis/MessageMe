using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MessageScott.Models;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace MessageScott.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendMessage(string msg)
        {
            // Create Queue Client
            var queueClient = QueueClient.Create("chat");

            // Create and Send Message to Queue
            var brokeredMessage = new BrokeredMessage(msg);
            queueClient.Send(brokeredMessage);

            // Redisplay home-page
            return RedirectToAction("Index");
        }

    }
}
