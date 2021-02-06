using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Abstract
{
    public interface IEntities
    {

        int Id { get; set; }

        string BrandId { get; set; }

        string ColorId { get; set; }

        string ModelYear { get; set; }

        double DailyPrice { get; set; }

        string Description { get; set; }

    }
}
