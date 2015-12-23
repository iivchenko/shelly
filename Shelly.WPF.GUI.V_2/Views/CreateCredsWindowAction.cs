using System.Windows;
using System.Windows.Interactivity;

namespace Shelly.WPF.GUI.V_2.Views
{
    public class CreateCredsWindowAction : TriggerAction<DependencyObject>
    {
        protected CreateCredsWindowAction()
        {
        }

        protected override void Invoke(object o)
        {
            new CredentialsView().ShowDialog();
        }
    }
}


