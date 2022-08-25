using DAL.Abstract;
using DAL.DbContexts;
using DAL.EFBase;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.EF
{
    public class EFUserRepository : EFBaseRepository<User2, TodebDbContext>, IUserRepository
    {
        //Dependency Injection alınan context base verilir.
        public EFUserRepository(TodebDbContext context) : base(context)
        {
        }

        public User2 GetUserWithPassword(string email)
        {
            //include join işlemi yapar
            return Context.Users2
                .Include(x => x.Password)
                .FirstOrDefault(x => x.Email == email);
                
        }
    }
}
