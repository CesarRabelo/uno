using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Uno.UI.Samples.Controls;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UITests.Shared.Windows_UI_Xaml_Controls.TextBoxControl
{
	[SampleControlInfo("TextBox", description: "Demonstrates of SelectedText")]
	public sealed partial class TextBox_And_SelectedText : UserControl
    {
        public TextBox_And_SelectedText()
        {
            this.InitializeComponent();
        }

		private void btnSelection_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				txkResult.Text += $"\n Selecion Start: {txbBase.SelectionStart} Length: {txbBase.SelectionLength} - {txbBase.SelectedText}";
			}
			catch (Exception)
			{

				throw;
			}
		}

		private void txbBase_SelectionChanged(object sender, RoutedEventArgs e)
		{
			try
			{
				txkResult.Text += $"\n Start: {txbBase.SelectionStart} Length: {txbBase.SelectionLength}";
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
