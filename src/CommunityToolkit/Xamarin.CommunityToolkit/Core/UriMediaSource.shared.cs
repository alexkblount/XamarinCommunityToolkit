using System;
using Microsoft.Maui; using Microsoft.Maui.Controls;

namespace Xamarin.CommunityToolkit.Core
{
	public sealed class UriMediaSource : MediaSource
	{
		public static readonly BindableProperty UriProperty =
			BindableProperty.Create(nameof(Uri), typeof(Uri), typeof(UriMediaSource), propertyChanged: OnUriSourceChanged, validateValue: UriValueValidator);

		static bool UriValueValidator(BindableObject bindable, object value) =>
			value == null || ((Uri)value).IsAbsoluteUri;

		static void OnUriSourceChanged(BindableObject bindable, object oldValue, object newValue) =>
			((UriMediaSource)bindable).OnSourceChanged();

		[TypeConverter(typeof(Microsoft.MauiUriTypeConverter))]
		public Uri? Uri
		{
			get => (Uri?)GetValue(UriProperty);
			set => SetValue(UriProperty, value);
		}

		public override string ToString() => $"Uri: {Uri}";
	}
}