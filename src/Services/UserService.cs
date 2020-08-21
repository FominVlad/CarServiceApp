using CarServiceApp.Models;
using CarServiceApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceApp.Services
{
    public class UserService
    {
        private AppDbContext dbContext { get; set; }
        public UserService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool AddUser(CreateUserDTO createUserDTO)
        {
            try
            {
                if (createUserDTO == null)
                    throw new Exception("CreateUserDTO is null!");

                dbContext.Users.Add((User)createUserDTO);
                dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteUser(int id)
        {
            try
            {
                User user = dbContext.Users.FirstOrDefault(u => u.Id == id);

                if (user == null)
                    throw new Exception($"User with id = {id} is undefined!");

                dbContext.Users.Remove(user);
                dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateUser(User user)
        {
            try
            {
                if (user == null)
                    throw new Exception($"User is null!");

                User userForUpdate = dbContext.Users.FirstOrDefault(u => u.Id == user.Id);

                if (userForUpdate == null)
                    throw new Exception("User is undefined!");

                userForUpdate.Login = string.IsNullOrEmpty(user.Login) ? userForUpdate.Login : user.Login;
                userForUpdate.Password = string.IsNullOrEmpty(user.Password) ? userForUpdate.Password : user.Password;
                userForUpdate.Name = string.IsNullOrEmpty(user.Name) ? userForUpdate.Name : user.Name;
                userForUpdate.Surname = string.IsNullOrEmpty(user.Surname) ? userForUpdate.Surname : user.Surname;

                dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateUserRole(User user)
        {
            try
            {
                User userForUpdate = dbContext.Users.FirstOrDefault(u => u.Id == user.Id);

                if (userForUpdate == null)
                    throw new Exception("User is undefined!");

                userForUpdate.RoleId = user.RoleId;

                dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public GetUserDTO GetUser(int id)
        {
            try
            {
                return (GetUserDTO)dbContext.Users.FirstOrDefault(u => u.Id == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<GetUserDTO> GetUserList()
        {
            try
            {
                List<GetUserDTO> userList = new List<GetUserDTO>();

                foreach(User user in dbContext.Users.ToList())
                {
                    userList.Add((GetUserDTO)user);
                }

                return userList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
