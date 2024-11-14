namespace Watchlist.Data.Constants
{
    public static class DataConstants
    {
        // User constants:
        public const int UserNameMinLength = 5;
        public const int UserNameMaxLength = 20;

        public const int UserMailMinLength = 10;
        public const int UserMailMaxLength = 60;

        public const int UserPwdMinLength = 5;
        public const int UserPwdMaxLength = 20;

        // Movie constants:
        public const int MovieTitleMinLength = 10;
        public const int MovieTitleMaxLength = 50;

        public const int MovieDirectorMinLength = 5;
        public const int MovieDirectorMaxLength = 50;

        public const int MovieImageUrlMaxLength = 255;

        public const string MovieRatingMinValue = "0.0";
        public const string MovieRatingMaxValue = "10.0";

        public const string MovieInputErrorMessage = "Field {0} should be between {2} and {1} characters long.";
        public const string MovieImageUrlTooLong = "Field {0} is too long. It should be less than {1} characters long.";

        // Genre constants:
        public const int GenreNameMinLength = 5;
        public const int GenreNameMaxLength = 50;

        public const string GenreNotExists = "This genre does not exist.";
    }
}
