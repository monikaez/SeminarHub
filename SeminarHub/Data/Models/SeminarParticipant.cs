using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeminarHub.Data.Models
{
    public class SeminarParticipant
    {
        [Required]
        public int SeminarId { get; set; }
        [ForeignKey(nameof(SeminarId))]
        public Seminar Seminar { get; set; } = null!;

        [Required]
        public string ParticipantId { get; set; } = string.Empty;

        [ForeignKey(nameof(ParticipantId))]
        public IdentityUser Participant { get; set; } = null!;

    }
}
//•	Has SeminarId – integer, PrimaryKey, foreign key (required)
//•	Has Seminar – Seminar
//•	Has ParticipantId – string, PrimaryKey, foreign key (required)
//•	Has Participant – IdentityUser 
