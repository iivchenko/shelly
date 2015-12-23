using System.ComponentModel;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Management.Automation.Runspaces;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Shelly.WPF.GUI.V_2.Models;

namespace Shelly.WPF.GUI.V_2.ViewModels
{
    public sealed class PowerShellViewModel : IPowerShellViewModel, INotifyPropertyChanged
    {
        private readonly PSHost _host;
        private readonly Runspace _runspace;

        private readonly  PSHostRawUserInterfaceModel _rawUi;
        private readonly PSHostUserInterfaceModel _ui;

        private PowerShell _shell; // Todo: Think on one instance
        
        private string _out;
        private string _script;
        private bool _credsRequired;

        public PowerShellViewModel()
        {
            _rawUi = new PSHostRawUserInterfaceModel();
            _ui = new PSHostUserInterfaceModel(_rawUi);

            _host = new PSHostModel(_ui);
            _runspace = RunspaceFactory.CreateRunspace(_host);
            _runspace.Open();

            _ui.Creds = (s, s1, arg3, arg4, arg5, arg6) =>
            {

            };
            
            _ui.Writing += (sender, s) => Out += s;
            _rawUi.WindowTitleChanged += (sender, s) => Title = s;
            _rawUi.Clearing += (sender, args) => Out = string.Empty;
        }

        public bool CredsRequired
        {
            get
            {
                return _credsRequired;
            }

            set
            {
                _credsRequired = value;
                
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get
            {
                return _rawUi.WindowTitle;
            }

            set
            {
                _rawUi.WindowTitle = value;

                OnPropertyChanged();
            }
        }

        public string Out
        {
            get
            {
                return _out;
            }

            set
            {
                _out = value;

                OnPropertyChanged();
            }
        }

        public string Script
        {
            get
            {
                return _script;
            }

            set
            {
                _script = value;

                OnPropertyChanged();
            }
        }

        public ICommand Run
        {
            get
            {
                // TODO: Think on async execution so View Thread should not wait the back-end
                return new LazyCommand(() =>
                {
                    if (string.IsNullOrEmpty(Script))
                    {
                        return;
                    }

                    Task.Factory.StartNew(() =>
                    {
                        using (_shell = PowerShell.Create())
                        {
                            Out += Script + "\n";

                            _shell.Runspace = _runspace;
                            _shell.AddScript(Script);
                            _shell.AddCommand("out-default");
                            _shell.Commands.Commands[0].MergeMyResults(PipelineResultTypes.Error, PipelineResultTypes.Output);

                            _shell.Invoke();
                        }

                        Script = string.Empty;
                    }).ContinueWith((parent) => { }, TaskContinuationOptions.OnlyOnFaulted);
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
