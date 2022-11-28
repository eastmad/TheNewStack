using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            SortedDictionary<long, TweetFrom> totalTweets = new SortedDictionary<long, TweetFrom>();
            foreach (var ident in idents)
                if (ident.Permission)
                {
                    List<Tweet> tweets = JsonServices.ReadTweetsFromFile(ident);
                    tweets.ForEach(tweet => totalTweets.Add(tweet.Time, new TweetFrom(ident.Name, tweet)));
                }

            Tweet prevtweet = default(Tweet);
            prevtweet.Time = -1;
            char sepchar = ':';
            Identity mitigationIdentity = idents.First();
            List<Tweet> mitigations = JsonServices.ReadTweetsFromFile(mitigationIdentity);

            // Add mitigations before we display
            foreach(var mit in mitigations)
            {
                if (!totalTweets.ContainsKey(mit.Time))
                    totalTweets.Add(mit.Time, new TweetFrom(mitigationIdentity.Name, mit));

            }
    

            foreach (var tweetfrom in totalTweets)
            {
                if (prevtweet.Time == tweetfrom.Value.tweet.Replyto)
                {
                    sepchar = '↳';

                    //Create mitigation tweet
                    mitigations.Add(new Tweet("Tweet not available", prevtweet.Replyto, prevtweet.Time));
                    
                }
                else sepchar = '-';

                        
                Console.WriteLine($"{tweetfrom.Value.tweet.DateTimeFromSeconds()} {tweetfrom.Value.from} ({tweetfrom.Value.tweet.Time}) {sepchar} {tweetfrom.Value.tweet.Text} ");

                prevtweet = tweetfrom.Value.tweet;
            }

            //write mitigations
            
            JsonServices.WriteTweetsToFile(mitigations, mitigationIdentity);
        }
    }
}

