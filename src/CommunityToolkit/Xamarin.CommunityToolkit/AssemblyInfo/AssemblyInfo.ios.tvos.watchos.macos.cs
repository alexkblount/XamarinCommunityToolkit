using Foundation;
using Xamarin.CommunityToolkit.UI.Views;
using Microsoft.Maui; using Microsoft.Maui.Controls;

[assembly: LinkerSafe]

#if XAMARIN_IOS || XAMARIN_MAC
[assembly: ExportImageSourceHandler(typeof(GravatarImageSource), typeof(GravatarImageSourceHandler))]
#endif