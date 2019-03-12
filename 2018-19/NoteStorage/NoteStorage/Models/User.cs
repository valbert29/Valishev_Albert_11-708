﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteStorage.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public List<Note> Notes { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
