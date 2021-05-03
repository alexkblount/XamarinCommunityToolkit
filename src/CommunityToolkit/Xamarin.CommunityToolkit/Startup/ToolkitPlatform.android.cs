using System;
using Android.Content;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;

namespace Xamarin.CommunityToolkit
{
	/// <summary>
	/// Platform extension methods.
	/// </summary>
	static class ToolkitPlatform
	{
		/// <summary>
		/// Gets the <see cref="Context"/>.
		/// </summary>
		internal static Context Context
		{
			get
			{
				var page = Microsoft.Maui.Controls.Application.Current.MainPage;
				var renderer = page.GetRenderer();
				return renderer.View.Context ?? throw new NullReferenceException($"{nameof(Context)} cannot be null");
			}
		}
	}
}