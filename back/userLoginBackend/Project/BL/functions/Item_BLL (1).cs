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
    public class Item : IItem_bll
    {
        Iitem Iitem;
        IMapper _mapper;
        public Item(Iitem iitem, IMapper mapper)
        {
            Iitem = iitem;
            _mapper = mapper;
        }
        public List<Item_bll> GetAll()
        {
            List<DAL.models.Item> myitem = Iitem.GetAll();
            return _mapper.Map<List<Item_bll>>(myitem);
        }

    }
}
