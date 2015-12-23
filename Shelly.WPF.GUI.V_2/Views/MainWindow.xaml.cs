using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation.Host;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Shelly.WPF.GUI.V_2.ViewModels;

namespace Shelly.WPF.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new PowerShellViewModel();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ((IPowerShellViewModel)DataContext).Run.Execute(null);
                Out.ScrollToEnd();
            }
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            Out.TextWrapping = Out.TextWrapping == TextWrapping.Wrap ? TextWrapping.NoWrap : TextWrapping.Wrap;
        }

        private void Out_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (Keyboard.GetKeyStates(Key.LeftCtrl) == (KeyStates.Down | KeyStates.Toggled))
            {
                if (e.Delta > 0 && Out.FontSize < double.MaxValue)
                {
                    Out.FontSize++;
                }
                else if(e.Delta < 0 && Out.FontSize > 0)
                {
                    Out.FontSize--;
                }
            }
            else
            {
                base.OnMouseWheel(e);
            }
        }
    }
}
