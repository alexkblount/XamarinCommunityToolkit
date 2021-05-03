using System.Threading.Tasks;
using Microsoft.Maui; using Microsoft.Maui.Controls;

namespace Xamarin.CommunityToolkit.Behaviors
{
	public class FlipVerticalAnimation : RotateAnimation
	{
		protected override double DefaultRotation { get; set; } = 90;

		public override async Task Animate(View? view)
		{
			if (view != null)
			{
				await view.RotateXTo(Rotation, Duration, Easing);
				await view.RotateXTo(0, Duration, Easing);
			}
		}
	}
}