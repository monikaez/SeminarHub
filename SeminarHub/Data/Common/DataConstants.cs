namespace SeminarHub.Data.Common
{
    public static class DataConstants
    {
        public const int TopicMaxlength = 100;
        public const int TopicMinlength = 3;
        //•	Has Topic – string with min length 3 and max length 100 (required)
        public const int LecturerMaxLength = 60;
        public const int LecturerMinLength = 5;
        //•	Has Lecturer – string with min length 5 and max length 60 (required)

        public const int DetailsMaxLength = 500;
        public const int DetailsMinLength = 10;
        //•	Has Details – string with min length 10 and max length 500 (required)

        public const string DateFormat = "dd/MM/yyyy HH:mm";
        //•	Has DateAndTime – DateTime with format "dd/MM/yyyy HH:mm" (required) (the DateTime format is recommended, if you are having troubles with this one, you are free to use another one)

        public const int DurationMinimum = 30;
        public const int DurationMaximum = 180;
        //•	Has Duration – integer value between 30 and 180

        public const int CategoryNameMaxLength = 50;
        public const int CategoryNameMinLength = 3;
        //•	Has Name – string with min length 3 and max length 50 (required)

        public const string RequireErrorMessage = "The field {0} is required";
        public const string StringLengthErrorMessage = "The field {0} must be between {2} and {1} characters long";
        public const string DurationLengthErrorMessage = "{0} must be between {1} and {2} minutes";


    }
}
