using DAL.DbContexts;
using Models.Entities;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var conn=new TodebProjectDbContext())
            {
                var commen = new Comment
                {
                    Opinion = "The first comment",
                    Rate = 5,
                };

                conn.Add(commen);
                conn.SaveChanges();
            }
        }
    }
}
