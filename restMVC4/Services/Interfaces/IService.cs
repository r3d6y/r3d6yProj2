using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restMVC4.Services.Interfaces
{
    public interface IService
    {
        IClientService ClientService { get; }
        IRestaurantService RestService { get; }
        IDishService DishService { get; }
    }
}