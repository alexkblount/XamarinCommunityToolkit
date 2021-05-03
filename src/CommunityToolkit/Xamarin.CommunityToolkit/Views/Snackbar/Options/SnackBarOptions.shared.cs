using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui; using Microsoft.Maui.Controls;

namespace Xamarin.CommunityToolkit.UI.Views.Options
{
	public class SnackBarOptions : ToastOptions
	{
		/// <summary>
		/// Action options
		/// </summary>
		public IEnumerable<SnackBarActionOptions> Actions { get; set; } = DefaultActions;

		public static IEnumerable<SnackBarActionOptions> DefaultActions { get; set; } = Enumerable.Empty<SnackBarActionOptions>();
	}
}