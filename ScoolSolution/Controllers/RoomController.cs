using Microsoft.AspNetCore.Mvc;
using ScoolSolution.Models;
using ScoolSolution.Repository;

namespace ScoolSolution.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        [HttpGet]
        public ActionResult Index()
        {
            List<Room> roomLst = _roomRepository.GetAllRooms();
            return View(roomLst);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Room room)
        {
            if (room != null)
            {
                _roomRepository.Create(room);
            }
            List<Room> roomLst = _roomRepository.GetAllRooms();
            return View("Index",roomLst);
        }
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                _roomRepository.Delete(id);
            }
            List<Room> roomLst = _roomRepository.GetAllRooms();
            return View("Index", roomLst);
        }
    }
}
