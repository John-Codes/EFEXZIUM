using System.Collections.Generic;

namespace BotLib
{
    public class IMSG
    {
        public  string Image { get; set; }
        public bool Liked { get; set; }
        public bool Loved { get; set; }
        public bool Hate { get; set; }
        public string Css { get; set; }
       

       

        public List<string> KeyWords { get; set; }

        public string Message { get; set; }

        public string BackgroundImage { get; set; }
        public bool NewMessage { get; set; }

        public string BotProgramTitle { get; set; }
        public bool IsSimpleMode { get; set; } = false;
        
        public string SelectedKeyword { get; set; }

        public string HelpMessage { get; set; }
        public bool IsLoggedIn { get; set; }




       
    }
}
