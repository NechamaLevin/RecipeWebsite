using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.models_bll
{
    public class Item_bll
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string FilePath { get; set; }

        public bool IsApproved { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int PublishingYear { get; set; }

        public string Edition { get; set; }

        public string Series { get; set; }

        public int NumOfSeries { get; set; }

        public string Language { get; set; }

        public string Note { get; set; }

        public string? AccompanyingMaterial { get; set; }

        public int ItemLevel { get; set; }

        public string HebrewPublicationYear { get; set; }

        public int NumberOfDaysOfQuestion { get; set; }

        public bool? Recommended { get; set; }



        

    }
}
