using System;
using System.Collections.Generic;

namespace PA1
{
    class Program
    {
        static void Main(string[] args)
        {
            int menuInput = 0;
            while (menuInput!=4)
            {
                Console.WriteLine("Press 1 to Show All Posts.\nPress 2 to Add a Post.\nPress 3 to delete a Post.\nPress 4 to Exit.");
                
                try
                {
                    menuInput = int.Parse(Console.ReadLine());
                    if(menuInput < 1|| menuInput>4)
                    {
                        throw new Exception("Not a valid menu choice");
                    }

                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    //Directs to user to see all 
                    if(menuInput ==1)
                    {
                        menuInput = 0;

                        List<Posts> bigAlPosts = PostFile.GetPosts();//Reading books in

                        Console.Clear();

                        Console.WriteLine("Here are the posts Sorted by Timestamp:\n");
                        bigAlPosts.Sort(Posts.CompareByDate);
                        
                        PostUtil.PrintAllPosts(bigAlPosts);

                        Console.WriteLine("\nPress enter to return to main menu...");
                        Console.ReadLine();
                        Console.Clear();
                    }   
                    //Directs the user to add a post
                    else if(menuInput == 2)
                    {
                        Console.WriteLine("here is where you add a post");
                        menuInput = 0;
                        
                        List<Posts> bigAlPosts = PostFile.GetPosts();
                        PostUtil.AddPosts(bigAlPosts);
                    }
                    //Directs the user to delete a post
                    else if(menuInput == 3)
                    {
                        Console.WriteLine("here is where you delete a post");
                        menuInput = 0;
                        
                        List<Posts> bigAlPosts = PostFile.GetPosts();
                        PostUtil.DeletePost(bigAlPosts);
                    }
                }
            } 
        }
    }
}
