using System;
using System.Collections.Generic;
using System.Text;

namespace LoowooTech.LEDFlow.Model
{
    public class Admin
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }
    }

    public enum Role
    {
        普通管理员,
        系统管理员,
    }
}
