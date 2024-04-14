using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;

namespace VTZ.Domain.Entities
{
    public class Task
    {
        [Key]
        public int DocumentId { get; set; }

        [Display(Name = "Название документа")]
        public string DocumentName { get; set; }

        [Display(Name = "СТО")]
        public bool STO { get; set; }

        [Display(Name = "СПБИ")]
        public bool SPBI { get; set; }

        [Display(Name = "МПИ")]
        public bool MPI { get; set; }

        [Display(Name = "НПИ")]
        public bool NPI { get; set; }

        [Display(Name = "На стадии проектирования")]
        public bool OnStagePD { get; set; }

        [Display(Name = "На стадии разработки")]
        public bool OnStageRD { get; set; }

        [Display(Name = "Тип документа")]
        public string DocTP { get; set; }

        [Display(Name = "Тип документа")]
        public string DocRD { get; set; }

        [Display(Name = "Номер документа")]
        public string DocNo { get; set; }
    }
}

