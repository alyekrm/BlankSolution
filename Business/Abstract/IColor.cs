using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColor
    {
        List<Color> GetAll();

        Color GetById(int colorId);
    }
}
