using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace NoteStorage
{
    public class NoteContext : DbContext
    {
        public NoteContext(DbContextOptions<NoteContext> options) :base(options)
        {

        }
    }
}
