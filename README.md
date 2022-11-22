# How to Build Your Own Decentralized Twitter

This project accompanies thenewstack.io article 'How to Build Your Own Decentralized Twitter'. It is a Microsoft Visual Studio Solution with two runnable projects and a small library assembly.

## The Project

The purpose of the project is to examine how a simple fully distributed architecture behaves under stress. See the article series for more detail. The project consists of 3 'tweet stores' which are just JSON entries, that the TweetDisplay pulls tweets from before threading them together to display them. The identities.json file defines the participating tweeters.

## Building and running

- Clone or download the project
- Open up the solution file _TheNewStack.sln_ with Visual Studio or VS Code.
- Edit line 12 of **TweetServices/JSonServives.cs** which mentions 

    const string BASEDIRECTORY = "/Users/eastmad/Projects/TheNewStack/";

  and edit ths path appropriately with the directory name you have used. 
- Run TweetDisplay to see the current small conversation
- Run TweetApp to create tweets in one of the stores ('1', '2' or '3' corresponding to the id's in the identity file)
  - For reply-to, use 0 for a new thread, or the tweet id to reply to a tweet.
  - You can only reply to the last tweet! 

## Data

- The JSON data is currently in the top level, but can be placed anywhere, just adjust that BASEDIRECTORY path.
- You can add tweets, change the premission bool, and add new identities and participating stores.
