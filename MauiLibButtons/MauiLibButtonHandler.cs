using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Handlers;

namespace MauiLib
{
    // This is a dummy handler.
    //
    // This type inherits from ButtonHandler to give the illusion of a complet handler
    // but really should just be inserting the new property via the mappers.
    public class MauiLibButtonHandler : ButtonHandler
    {
        public static IPropertyMapper<IMauiLibButton, ButtonHandler> Mapper =
            new PropertyMapper<IMauiLibButton, ButtonHandler>(ButtonHandler.Mapper)
            {
                [nameof(IMauiLibButton.IsHappy)] = MapIsHappy
            };

        public MauiLibButtonHandler()
            : base(Mapper)
        {
        }

        private static void MapIsHappy(ButtonHandler handler, IMauiLibButton Button)
        {
            var color = Button.IsHappy
                ? Colors.Green
                : Colors.Red;

#if WINDOWS
            handler.NativeView.Background = color.ToNative();
#endif
        }
    }
}