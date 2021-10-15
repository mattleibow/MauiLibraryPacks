using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using System;
using System.Collections.Generic;

namespace MauiLib
{
    // the internal mechanism for getting access to the handler collection
    static class MauiLibHandlers
    {
        static IMauiHandlersCollection HandlersCollection;
        static readonly Dictionary<Type, Type> PendingHandlers = new();

        // the method to use to register handlers on-demand
        public static void TryAddHandler<TType, TTypeRender>()
            where TType : IView
            where TTypeRender : IViewHandler
        {
            if (HandlersCollection == null)
                PendingHandlers[typeof(TType)] = typeof(TTypeRender);
            else
                HandlersCollection.TryAddHandler<TType, TTypeRender>();
        }

        // a simple initializer that runs when the app is ready
        internal class Initializer : IMauiInitializeService
        {
            public void Initialize(IServiceProvider services)
            {
                // retrieve the collection for later
                HandlersCollection ??= services.GetRequiredService<IMauiHandlersServiceProvider>().GetCollection();

                // if any were added prior to app startup, register them now
                if (PendingHandlers.Count > 0)
                {
                    HandlersCollection.TryAddHandlers(PendingHandlers);
                    PendingHandlers.Clear();
                }
            }
        }
    }
}