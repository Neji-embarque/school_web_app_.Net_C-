using ScoolSolution.Models;

namespace ScoolSolution.Repository
{
    public interface IRoomRepository
    {
        public List<Room> GetAllRooms();
        public void Create(Room room);
        public void Delete(int id);
    }
}
