using AutoMapper;
using BLL.AutoMapper;
using BLL.interfaces;
using BLL.models_bll;
using DAL.Interfaces;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BLL.functions
{
    public class SearchLogBll : ISearchLogBll
    {
        IsearchLog _IsearchLog;
        IMapper mapper;
        public SearchLogBll(IsearchLog IsearchLog)
        {
            _IsearchLog = IsearchLog;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = (IMapper)config.CreateMapper();
        }
        public List<searchLogModelBll> getall()
        {
            List<SearchLog> SearchLog = _IsearchLog.GetAll();
            return mapper.Map<List<searchLogModelBll>>(SearchLog);
        }
    }
}
