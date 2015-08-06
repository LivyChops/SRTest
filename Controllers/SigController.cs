using System.Web.Mvc;
using SRTest.SignalR.Models;
using Orchard.DisplayManagement;
using Orchard.Mvc;
using Orchard.Themes;

namespace SRTest.SignalR.Controllers
{
    public class SigController : Controller
    {
        private readonly dynamic _shapeFactory;

        public SigController(IShapeFactory shapeFactory) {
            _shapeFactory = shapeFactory;
        }
        // GET: Home
        [Themed]
        public ActionResult Index()
        {
            return View();
        }

        [Themed]
        public ActionResult Benchmark()
        {
            return View();
        }

        [OutputCache(Duration = 0)]
        //I found the above was needed in IE with standalone tutorial Project
        public ActionResult GetMessages()
        {
            MessagesRepository _messageRepository = new MessagesRepository();
            //return PartialView("_MessagesList", _messageRepository.GetAllMessages());
            var messages = _messageRepository.GetAllMessages();

            var shape = _shapeFactory.MessageList(
                Message: messages
            );
            return new ShapeResult(this, shape);
        }
    }
}