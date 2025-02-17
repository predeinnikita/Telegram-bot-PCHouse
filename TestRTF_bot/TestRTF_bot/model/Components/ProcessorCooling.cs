﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRTF_bot.Models.Accessories
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
        public int CoolerWidth { get; set; } // до видеокарты и радиатора питальника процессора       НЕ ЮЗАЕМ
        public int CoolerLength { get; set; } // до слотов ОЗУ         НЕ ЮЗАЕМ

        public bool IsCompatible(IComponent otherComponent)
        {
            if (otherComponent is Case computerCase)
                return computerCase.IsCompatible(this);
            if (otherComponent is Motherboard motherboard)
                return motherboard.IsCompatible(this);
            return true;
        }
    }
}
