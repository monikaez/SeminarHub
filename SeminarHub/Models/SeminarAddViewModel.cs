using System.ComponentModel.DataAnnotations;
using static SeminarHub.Data.Common.DataConstants;

namespace SeminarHub.Models
{
    public class SeminarAddViewModel
    {
       
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(TopicMaxlength,MinimumLength =TopicMinlength,ErrorMessage = StringLengthErrorMessage)]
        public string Topic { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(LecturerMaxLength, MinimumLength = LecturerMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Lecturer { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
       [StringLength(DetailsMaxLength,MinimumLength =DetailsMinLength,ErrorMessage =StringLengthErrorMessage)]
        public string Details { get; set; } = string.Empty;


        [Required(ErrorMessage = RequireErrorMessage)]
        public string DateAndTime { get; set; } = string.Empty;


        [Range(DurationMinimum, DurationMaximum,
           ErrorMessage = DurationLengthErrorMessage)]
        public int Duration { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new HashSet<CategoryViewModel>();

    }
}
