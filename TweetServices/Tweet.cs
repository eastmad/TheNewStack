using System;
using static System.Net.Mime.MediaTypeNames;

namespace BackEnd
{
    public struct Tweet
    {
        public string Text { get; set; }
        public long Replyto { get; set; }
        public long Time { get; set; }

        public Tweet(string text, long replyto)
        {
            Text = text;
            Replyto = replyto;
            Time = DateTimeOffset.Now.ToUnixTimeSeconds();
        }

        public Tweet(string text, long replyto, long time)
        {
            Text = text;
            Replyto = replyto;
            Time = time;
        }

        public DateTime DateTimeFromSeconds()
        {
            DateTime unixDateTime = DateTime.UnixEpoch;
            unixDateTime = unixDateTime.AddSeconds(Time).ToLocalTime();
            return unixDateTime;
        }

        public void Display()
        {
            Console.WriteLine("\nTweet: " + Text);
            if (Replyto != 0)
                Console.WriteLine("Reply-to: " + Replyto);
            Console.WriteLine("Time: " + DateTimeFromSeconds());
            Console.WriteLine("Id: " + Time);
        }
    }
}

