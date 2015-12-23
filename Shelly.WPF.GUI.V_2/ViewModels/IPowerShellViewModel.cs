using System.Windows.Input;

namespace Shelly.WPF.GUI.V_2.ViewModels
{
    public interface IPowerShellViewModel
    {
        bool CredsRequired { get; set; }

        string Out { get; }

        string Title { get; }

        ICommand Run { get; }
    }
}
