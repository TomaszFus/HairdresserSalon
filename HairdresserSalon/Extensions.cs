using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon
{
    public static class Extensions
    {
        public static IConveyBuilder AddApplication(this IConveyBuilder builder)
        {
            builder
                .AddCommandHandlers()
                .AddInMemoryCommandDispatcher()
                .AddQueryHandlers()
                .AddInMemoryQueryDispatcher();

            return builder;
        }
    }
}
