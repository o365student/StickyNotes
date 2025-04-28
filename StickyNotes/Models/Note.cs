// Models/Note.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace StickyNotes.Models
{
    public class Note
    {
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [StringLength(4000)]
        public string? Content { get; set; }

        public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
    }
}
