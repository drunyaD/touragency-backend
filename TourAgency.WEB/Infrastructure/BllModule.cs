﻿using Ninject.Modules;
using TourAgency.BLL.Interfaces;
using TourAgency.BLL.Services;

namespace TourAgency.WEB.Infrastructure
{
    public class BllModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<ITourService>().To<TourService>();
        }
    }
}