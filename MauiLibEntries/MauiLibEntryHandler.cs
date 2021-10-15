using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Handlers;

namespace MauiLib
{
    // This is a dummy handler.
    //
    // This type inherits from EntryHandler to give the illusion of a complet handler
    // but really should just be inserting the new property via the mappers.
    public class MauiLibEntryHandler : EntryHandler
    {
        public static IPropertyMapper<IMauiLibEntry, EntryHandler> Mapper = new PropertyMapper<IMauiLibEntry, EntryHandler>(EntryMapper)
        {
            [nameof(IMauiLibEntry.IsHappy)] = MapIsHappy
        };

        public MauiLibEntryHandler()
            : base(Mapper)
        {
        }

        private static void MapIsHappy(EntryHandler handler, IMauiLibEntry entry)
        {
            var color = entry.IsHappy
                ? Colors.Green
                : Colors.Red;

#if WINDOWS
            handler.NativeView.Background = color.ToNative();
#endif
        }
    }
}