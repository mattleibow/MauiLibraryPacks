using Microsoft.Maui.Controls;

namespace MauiLib
{
    public class MauiLibButton : Button, IMauiLibButton
    {
        static MauiLibButton()
        {
            // register the hander on first use
            MauiLibHandlers.TryAddHandler<MauiLibButton, MauiLibButtonHandler>();
        }

        public static readonly BindableProperty IsHappyProperty = BindableProperty.Create(
            nameof(IsHappy), typeof(bool), typeof(MauiLibButton), false);

        public bool IsHappy
        {
            get => (bool)GetValue(IsHappyProperty);
            set => SetValue(IsHappyProperty, value);
        }
    }
}