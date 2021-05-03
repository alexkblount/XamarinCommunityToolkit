using Android.Widget;
using Xamarin.CommunityToolkit.Effects;
using Microsoft.Maui; using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Effects = Xamarin.CommunityToolkit.Android.Effects;

[assembly: ExportEffect(typeof(Effects.SelectAllTextEffect), nameof(SelectAllTextEffect))]

namespace Xamarin.CommunityToolkit.Android.Effects
{
	public class SelectAllTextEffect : PlatformEffect
	{
		EditText EditText => (EditText)Control;

		protected override void OnAttached()
			=> EditText?.SetSelectAllOnFocus(true);

		protected override void OnDetached()
			=> EditText?.SetSelectAllOnFocus(false);
	}
}