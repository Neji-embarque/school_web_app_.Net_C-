using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using ScoolSolution.Contest;
using ScoolSolution.Models;

namespace ScoolSolution.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly MyDbContext _myDbConnection;
        public RoomRepository(MyDbContext myDbConnection)
        {
            _myDbConnection = myDbConnection;
        }
        public List<Room> GetAllRooms()
        {
            try
            {
                List<Room> rooms = (from RoomsObj in _myDbConnection.Rooms
                                          select RoomsObj).ToList();
                return rooms;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public void Create(Room room)
        {
            _myDbConnection.Rooms.Add(room);
            _myDbConnection.SaveChanges();
        }
        public void Delete(int id)
        {
            Room room = (from RoomObj in _myDbConnection.Rooms
                               where RoomObj.RoomId == id
                               select RoomObj).FirstOrDefault();
            _myDbConnection.Rooms.Remove(room);
            _myDbConnection.SaveChanges();

        }
    }
}
    

