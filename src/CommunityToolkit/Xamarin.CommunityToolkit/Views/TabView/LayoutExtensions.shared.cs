using System;
using System.Collections.Generic;
using Microsoft.Maui; using Microsoft.Maui.Controls;

namespace Xamarin.CommunityToolkit.UI.Views
{
	public static class LayoutExtensions
	{
		public static IReadOnlyList<Element> GetChildren(this ILayoutController source)
		{
			_ = source ?? throw new ArgumentNullException(nameof(source));

			return source.Children;
		}
	}
}