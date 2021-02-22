using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BusinessManager>().As<IBusiness>();

            builder.RegisterType<RentManager>().As<IRent>();
            
            builder.RegisterType<EfCarDal>().As<ICarDal>();
            
            builder.RegisterType<EfRentDal>().As<IRentDal>();
        }
    }
}
