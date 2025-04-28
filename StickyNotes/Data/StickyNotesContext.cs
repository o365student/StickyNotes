// Data/StickyNotesContext.cs
using Microsoft.EntityFrameworkCore;
using StickyNotes.Models;

namespace StickyNotes.Data
{
    public class StickyNotesContext : DbContext
    {
        public StickyNotesContext(DbContextOptions<StickyNotesContext> options)
            : base(options)
        {
        }

        public DbSet<Note> Notes => Set<Note>();
    }
}
