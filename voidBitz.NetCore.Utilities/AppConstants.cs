using System;

namespace voidBitz.NetCore.Utilities
{
    public static class AppConstants
    {
        public static string EnterTextPlaceHolder = "Please enter the {0} text...";
        public static string QuestionTextPlaceHolder = "Please enter the question text...";

        public static string UpdateAddErrorWhenSaving = "Something went wrong saving {0}";
        public static string ErrorWhenDeleting = "Something went wrong deleting {0}";
        public static string ExistsErrorString = "An {0} with this text exists in the database.";

        public static string Success = "Success";
        public static string Failure = "Failure";

        public static string Notification_Saved = "{0} saved.";
        public static string Notification_Error = "{0}";
    }
}
