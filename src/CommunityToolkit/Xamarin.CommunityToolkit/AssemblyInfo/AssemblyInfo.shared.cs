﻿using System.Runtime.CompilerServices;
using Microsoft.Maui; 
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Internals;

[assembly: InternalsVisibleTo("Xamarin.CommunityToolkit.UnitTests")]

#if !NETSTANDARD1_0
[assembly: XmlnsDefinition("http://xamarin.com/schemas/2020/toolkit", "Xamarin.CommunityToolkit.Behaviors")]
[assembly: XmlnsDefinition("http://xamarin.com/schemas/2020/toolkit", "Xamarin.CommunityToolkit.Converters")]
[assembly: XmlnsDefinition("http://xamarin.com/schemas/2020/toolkit", "Xamarin.CommunityToolkit.Effects")]
[assembly: XmlnsDefinition("http://xamarin.com/schemas/2020/toolkit", "Xamarin.CommunityToolkit.Extensions")]
[assembly: XmlnsDefinition("http://xamarin.com/schemas/2020/toolkit", "Xamarin.CommunityToolkit.UI.Views")]
#endif