﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SeminarHub.Data.Common.DataConstants;

namespace SeminarHub.Data.Models
{
    public class Seminar
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TopicMaxlength)]
        public string Topic { get; set; } = string.Empty;

        [Required]
        [MaxLength(LecturerMaxLength)]
        public string Lecturer { get; set; } = string.Empty;

        [Required]
        [MaxLength(DetailsMaxLength)]
        public string Details { get; set; } = string.Empty;

        [Required]
        public string OrganizerId { get; set; } = string.Empty;

        [Required]
        public IdentityUser Organizer { get; set; } = null!;

        [Required]
        public DateTime DateAndTime { get; set; }

        [MaxLength(DurationMaximum)]
        public int Duration { get; set; }

        [Required]
        public int CategoryId { get; set; }
        [Required]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        public List<SeminarParticipant> SeminarsParticipants { get; set; } = new List<SeminarParticipant>();

    }
}
//•	Has Id – a unique integer, Primary Key
//•	Has Topic – string with min length 3 and max length 100 (required)
//•	Has Lecturer – string with min length 5 and max length 60 (required)
//•	Has Details – string with min length 10 and max length 500 (required)
//•	Has OrganizerId – string (required)
//•	Has Organizer – IdentityUser (required)
//•	Has DateAndTime – DateTime with format "dd/MM/yyyy HH:mm" (required) (the DateTime format is recommended, if you are having troubles with this one, you are free to use another one)
//•	Has Duration – integer value between 30 and 180
//•	Has CategoryId – integer, foreign key (required)
//•	Has Category – Category (required)
//•	Has SeminarsParticipants – a collection of type SeminarParticipant
