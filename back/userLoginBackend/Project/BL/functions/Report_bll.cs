using AutoMapper;
using BLL.AutoMapper;
using BLL.interfaces;
using BLL.models_bll;
using DAL.Interfaces;
using DAL.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace BLL.functions
{
    public class Report_bll : IReport_bll
    {
        #region הגדרות משתנים
        Iuser _Iuser;
        Ilog _Ilog;
        Ireport _Ireport;
        static IMapper mapper;
        ISearchLogBll _ISearchLogBll;
        IActivityLog_bll _ActivityLogBll;
        IBorrowApprovalRequestsBll _IBorrowApprovalRequestsBll;
        public Report_bll(Ireport Ireport, ISearchLogBll ISearchLogBll, IBorrowApprovalRequestsBll IBorrowApprovalRequestsBll, Iuser iuser, Ilog ilog, IActivityLog_bll activityLogBll)
        {
            _ActivityLogBll = activityLogBll;
            _Ilog = ilog;
            _Iuser = iuser;
            _Ireport = Ireport;
            _ISearchLogBll = ISearchLogBll;
            _IBorrowApprovalRequestsBll = IBorrowApprovalRequestsBll;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = (IMapper)config.CreateMapper();
            _Ilog = ilog;
            _ActivityLogBll = activityLogBll;
        }
        #endregion
        #region getall
        public List<Report_modelBll> getall()
        {
            List<Report> reports = _Ireport.GetAll();
            return mapper.Map<List<Report_modelBll>>(reports);
        }
        #endregion
        #region GetSearchLogsBorrowRequests
        public List<SearchLogBorrowRequestDto> GetSearchLogsBorrowRequests(string reportName, string type1, int userid)
        {
            try
            {
                var users = _Iuser.GetAll();
                var logs = _ISearchLogBll.getall(); // שליפת החיפושים
                var requests = _IBorrowApprovalRequestsBll.getall(); // שליפת הבקשות
                var query = logs
                    .Join(requests,
                          log => log.UserId,
                          request => request.UserId,
                          (log, request) => new { log, request })
                    .Where(joined => joined.request.RequestDate >= joined.log.SearchDate &&
                                     joined.request.RequestDate <= joined.log.SearchDate.AddMinutes(5))
                    .OrderBy(joined => joined.request.searchDate)
                    .Select(joined => new SearchLogBorrowRequestDto
                    {
                        UserId = joined.log.UserId,
                        SearchQuery = joined.log.SearchQuery,
                        SearchDate = joined.log.SearchDate,
                        RequestId = joined.request.searchDate,
                        RequestDate = joined.request.RequestDate,
                    })
                    .ToList();
                ////////////////////יצירת הדוח////////////////////////////////
                var newReport = new Report
                {
                    ReportName = reportName,
                    ReportData = ConvertToCustomFormat(query, type1),
                    GeneratedAt = DateTime.Now,
                    GeneratedByNavigationUserId = userid,
                    GeneratedBy = users.Find(x => x.UserId == userid).Fname
                };
                _Ireport.Add(newReport);
                return query;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }
        #endregion
        #region getCountByDate
        public List<UserCount> getCountByDate(string reportName, string type, int userid)
        {
            var users = _Iuser.GetAll();
            var result = users
              .GroupBy(u => u.CreatedAt.Year)
              .Select(g => new UserCount
              {
                  year = g.Key,
                  Count = g.Count()
              })
              .ToList();
            var newReport = new Report
            {
                ReportName = reportName,
                ReportData = ConvertToCustomFormat(result, type),
                GeneratedAt = DateTime.Now,
                GeneratedByNavigationUserId = userid,
                GeneratedBy = users.Find(x => x.UserId == userid).Fname
            };
            _Ireport.Add(newReport);
            return result;
        }
        #endregion
        #region temp table
        public class SearchLogBorrowRequestDto
        {
            public int UserId { get; set; }
            public string SearchQuery { get; set; }
            public DateTime SearchDate { get; set; }
            public int RequestId { get; set; }
            public DateTime RequestDate { get; set; }
        }
        public class UserCount
        {
            public int Count { get; set; }
            public int year { get; set; }
        }
        #endregion
        #region ConvertToCustomFormat
        private string ConvertToCustomFormat(List<SearchLogBorrowRequestDto> query, string type1)
        {
            var sb = new System.Text.StringBuilder();
            foreach (var item in query)
            {
                sb.AppendLine($"UserId: {item.UserId},SearchQuery: {item.SearchQuery},SearchDate: {item.SearchDate},RequestId: {item.RequestId},RequestDate: {item.RequestDate},type: {type1}");
            }
            return sb.ToString();
        }
        private string ConvertToCustomFormat(List<UserCount> query, string type1)
        {
            var sb = new System.Text.StringBuilder();
            foreach (var item in query)
            {
                sb.AppendLine($"year: {item.year}, Count: {item.Count},type: {type1}");
            }
            return sb.ToString();
        }
        private string ConvertToCustomFormat(List<UserLoginReport> query, string type1)
        {
            var sb = new System.Text.StringBuilder();
            foreach (var item in query)
            {
                sb.AppendLine($"name: {item.UserName},lastName: {item.UserSurname},hour: {item.LoginTime.Value.TimeOfDay},type: {type1}");
            }
            return sb.ToString();
        }
        #endregion
        public List<UserActivityCount> GetActivityLogs(string reportName, string type, int userid)
        {
            try
            {
                var oneMonthAgo = DateTime.Now.AddMonths(-1);//תאריך הנוכחי
                var logs = _ISearchLogBll.getall();//שליפת החיפושים
                var users = _Iuser.GetAll();//שליפת המשתמשים
                var filteredLogs = logs.Where(log => log.SearchDate >= oneMonthAgo).ToList();//סינון רק אלא של החודש
                /////////////////////////////////////////////////////////
                var groupedLogs = filteredLogs
                    .Where(log => log.UserId != 0)
                    .GroupBy(log => log.UserId)
                    .ToList();
                //////////////////////////////////////////////////////////
                var result = groupedLogs
                    .Join(users,
                          logGroup => logGroup.Key,
                          user => user.UserId,
                          (logGroup, user) => new UserActivityCount
                          {
                              UserId1 = logGroup.Key,
                              ActivityCount = logGroup.Count(),
                              UserName = users.Find(x => x.UserId == logGroup.Key).Fname
                          })
                    .OrderByDescending(x => x.ActivityCount)
                    .ToList();
                ////////////////////יצירת הדוח////////////////////////////////
                var newReport = new Report
                {
                    ReportName = reportName,
                    ReportData = ConvertToCustomFormat(result, type),
                    GeneratedAt = DateTime.Now,
                    GeneratedByNavigationUserId = userid,
                    GeneratedBy = users.Find(x => x.UserId == userid).Fname


                };
                _Ireport.Add(newReport);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }

        public List<UserLoginReport> GetLoginActivityReport(DateTime loginDate, string reportName, string type, int userId)
        {
            try
            {
                var logs = _ActivityLogBll.getall();
                var users = _Iuser.GetAll();
                var filteredLogs = logs
                    .Where(log => log.Activity == "התחברות" && log.Timestamp.HasValue && log.Timestamp.Value.Date == loginDate.Date)
                    .ToList();

                var result = filteredLogs
                      .Join(users,
                            log => log.UserId1NavigationUserId,
                            user => user.UserId,
                            (log, user) => new UserLoginReport
                            {
                                UserName = user.Fname,
                                UserSurname = user.Sname,
                                LoginTime = log.Timestamp
                            })
                      .OrderByDescending(x => x.UserName)
                      .ToList();

                var newReport = new Report
                {
                    ReportName = reportName,
                    ReportData = ConvertToCustomFormat(result, type),
                    GeneratedAt = DateTime.Now,
                    GeneratedByNavigationUserId = userId,
                    GeneratedBy = users.Find(x => x.UserId == userId).Fname
                };

                _Ireport.Add(newReport);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }

        public class UserLoginReport
        {
            public string UserName { get; set; }
            public string UserSurname { get; set; }
            public DateTime? LoginTime { get; set; }
        }

        private string ConvertToCustomFormat(List<UserActivityCount> result, string type)
        {
            // כאן אפשר להמיר את הרשימה לפורמט טקסטואלי לפי הצורך שלך
            // לדוגמה, אפשר להשתמש ב-StringBuilder כדי ליצור פורמט מותאם אישית
            var sb = new System.Text.StringBuilder();
            foreach (var item in result)
            {
                sb.AppendLine($"UserName: {item.UserName}, ActivityCount: {item.ActivityCount},type:{type}");
            }
            return sb.ToString();
        }
    }
}