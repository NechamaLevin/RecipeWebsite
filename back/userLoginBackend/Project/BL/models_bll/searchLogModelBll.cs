using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BLL.models_bll
{
    public class searchLogModelBll
    {
        public int LogId { get; set; }
        public int UserId { get; set; }
        public string SearchQuery { get; set; }
        public DateTime SearchDate { get; set; }
    }
}
