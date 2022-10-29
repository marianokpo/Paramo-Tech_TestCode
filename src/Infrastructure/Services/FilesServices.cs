using Application.Commmon.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class FilesServices : IFilesServices
    {
        private readonly string path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

        private StreamReader ReadUsersFromFile()
        {
            FileStream fileStream = new FileStream(path, FileMode.Open);

            StreamReader reader = new StreamReader(fileStream);
            return reader;
        }

        public bool WriteUserToFile(User user)
        {
            try
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(user.ToString());
                }
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error Escribiendo el usuario. Error: {e.Message}");
                return false;
            }
        }

        public async Task<List<User>> GetUsersFromFile()
        {
            return await Task.Run(() =>
            {
                StreamReader reader = ReadUsersFromFile();

                List<User> _users = new List<User>();

                while (reader.Peek() >= 0)
                {
                    var line = reader.ReadLineAsync().Result;
                    var user = new User
                    {
                        Name = line.Split(',')[0].ToString(),
                        Email = line.Split(',')[1].ToString(),
                        Phone = line.Split(',')[2].ToString(),
                        Address = line.Split(',')[3].ToString(),
                        UserType = line.Split(',')[4].ToString(),
                        Money = decimal.Parse(line.Split(',')[5].ToString().Replace(".", ",")),
                    };
                    _users.Add(user);
                }
                reader.Close();

                return _users;
            });
        }
    }
}