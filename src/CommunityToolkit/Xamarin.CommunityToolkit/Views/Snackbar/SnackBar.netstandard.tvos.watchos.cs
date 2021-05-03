using System;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views.Options;
using Microsoft.Maui; using Microsoft.Maui.Controls;

namespace Xamarin.CommunityToolkit.UI.Views
{
	class SnackBar
	{
		internal ValueTask Show(Page sender, SnackBarOptions arguments) => throw new PlatformNotSupportedException();
	}
}