using System.Collections.Generic;

namespace BotLib
{
    public static partial class ChatBot
    {

        public static bool NewMessage { get; set; }
        public static List<string> CurrentKeyWords { get; set; }= new List<string>(){ };
        public static string BotCustomerServiceEmail { get; set; }
        public static string UsersEmail { get; set; }

        public static string AskUserEmail { get; set; } = "What is your Email?";
        public static string EmailInput { get; set; }
        public static string AskUserPW { get; set; } = "What is your Password?";
        public static string PasswordInput { get; set; }

       



    }
}
