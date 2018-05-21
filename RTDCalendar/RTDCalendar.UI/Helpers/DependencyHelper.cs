using System;
using Windows.UI.Xaml;

namespace RTDCalendar.UI.Helpers
{
	public static class DependencyHelper
	{
		public static DependencyProperty Register<T, TOwner>(string name, T value = default(T), Action<TOwner> propertyChanged = null) where TOwner : DependencyObject =>
            DependencyProperty.Register(name, typeof(T), typeof(TOwner),new PropertyMetadata(value, (o, args) => propertyChanged?.Invoke((TOwner) o)));

		public static DependencyProperty Register<T, TOwner>(string name,  Action<TOwner> propertyChanged ) where TOwner : DependencyObject =>
            Register(name, default(T), propertyChanged);
	}
}
