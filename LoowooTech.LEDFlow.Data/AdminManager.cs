using LoowooTech.LEDFlow.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoowooTech.LEDFlow.Data
{
    public class AdminManager
    {
        private static Admin _currentUser = null;

        public static Admin GetCurrentUser()
        {
            return _currentUser;
        }

        public static Admin Login(string username, string password)
        {
            var admins = DataManager.Instance.GetList<Admin>();
            if (admins.Count == 0)
            {
                _currentUser = new Admin { Username = "temp", Password = "temp", Role = Role.系统管理员 };
            }

            foreach (var e in admins)
            {
                if (e.Username.ToLower() == username.ToLower() && e.Password == password)
                {
                    _currentUser = e;
                }
            }
            return _currentUser;
        }

        public static void Logout()
        {
            _currentUser = null;
        }
    }
}
