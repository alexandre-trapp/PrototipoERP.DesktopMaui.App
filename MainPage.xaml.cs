﻿using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace PrototipoERP.DesktopMaui
{
	public partial class MainPage : ContentPage
	{ 
		public MainPage()
		{
			InitializeComponent();
		}

		private void OnLoginClicked(object sender, EventArgs e)
		{
			Console.WriteLine("ronaldo");
			//SemanticScreenReader.Announce(CounterLabel.Text);
		}
	}
}
