using System;
using System.IO;
using System.Text.Unicode;
using BackEnd;

namespace DisplayTweets
{
    class TweetFrom : IComparable<TweetFrom>
    {
        public string from;
        public Tweet tweet;

        public TweetFrom(string from, Tweet tweet)
        {
            this.from = from;
            this.tweet = tweet;
        }

        public int CompareTo(TweetFrom? other)
        {
            if (tweet.Time == other?.tweet.Time)
            {
                return 0;
            }
       
            // CompareTo() method
            return tweet.Time.CompareTo(other?.tweet.Time);
        }
    }

    public class ShowTweets
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\nTweets:\n");
            //Load Tweets from identities
            List<Identity> idents = JsonServices.ReadIdentitesFromFile();
            List<TweetFrom> totalTweets = new List<TweetFrom>();
            foreach (var ident in idents)
                if (ident.Permission)
                {
                    List<Tweet> tweets = JsonServices.ReadTweetsFromFile(ident);
                    tweets.ForEach(tweet => totalTweets.Add(new TweetFrom(ident.Name, tweet)));
                }

            totalTweets.Sort();

            long prevtweetid = -1;
            char sepchar = ':';
            foreach (var tweetfrom in totalTweets)
            {
                if (prevtweetid == tweetfrom.tweet.Replyto)
                    sepchar = '↳';
                else sepchar = '-';

                        
                Console.WriteLine($"{tweetfrom.tweet.DateTimeFromSeconds()} {tweetfrom.from} ({tweetfrom.tweet.Time}) {sepchar} {tweetfrom.tweet.Text} ");

                prevtweetid = tweetfrom.tweet.Time;
            }
        }
    }
}

