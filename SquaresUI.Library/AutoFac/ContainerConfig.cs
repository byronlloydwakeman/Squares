using Autofac;
using SquaresUI.Library.API;
using SquaresUI.Library.API.Endpoints;
using SquaresUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresUI.Library.AutoFac
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<APIHelper>().As<IAPIHelper>();
            builder.RegisterType<HighScoreEndpoint>().As<IHighScoreEndpoint>();
            builder.RegisterType<AuthenticatedUser>().As<IAuthenticatedUser>().SingleInstance();

            return builder.Build();
        }
    }
}
