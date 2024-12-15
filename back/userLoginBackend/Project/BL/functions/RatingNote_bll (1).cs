using AutoMapper;
using BLL.AutoMapper;
using BLL.interfaces;
using DAL.Interfaces;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.functions
{
    public class RatingNote_bll : IRatingNote_bll
    {
        Irating Irating;
        IMapper _mapper;

        public RatingNote_bll(Irating irating, IMapper mapper)
        {
            Irating = irating;
            _mapper = mapper;
        }
        public List<models_bll.RatingNote_bll> GetAll()
        {
            List<RatingNote> RatingNote = Irating.GetAll();
            return _mapper.Map<List<models_bll.RatingNote_bll>>(RatingNote);
        }
    }
}
