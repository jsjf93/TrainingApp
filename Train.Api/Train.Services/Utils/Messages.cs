using System;
using System.Collections.Generic;
using System.Text;
using Train.Data;
using Train.Services.CommandHandlers.Interfaces;
using Train.Services.Commands.Interfaces;
using Train.Services.Queries.Interfaces;
using Train.Services.QueryProcessors.Interfaces;

namespace Train.Services.Utils
{
    public sealed class Messages
    {
        private readonly IServiceProvider provider;

        public Messages(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public void Dispatch(ICommand command)
        {
            Type type = typeof(ICommandHandler<>);
            Type[] typeArgs = { command.GetType() };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = this.provider.GetService(handlerType);
            handler.Execute((dynamic)command);
        }

        public T Dispatch<T>(IQuery<T> query)
        {
            Type type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = this.provider.GetService(handlerType);
            T result = handler.Handle((dynamic)query);

            return result;
        }
    }
}
