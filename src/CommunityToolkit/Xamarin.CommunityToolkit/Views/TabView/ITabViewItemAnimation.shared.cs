using System.Threading.Tasks;
using Microsoft.Maui; 
using Microsoft.Maui.Controls;

namespace Xamarin.CommunityToolkit.UI.Views
{
	public interface ITabViewItemAnimation
	{
		Task OnSelected(View tabViewItem);

		Task OnDeSelected(View tabViewItem);
	}
}