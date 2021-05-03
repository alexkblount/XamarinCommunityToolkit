using System;
using Microsoft.Maui; using Microsoft.Maui.Controls;

namespace Xamarin.CommunityToolkit.ObjectModel
{
	/// <summary>
	/// Factory for Microsoft.MauiCommand
	/// </summary>
	public static partial class CommandFactory
	{
		/// <summary>
		/// Initializes Microsoft.MauiCommand
		/// </summary>
		/// <param name="execute">The Function executed when Execute is called. This does not check canExecute before executing and will execute even if canExecute is false</param>
		/// <returns>Microsoft.MauiCommand</returns>
		public static Command Create(Action execute) =>
			new Command(execute);

		/// <summary>
		/// Initializes Microsoft.MauiCommand
		/// </summary>
		/// <param name="execute">The Function executed when Execute is called. This does not check canExecute before executing and will execute even if canExecute is false</param>
		/// <returns>Microsoft.MauiCommand</returns>
		public static Command Create(Action execute, Func<bool> canExecute) =>
			new Command(execute, canExecute);

		/// <summary>
		/// Initializes Microsoft.MauiCommand
		/// </summary>
		/// <param name="execute">The Function executed when Execute is called. This does not check canExecute before executing and will execute even if canExecute is false</param>
		/// <returns>Microsoft.MauiCommand</returns>
		public static Command Create(Action<object> execute) =>
			new Command(execute);

		/// <summary>
		/// Initializes Microsoft.MauiCommand
		/// </summary>
		/// <param name="execute">The Function executed when Execute is called. This does not check canExecute before executing and will execute even if canExecute is false</param>
		/// <returns>Microsoft.MauiCommand</returns>
		public static Command Create(Action<object> execute, Func<object, bool> canExecute) =>
			new Command(execute, canExecute);

		/// <summary>
		/// Initializes Microsoft.MauiCommand<typeparamref name="T"/>
		/// </summary>
		/// <param name="execute">The Function executed when Execute is called. This does not check canExecute before executing and will execute even if canExecute is false</param>
		/// <returns>Microsoft.MauiCommand<typeparamref name="T"/></returns>
		public static Command<T> Create<T>(Action<T> execute) =>
			new Command<T>(execute);

		/// <summary>
		/// Initializes Microsoft.MauiCommand<typeparamref name="T"/>
		/// </summary>
		/// <param name="execute">The Function executed when Execute is called. This does not check canExecute before executing and will execute even if canExecute is false</param>
		/// <returns>Microsoft.MauiCommand<typeparamref name="T"/></returns>
		public static Command<T> Create<T>(Action<T> execute, Func<T, bool> canExecute) =>
			new Command<T>(execute, canExecute);
	}
}