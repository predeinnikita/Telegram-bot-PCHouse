﻿using DataBaseComponentFiller.Model.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseComponentFiller.Model.Components
{
    class ProcessorCooling : IComponent
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Rating { get; set; }
        public string Socket { get; set; }
        public string Power { get; set; }
        public int CoolerHeight { get; set; } // до стенки корпуса
        public int CoolerWidth { get; set; } // до видеокарты и радиатора питальника процессора
        public int CoolerLength { get; set; } // до слотов ОЗУ 

        public bool IsCompatible(IComponent otherComponent)
        {
            throw new NotImplementedException();
        }
    }
}
