using System;
using System.IO;
using System.Collections.Generic;

namespace PA1
{
    public class PostFile
    {
        //This method reads in the list from a file and error handles for missing text files
        public static List<Posts> GetPosts()
        {
        List<Posts> bigAlPosts = new List<Posts>();
            
            StreamReader inFile = null;
            try
            {
             inFile = new StreamReader("posts.txt");
            }
            catch(Exception e)
            {
                Console.WriteLine("Something went wrong... returning blank list {0}",e);
               return bigAlPosts;
            }
            string line = inFile.ReadLine(); //priming read
            while(line!=null)
            {
                string[] temp = line.Split("#");
                bigAlPosts.Add(new Posts(){ID = int.Parse(temp[0]), Post = temp[1],Time = DateTime.Parse(temp[2])});
                line = inFile.ReadLine();
            }
            inFile.Close();
            return bigAlPosts;
        }
        
       // This method saves updates to a file
        public static void SaveAllPosts(List<Posts> bigAlPosts)
        {
            
            StreamWriter outFile = new StreamWriter("posts.txt");

            foreach (Posts x in bigAlPosts)
            
            outFile.WriteLine(x.ToFile());
            
            
            outFile.Close();
            
        }
    }
}