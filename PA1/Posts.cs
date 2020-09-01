using System;
using System.Collections.Generic;

namespace PA1
{
    public class Posts : IComparable<Posts>
    {
        public int ID{get;set;}
        public string Post{get;set;}
        public DateTime Time{get;set;}

        // This is the normal sort method. It sorts by date but write in ascending order
        public int CompareTo(Posts temp)
        {
            return this.Time.CompareTo(temp.Time);
        }
        //This sorts the date and prints in descending order
        public static int CompareByDate(Posts x,Posts y)
        {
             return y.Time.CompareTo(x.Time);
        }
        
        //this sort the posts by ID
        public static int CompareByID(Posts x,Posts y)
        {
            return x.ID.CompareTo(y.ID);
        }
        
        public override string ToString()
        {
            return this.ID + ": " + this.Post +"  " + this.Time;
        }

        public string ToFile()
        {
            return ID +"#" + Post +"#" + Time;
        }
    }
}