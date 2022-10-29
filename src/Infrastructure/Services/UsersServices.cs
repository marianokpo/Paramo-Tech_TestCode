using Application.Commmon.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UsersServices : IUsersServices
    {
        public async Task<User> NewUser(string Name, string Email, string Address, string Phone,
            string UserType, string Money)
        {
            return await Task.Run(() =>
            {
                User newUser = new User
                {
                    Name = Name,
                    Email = Email,
                    Address = Address,
                    Phone = Phone,
                    UserType = UserType,
                    Money = decimal.Parse(Money)
                };

                if (newUser.UserType == "Normal")
                {
                    if (newUser.Money > 100)
                    {
                        var percentage = Convert.ToDecimal(0.12);
                        //If new user is normal and has more than USD100
                        var gif = newUser.Money * percentage;
                        newUser.Money = newUser.Money + gif;
                    }
                    else if (newUser.Money > 10 && newUser.Money < 100)
                    {
                        var percentage = Convert.ToDecimal(0.8);
                        var gif = newUser.Money * percentage;
                        newUser.Money = newUser.Money + gif;
                    }
                }
                else if (newUser.UserType == "SuperUser" && newUser.Money > 100)
                {
                    var percentage = Convert.ToDecimal(0.20);
                    var gif = newUser.Money * percentage;
                    newUser.Money = newUser.Money + gif;
                }
                else if (newUser.UserType == "Premium" && newUser.Money > 100)
                {
                    var gif = newUser.Money * 2;
                    newUser.Money = newUser.Money + gif;
                }

                return newUser;
            });
        }

        public async Task<string> NormalizeEmail(string Email)
        {
            return await Task.Run(() =>
            {
                var aux = Email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

                var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

                aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

                return string.Join("@", new string[] { aux[0], aux[1] });
            });
        }

        public async Task<bool> isDuplicate(User user, List<User> users)
        {
            return await Task.Run(() =>
            {
                foreach (var tuser in users)
                {
                    if (tuser.Email == user.Email
                        ||
                        tuser.Phone == user.Phone
                        ||
                        tuser.Name == user.Name
                        ||
                        tuser.Address == user.Address)
                    {
                        return true;
                    }
                }

                return false;
            });
        }
    }
}