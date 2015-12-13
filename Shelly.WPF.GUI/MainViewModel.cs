using System;
using System.ComponentModel;
using System.Linq;
using System.Management.Automation;
using System.Windows.Input;

namespace Shelly.WPF.GUI
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly PowerShell _shell;

        private string _script;
        private string _output;        

        public MainViewModel()
        {
            _shell = PowerShell.Create();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Script
        {
            get
            {
                return _script;
            }

            set
            {
                _script = value;

                OnPropertyChanged("Script");
            }
        }

        public string Output
        {
            get
            {
                return _output;
            }

            set
            {
                _output= value;

                OnPropertyChanged("Output");
            }
        }

        public ICommand Run
        {
            get
            {
                return new LazyCommand(() =>
                {
                    _shell.AddScript(Script);
                    _shell.AddCommand("out-string");

                    Output += Script;                    

                    foreach (var item in _shell.Invoke())
                    {
                        Output += item.ToString();
                    }

                    Script = string.Empty;
                });
            }
        } 

        private void OnPropertyChanged(string name)
        {
            var temp = PropertyChanged;

            if (temp != null)
            {
                temp(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
