using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Maui; using Microsoft.Maui.Controls;

namespace Xamarin.CommunityToolkit.Markup
{
	public static class DefaultBindableProperties
	{
		static Dictionary<string, BindableProperty> bindableObjectTypeDefaultProperty = new Dictionary<string, BindableProperty>
		{ // Key: full type name of BindableObject, Value: the default BindableProperty
		  // Note that we don't specify default properties for unconstructed generic types
			{ "Microsoft.MauiActivityIndicator", ActivityIndicator.IsRunningProperty },
			{ "Microsoft.MauiBackButtonBehavior", BackButtonBehavior.CommandProperty },
			{ "Microsoft.MauiBoxView", BoxView.ColorProperty },
			{ "Microsoft.MauiButton", Button.CommandProperty },
			{ "Microsoft.MauiCarouselPage", Page.TitleProperty },
			{ "Microsoft.MauiCheckBox", CheckBox.IsCheckedProperty },
			{ "Microsoft.MauiClickGestureRecognizer", ClickGestureRecognizer.CommandProperty },
			{ "Microsoft.MauiCollectionView", CollectionView.ItemsSourceProperty },
			{ "Microsoft.MauiContentPage", Page.TitleProperty },
			{ "Microsoft.MauiDatePicker", DatePicker.DateProperty },
			{ "Microsoft.MauiEditor", Editor.TextProperty },
			{ "Microsoft.MauiEntry", Entry.TextProperty },
			{ "Microsoft.MauiEntryCell", EntryCell.TextProperty },
			{ "Microsoft.MauiFileImageSource", FileImageSource.FileProperty },
			{ "Microsoft.MauiFlyoutPage", FlyoutPage.IsPresentedProperty },
			{ "Microsoft.MauiHtmlWebViewSource", HtmlWebViewSource.HtmlProperty },
			{ "Microsoft.MauiImage", Image.SourceProperty },
			{ "Microsoft.MauiImageButton", ImageButton.CommandProperty },
			{ "Microsoft.MauiImageCell", ImageCell.ImageSourceProperty },
			{ "Microsoft.MauiItemsView", ItemsView.ItemsSourceProperty },
			{ "Microsoft.MauiLabel", Label.TextProperty },
			{ "Microsoft.MauiListView", ListView.ItemsSourceProperty },
			{ "Microsoft.MauiMasterDetailPage", Page.TitleProperty },
			{ "Microsoft.MauiMenuItem", MenuItem.CommandProperty },
			{ "Microsoft.MauiMultiPage", Page.TitleProperty },
			{ "Microsoft.MauiNavigationPage", Page.TitleProperty },
			{ "Microsoft.MauiPage", Page.TitleProperty },
			{ "Microsoft.MauiPicker", Picker.SelectedIndexProperty },
			{ "Microsoft.MauiProgressBar", ProgressBar.ProgressProperty },
			{ "Microsoft.MauiRadioButton", RadioButton.IsCheckedProperty },
			{ "Microsoft.MauiRefreshView", RefreshView.CommandProperty },
			{ "Microsoft.MauiSearchBar", SearchBar.SearchCommandProperty },
			{ "Microsoft.MauiSearchHandler", SearchHandler.CommandProperty },
			{ "Microsoft.MauiSlider", Slider.ValueProperty },
			{ "Microsoft.MauiSolidColorBrush", SolidColorBrush.ColorProperty },
			{ "Microsoft.MauiSpan", Span.TextProperty },
			{ "Microsoft.MauiStepper", Stepper.ValueProperty },
			{ "Microsoft.MauiStreamImageSource", StreamImageSource.StreamProperty },
			{ "Microsoft.MauiSwipeGestureRecognizer", SwipeGestureRecognizer.CommandProperty },
			{ "Microsoft.MauiSwipeItem", SwipeItem.CommandProperty },
			{ "Microsoft.MauiSwitch", Switch.IsToggledProperty },
			{ "Microsoft.MauiSwitchCell", SwitchCell.OnProperty },
			{ "Microsoft.MauiTabbedPage", Page.TitleProperty },
			{ "Microsoft.MauiTableRoot", TableRoot.TitleProperty },
			{ "Microsoft.MauiTableSection", TableSection.TitleProperty },
			{ "Microsoft.MauiTableSectionBase", TableSectionBase.TitleProperty },
			{ "Microsoft.MauiTapGestureRecognizer", TapGestureRecognizer.CommandProperty },
			{ "Microsoft.MauiTemplatedPage", Page.TitleProperty },
			{ "Microsoft.MauiTextCell", TextCell.TextProperty },
			{ "Microsoft.MauiTimePicker", TimePicker.TimeProperty },
			{ "Microsoft.MauiToolbarItem", ToolbarItem.CommandProperty },
			{ "Microsoft.MauiUriImageSource", UriImageSource.UriProperty },
			{ "Microsoft.MauiUrlWebViewSource", UrlWebViewSource.UrlProperty },
			{ "Microsoft.MauiWebView", WebView.SourceProperty }
		};

