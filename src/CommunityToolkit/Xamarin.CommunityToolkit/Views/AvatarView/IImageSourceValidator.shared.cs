using System.Threading.Tasks;
using Microsoft.Maui; 
using Microsoft.Maui.Controls;

namespace Xamarin.CommunityToolkit.UI.Views
{
	interface IImageSourceValidator
	{
		Task<bool> IsImageSourceValidAsync(ImageSource? source);
	}
}