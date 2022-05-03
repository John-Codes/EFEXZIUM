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

    public class ChatBotModel
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




        #endregion
    }
    public static class ChatBot
    {




        #region Bot Write To Screen Methods

        /// <summary>
        /// Writes a message to the Users Screen locally.
        /// Every time this method is called the chatbot prints the message to the screen.
        /// Adding a row to a list view on the UI
        /// The person can type the word he’s interested in.

        /// </summary>
        /// <returns></returns>
        public static ChatBotModel BW(string message, string backgroundImage, List<string> keywords)
        {
            var bot = new ChatBotModel() { BackgroundImage = backgroundImage, KeyWords = keywords, Message = message, HelpMessage = String.Empty };
            foreach (var item in bot.KeyWords)
            {

                bot.HelpMessage = "Please say one of this words: " + item + " ";

            }
            return bot;
        }
        #endregion

        #region Bot Read User Input

        public static ChatBotModel BR(ChatBotModel bot)
        {
            if (!string.IsNullOrEmpty(bot.SelectedKeyword) && bot.KeyWords != null)
            {
                foreach (var word in bot.KeyWords)
                {
                    if (word.Contains(bot.SelectedKeyword) == true)
                    {
                        bot.SelectedKeyword = word;

                        return bot;
                    }

                }

            }
            bot.IsSimpleMode = true;
            
            return bot;
        }
        #endregion

    }
}
