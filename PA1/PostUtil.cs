using System;
using System.IO;
using System.Collections.Generic;

namespace PA1
{
    public class PostUtil
    {
        public static void PrintAllPosts(List<Posts> posts)
        {
            foreach(Posts x in posts)
            {
                Console.WriteLine(x.ToString());
            }
        }
        
        
        //This method allows the user to enter new information and write a new post to the file.
        public static void AddPosts(List<Posts> posts)
        {   
            Console.Clear();
            
            List<Posts> bigAlPosts = PostFile.GetPosts();
        //Show the User Current Posts
            Console.WriteLine("Here are the current posts:");
            bigAlPosts.Sort(Posts.CompareByID);
            PrintAllPosts(bigAlPosts);
        //Prompt the user to enter new information
            Console.WriteLine("\nEnter the ID of the new post");
            int newPostID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter what you would like to say in the new post");
            string newPost= Console.ReadLine();

        //Write to the last line of the file 
            bigAlPosts.Add(new Posts() {ID = newPostID, Post = newPost,Time = DateTime.Now});

        //Show the user the updated posts
            Console.WriteLine("Here are the updated posts:\n"); 
            bigAlPosts.Sort(Posts.CompareByDate);      
            PrintAllPosts(bigAlPosts);

        //Save to the file
            PostFile.SaveAllPosts(bigAlPosts);

            Console.WriteLine("\n\nPress Enter to return to main Menu...");
            Console.ReadLine();
            Console.Clear();
        }

        
        //This method takes the ID from the user and deletes that post
        public static void DeletePost(List<Posts> posts)
        {
            Console.Clear();
            List<Posts> bigAlPosts = PostFile.GetPosts();

            Console.WriteLine("Here are the posts:\n\n");
            
            bigAlPosts.Sort(Posts.CompareByID);
            PostUtil.PrintAllPosts(bigAlPosts);

            Console.WriteLine("\nEnter the ID of the post you would like to delete.");
            int searchVal = int.Parse(Console.ReadLine());
            

        //search for ID by user entered number and delets that post
            Posts tempPosts = new Posts();
            
            foreach(Posts x in bigAlPosts)
            {
            if(x.ID == (searchVal))
                {
                   tempPosts = x;
                }
            }
        bigAlPosts.Remove(tempPosts);
        
        //Save Posts to the file
            PostFile.SaveAllPosts(bigAlPosts);
        //print Updated posts to console
            Console.WriteLine("\nHere are the updated posts:\n");     
            bigAlPosts.Sort(Posts.CompareByDate);  
            PrintAllPosts(bigAlPosts);

            Console.WriteLine("\n\nPress Enter to return to main Menu...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}