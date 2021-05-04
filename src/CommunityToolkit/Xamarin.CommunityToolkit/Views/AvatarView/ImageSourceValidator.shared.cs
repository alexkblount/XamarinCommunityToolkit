using System.Threading.Tasks;
using Microsoft.Maui; 
using Microsoft.Maui.Controls;

namespace Xamarin.CommunityToolkit.UI.Views
{
#if NETSTANDARD || __TVOS__ || __WATCHOS__
	class ImageSourceValidator : IImageSourceValidator
	{
		public Task<bool> IsImageSourceValidAsync(ImageSource? source) => Task.FromResult(false);
	}
#endif
}