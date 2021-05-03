using Android.Content;
using Android.Views;
using Xamarin.CommunityToolkit.UI.Views;
using Microsoft.Maui; using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility.Platform.Android.FastRenderers;
using Microsoft.Maui.Controls.Compatibility;

[assembly: ExportRenderer(typeof(ThumbFrame), typeof(ThumbFrameRenderer))]

namespace Xamarin.CommunityToolkit.UI.Views
{
	sealed class ThumbFrameRenderer : FrameRenderer
	{
		public ThumbFrameRenderer(Context context)
			: base(context)
		{
		}

		public override bool OnTouchEvent(MotionEvent e)
		{
			switch (e.ActionMasked)
			{
				case MotionEventActions.Down:
					Parent?.RequestDisallowInterceptTouchEvent(true);
					break;
				case MotionEventActions.Up:
				case MotionEventActions.Cancel:
					Parent?.RequestDisallowInterceptTouchEvent(false);
					break;
			}
			return base.OnTouchEvent(e);
		}
	}
}