		static Dictionary<string, (BindableProperty, BindableProperty)> bindableObjectTypeDefaultCommandAndParameterProperties = new Dictionary<string, (BindableProperty, BindableProperty)>
		{ // Key: full type name of BindableObject, Value: command property and corresponding commandParameter property
			{ "Microsoft.MauiButton", (Button.CommandProperty, Button.CommandParameterProperty) },
			{ "Microsoft.MauiTextCell", (TextCell.CommandProperty, TextCell.CommandParameterProperty) },
			{ "Microsoft.MauiClickGestureRecognizer", (ClickGestureRecognizer.CommandProperty, ClickGestureRecognizer.CommandParameterProperty) },
			{ "Microsoft.MauiImageButton", (ImageButton.CommandProperty, ImageButton.CommandParameterProperty) },
			{ "Microsoft.MauiMenuItem", (MenuItem.CommandProperty, MenuItem.CommandParameterProperty) },
			{ "Microsoft.MauiRefreshView", (RefreshView.CommandProperty, RefreshView.CommandParameterProperty) },
			{ "Microsoft.MauiSwipeGestureRecognizer", (SwipeGestureRecognizer.CommandProperty, SwipeGestureRecognizer.CommandParameterProperty) },
			{ "Microsoft.MauiSwipeItemView", (SwipeItemView.CommandProperty, SwipeItemView.CommandParameterProperty) },
			{ "Microsoft.MauiTapGestureRecognizer", (TapGestureRecognizer.CommandProperty, TapGestureRecognizer.CommandParameterProperty) }
		};

		public static void Register(params BindableProperty[] properties)
		{
			foreach (var property in properties)
				bindableObjectTypeDefaultProperty.Add(property.DeclaringType.FullName, property);
		}

		public static void RegisterForCommand(params (BindableProperty commandProperty, BindableProperty parameterProperty)[] propertyPairs)
		{
			foreach (var propertyPair in propertyPairs)
				bindableObjectTypeDefaultCommandAndParameterProperties.Add(propertyPair.commandProperty.DeclaringType.FullName, propertyPair);
		}

		internal static void Unregister(BindableProperty property)
			=> bindableObjectTypeDefaultProperty.Remove(property.DeclaringType.FullName);

		internal static BindableProperty GetFor(BindableObject bindableObject)
		{
			var type = bindableObject.GetType();
			var defaultProperty = GetFor(type);
			if (defaultProperty == null)
			{
				throw new ArgumentException(
					"No default bindable property is registered for BindableObject type " + type.FullName +
					"\r\nEither specify a property when calling Bind() or register a default bindable property for this BindableObject type");
			}

			return defaultProperty;
		}

		internal static BindableProperty GetFor(Type bindableObjectType)
		{
			BindableProperty defaultProperty;

			do
			{
				string bindableObjectTypeName = bindableObjectType.FullName;
				if (bindableObjectTypeDefaultProperty.TryGetValue(bindableObjectTypeName, out defaultProperty))
					break;
				if (bindableObjectTypeName.StartsWith("Microsoft.Maui", StringComparison.Ordinal))
					break;

				bindableObjectType = bindableObjectType.GetTypeInfo().BaseType;
			}
            while (bindableObjectType != null);

			return defaultProperty;
		}

		internal static void UnregisterForCommand(BindableProperty commandProperty)
			=> bindableObjectTypeDefaultCommandAndParameterProperties.Remove(commandProperty.DeclaringType.FullName);

		internal static (BindableProperty, BindableProperty) GetForCommand(BindableObject bindableObject)
		{
			var type = bindableObject.GetType();
			(var commandProperty, var parameterProperty) = GetForCommand(type);
			if (commandProperty == null)
			{
				throw new ArgumentException(
					"No command + command parameter properties are registered for BindableObject type " + type.FullName +
					"\r\nRegister command + command parameter properties for this BindableObject type");
			}

			return (commandProperty, parameterProperty);
		}

		internal static (BindableProperty, BindableProperty) GetForCommand(Type bindableObjectType)
		{
			(BindableProperty, BindableProperty) commandAndParameterProperties;

			do
			{
				string bindableObjectTypeName = bindableObjectType.FullName;
				if (bindableObjectTypeDefaultCommandAndParameterProperties.TryGetValue(bindableObjectTypeName, out commandAndParameterProperties))
					break;
				if (bindableObjectTypeName.StartsWith("Microsoft.Maui", StringComparison.Ordinal))
					break;

				bindableObjectType = bindableObjectType.GetTypeInfo().BaseType;
			}
            while (bindableObjectType != null);

			return commandAndParameterProperties;
		}
	}
}
