using AutoMapper;
using BLL.AutoMapper;
using BLL.interfaces;
using BLL.models_bll;
using DAL.Interfaces;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.functions
{
    public class ActivityLog_bll:IActivityLog_bll
    {

        Ilog _Ilog;
        static IMapper mapper;
        public ActivityLog_bll(Ilog Ilog)
        {

            _Ilog = Ilog;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = (IMapper)config.CreateMapper();
        }

        public List<ActivityLog_modelBll> getall()
        {

            List<ActivityLog> activityLogs = _Ilog.GetAll();
            return mapper.Map<List<ActivityLog_modelBll>>(activityLogs);
        }

        public int Add(ActivityLog_modelBll activity)
        {
            try
            {

                ActivityLog a = _Ilog.Add(mapper.Map<ActivityLog_modelBll, ActivityLog>(activity));
                return a.LogId;

            }
            catch
            {
                return -1;
            }
        }
    }



}
