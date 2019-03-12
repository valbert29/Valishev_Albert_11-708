using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteStorage.Models
{
    public class Role
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public List<User> Users { get; set; }
    }
}
