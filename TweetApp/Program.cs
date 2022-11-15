using System;
using System.IO;
using System.Security.Principal;
using BackEnd;

namespace TweetApp
{
    public class Tweeter
    {
        public static void Main(string[] args)
        {
            string? line;
            short identityId = 0;
            long replyto = 0L;

            Console.WriteLine("Tweeting as (ident): ");
            identityId = Convert.ToInt16(Console.ReadLine());
           
            Identity ident = JsonServices.ReadIdentitesFromFile().Find(id => id.Id == identityId);
            Console.WriteLine(" (Tweeting as " + ident.Name + ")");

            Console.WriteLine("Reply-to (id or 0):");
            replyto = Convert.ToInt64(Console.ReadLine());

            Console.Write("Write your tweet here: ");

            List<Tweet>? tweets = JsonServices.ReadTweetsFromFile(ident);
            while ((line = Console.ReadLine()) != null)
            {
                Tweet tweet = new Tweet(line, replyto);
                tweet.Display();
                tweets.Add(tweet);
                JsonServices.WriteTweetsToFile(tweets, ident);
             
                return;
            }
            
        }
    }
}

