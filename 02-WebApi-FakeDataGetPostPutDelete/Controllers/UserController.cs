using _02_WebApi_FakeDataGetPostPutDelete.Models;
using _02_WebApi_FakeDataGetPostPutDelete.Models.DummyData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _02_WebApi_FakeDataGetPostPutDelete.Controllers
{
    [Route("api/[controller]/[action]")]//Route default olarak sunulur ve https:localhost://PortNo/api/User şeklindedir
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<User> _users = FakeData.GetUsers(200);
        [HttpGet]
        public List<User> GetUsers()
        {
            return _users;
        }
        [HttpGet("{id}")]//Listeden ilgili ıd li kişiyi döndür
        public User GetUserById(int Id)
        {
            return _users.FirstOrDefault(x => x.Id == Id);
        }
        [HttpPost]
        public string Post()
        {
            return "Merhaba POST";
        }
        [HttpDelete]
        public bool Delete(int Id)
        {
            User deletedUser = GetUserById(Id);//_users.Find(x => x.Id == Id);
            if (deletedUser != null)
            {
                _users.Remove(deletedUser);
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpPut]
        public User Update(int Id, string firstName, string lastName, string phone, string email)
        {
            User updateUser = GetUserById(Id); //_users.FirstOrDefault(x => x.Id == Id);
            if (updateUser != null)
            {
                updateUser.FirsName = firstName;
                updateUser.LastName = lastName;
                updateUser.Phone = phone;
                updateUser.Email = email;

                return updateUser;
            }
            else
            {
                return new Models.User { };
            }
        }
        [HttpPost]
        public User CreateUser(string firsName, string lastName, string phone, string email, string adress, string password)
        {
            int id = _users.Count + 1;
            var CreatedUser = new Models.User { Id = id, FirsName = firsName, Adress = adress, Email = email, LastName = lastName, Phone = phone, Password = password };
            _users.Add(CreatedUser);
            return GetUserById(id);

        }
        // Post, Put, Delete yanıt veren method olş,-----Post Listeye eleman eklesin----------Put listedeki bir kullanıcıyı güncellesin--Delete Listedeki bir kullanıcıyı silsin

    }
}
