using BLL.models_bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.interfaces
{
    public interface IItem_bll
    {
        public List<Item_bll> GetAll();
    }
}
