using Microsoft.Maui.Controls;

namespace MauiLib
{
    public class MauiLibEntry : Entry, IMauiLibEntry
    {
        static MauiLibEntry()
        {
            // register the hander on first use
            MauiLibHandlers.TryAddHandler<MauiLibEntry, MauiLibEntryHandler>();
        }

        public static readonly BindableProperty IsHappyProperty = BindableProperty.Create(
            nameof(IsHappy), typeof(bool), typeof(MauiLibEntry), false);

        public bool IsHappy
        {
            get => (bool)GetValue(IsHappyProperty);
            set => SetValue(IsHappyProperty, value);
        }
    }
}