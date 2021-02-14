﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Car : IEntities
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string Name { get; set; }
        public int ColorId { get; set; }
        public string ModelYear { get; set; }
        public float DailyPrice { get; set; }
       
        
    }
}
