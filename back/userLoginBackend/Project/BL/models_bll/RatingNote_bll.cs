using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.models_bll
{
    public class RatingNote_bll
    {
        public int RatingNoteId { get; set; }

        public int UserId { get; set; }

        public int? ItemId { get; set; }

        public string Note { get; set; }

        public int? Rating { get; set; }
    }
}
