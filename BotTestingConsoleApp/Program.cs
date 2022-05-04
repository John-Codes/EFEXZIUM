using System;
using System.Collections.Generic;

namespace BotTestingConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class IMSG
    {

        #region Properties

        public string KeyWord { get; set; }

        public List<string> KeyWords { get; set; }

        public string Message { get; set; }

        public string BackgroundImage { get; set; }
        public bool NewMessage { get; set; }

        public string BotProgramTitle { get; set; }
        public bool IsSimpleMode { get; set; } = false;
        public string SelectedKeyword { get; set; }

        public string HelpMessage { get; set; }
        public bool IsLoggedIn { get; set; }




        #endregion
    }
    public static class ChatBot
    {
        #region Properties
         public string BotCustomerServiceEmail { get; set; }
         public string UsersEmail { get; set; }
         
         public static readonly string AskUserEmail { get; set; }= "What is your Email?";
         public static string EmailInput { get; set; }
         public static readonly string AskUserPW { get; set; }= "What is your Password?";
         public static string PasswordInput { get; set; }
        
        
        
	    #endregion

        #region Help User Methods
        public static IMSG HelpUser(IMSG m) 
        {
           if (m.IsLoggedIn==true)
	        {
	        //Call API  send users email and users message 
            }

           if(m.IsLoggedIn == false)
            {
                LogIn(m);
            }
        }
    	#endregion

        #region User Loggin
        /// <summary>
        /// Call this method until IsLoggedIn = true
        /// </summary>
         public static IMSG LogIn(IMSG m) 
        {
            if (m.IsLoggedIn==true)
	        {
                return m;
	        }

            if (m.IsLoggedIn == false)
	        {
                if (string.IsNullOrEmpty(EmailInput)==true)
	            {
		            m.Message =  AskUserEmail;
                    return m;
	            }
                 if (string.IsNullOrEmpty(PasswordInput)==true)
	            {
		            m.Message =  AskUserPW;
                    return m;
	            }
	        }   
        } 
           

	    #endregion

        #region Bot Write To Screen Methods

        /// <summary>
        /// Writes a message to the Users Screen locally.
        /// Every time this method is called the chatbot prints the message to the screen.
        /// Adding a row to a list view on the UI
        /// The person can type the word he’s interested in.

        /// </summary>
        /// <returns></returns>
        public static IMSG BW(string message, string backgroundImage, List<string> keywords)
        {
            var bot = new IMSG() { BackgroundImage = backgroundImage, KeyWords = keywords, Message = message, HelpMessage = String.Empty };
            foreach (var item in bot.KeyWords)
            {

                bot.HelpMessage = "Please say one of this words: " + item + " ";

            }
            return bot;
        }
        #endregion

        #region Bot Read User Input

        public static ChatBotModel BR(IMSG bot)
        {
            if (!string.IsNullOrEmpty(bot.SelectedKeyword) && bot.KeyWords != null)
            {
                if (!bot.KeyWords.Contains("Help")) 
                { 
                 bot.KeyWords.Add("Help");	
                }


	        }
                foreach (var word in bot.KeyWords)
                { 
                    var lowercapword = word.ToLower();
                    var lowercapSelected = bot.SelectedKeyword.ToLower();
                    
                    if (lowercapword.Contains(lowercapSelected) == true)
                    {
                        bot.SelectedKeyword = word;

                        return bot;
                    }

                }

            
            bot.IsSimpleMode = true;
          
            foreach (var item in bot.KeyWords)
	        {

		      bot.HelpMessage = "Im sorry did you mean? "+   item +" ";

	        }
            
            return bot;
        }
        #endregion

    }
}
