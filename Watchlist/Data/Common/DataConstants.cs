namespace Watchlist.Data.Common
{
    public static class DataConstants
    {
        // User constants:
        public const int UserNameMinLength = 5;
        public const int UserNameMaxLength = 20;

        public const int PasswordMinLength = 5;
        public const int PasswordMaxLength = 20;

        public const int EmailMinLength = 10;
        public const int EmailMaxLength = 60;

        // Input fields error messages:
        public const string RequiredFieldErrorMsg = "This field is required.";
        public const string StringLengthErrorMsg = "Field input should be between {2} and {1} charcters long.";
        public const string UsernameDisplayText = "Username";
        public const string LoginFailedMsg = "Invalid Login, please try again.";

        // Movie constants:
        public const int TitleMinLength = 10;
        public const int TitleMaxLength = 50;

        public const int DirectorMinLength = 5;
        public const int DirectorMaxLength = 50;

        public const int ImageUrlMaxLength = 255;

        public const string RatingMinValue = "0.0";
        public const string RatingMaxValue = "10.0";

        // Genre constants:
        public const int GenreNameMinLength = 5;
        public const int GenreNameMaxLength = 50;

        public const string GenreErrorMsg = "This genre does not exist.";

        // Names of controllers and actions:
        public const string AllActionName = "All";
        public const string IndexActionName = "Index";
        public const string MoviesContrName = "Movies";
        public const string HomeContrName = "Home";
    }
}
