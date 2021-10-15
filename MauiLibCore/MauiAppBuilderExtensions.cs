using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Maui;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Hosting;

namespace MauiLib
{
    public static class MauiAppBuilderExtensions
    {
        public static MauiAppBuilder UseMauiLib(this MauiAppBuilder builder)
        {
            // hack to disable all background operations on the elements we control
            ButtonHandler.Mapper.Add(nameof(IView.Background), delegate { });
            EntryHandler.EntryMapper.Add(nameof(IView.Background), delegate { });

            // register the initializer
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IMauiInitializeService, MauiLibHandlers.Initializer>());

            return builder;
        }
    }
}