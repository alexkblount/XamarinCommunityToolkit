using System.IO;
using System.Threading.Tasks;
using Microsoft.Maui; using Microsoft.Maui.Controls;

#if MONOANDROID
using Microsoft.Maui.Platform.Android;
using UriImageSourceHandler = Microsoft.MauiPlatform.Android.ImageLoaderSourceHandler;
using StreamImageSourceHandler = Microsoft.MauiPlatform.Android.StreamImagesourceHandler;
#elif __IOS__
using Microsoft.Maui.Platform.iOS;
using UriImageSourceHandler = Microsoft.MauiPlatform.iOS.ImageLoaderSourceHandler;
using StreamImageSourceHandler = Microsoft.MauiPlatform.iOS.StreamImagesourceHandler;
#elif __MACOS__
using Microsoft.Maui.Platform.MacOS;
using UriImageSourceHandler = Microsoft.MauiPlatform.MacOS.ImageLoaderSourceHandler;
using StreamImageSourceHandler = Microsoft.MauiPlatform.MacOS.StreamImagesourceHandler;
#elif UWP
using Microsoft.Maui.Platform.UWP;
#elif NET471
using Microsoft.Maui.Platform.GTK.Renderers;
using StreamImageSourceHandler = Microsoft.MauiPlatform.GTK.Renderers.StreamImagesourceHandler;
#elif TIZEN
using Microsoft.Maui.Platform.Tizen;
using NImage = Microsoft.MauiPlatform.Tizen.Native.Image;
using XForms = Microsoft.MauiForms;
#else
using Microsoft.Maui.Platform.WPF;
#endif

namespace Xamarin.CommunityToolkit.UI.Views
{
	class ImageSourceValidator : IImageSourceValidator
	{
		public async Task<bool> IsImageSourceValidAsync(ImageSource? source)
		{
			var handler = GetHandler(source);
			if (handler == null)
				return false;

#if TIZEN
			return await handler.LoadImageAsync(new NImage(XForms.NativeParent), source).ConfigureAwait(false);
#elif MONOANDROID
			var imageSource = await handler.LoadImageAsync(source, ToolkitPlatform.Context).ConfigureAwait(false);
			return imageSource != null;
#else
			var imageSource = await handler.LoadImageAsync(source).ConfigureAwait(false);
			return imageSource != null;
#endif
		}

		IImageSourceHandler? GetHandler(ImageSource? source)
		{
			if (source is UriImageSource)
				return new UriImageSourceHandler();

			if (source is StreamImageSource)
				return new StreamImageSourceHandler();

#if !NET471
			if (source is GravatarImageSource)
				return new GravatarImageSourceHandler();
#endif

#if !TIZEN
			if (source is FontImageSource)
				return new FontImageSourceHandler();
#endif

			if (source is FileImageSource fileSource)
			{
#if !MONOANDROID
				if (!File.Exists(fileSource.File))
					return null;
#endif
				return new FileImageSourceHandler();
			}

			return null;
		}
	}
}