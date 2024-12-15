using DAL.Interfaces;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.functions
{
    public class ratingDal:Irating
    {
        LiberiansDbContext LiberiansDbContext;
        public ratingDal(LiberiansDbContext LiberiansDbContext)
        {
            this.LiberiansDbContext = LiberiansDbContext;
        }
        public List<RatingNote> GetAll()
        {
            return LiberiansDbContext.RatingNotes.ToList();
        }

    }
}
