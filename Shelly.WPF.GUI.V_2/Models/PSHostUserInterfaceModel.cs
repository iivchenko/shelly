using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using Shelly.WPF.GUI.V_2.Views;

namespace Shelly.WPF.GUI.V_2.Models
{
    public sealed class PSHostUserInterfaceModel : PSHostUserInterface
    {
        public event EventHandler<string> Writing;

        public Func<string, string, string, string, PSCredentialTypes, PSCredentialUIOptions, PSCredential> Creds;

        private readonly PSHostRawUserInterface _rawUI;

        public PSHostUserInterfaceModel(PSHostRawUserInterface rawUI)
        {
            _rawUI = rawUI;
        }

        public override string ReadLine()
        {
            throw new NotImplementedException();
        }

        public override SecureString ReadLineAsSecureString()
        {
            throw new NotImplementedException();
        }

        public override void Write(string value)
        {
            Writing(this, value.TrimEnd(' '));
        }

        public override void Write(ConsoleColor foregroundColor, ConsoleColor backgroundColor, string value)
        {
            Writing(this, value.TrimEnd(' '));
        }

        public override void WriteLine(string value)
        {
            Writing(this, value.TrimEnd(' ') + "\n");
        }

        public override void WriteErrorLine(string value)
        {
            Writing(this, value.TrimEnd(' ') + "\n");
        }

        public override void WriteDebugLine(string message)
        {
            throw new NotImplementedException();
        }

        public override void WriteProgress(long sourceId, ProgressRecord record)
        {
            throw new NotImplementedException();
        }

        public override void WriteVerboseLine(string message)
        {
            throw new NotImplementedException();
        }

        public override void WriteWarningLine(string message)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, PSObject> Prompt(string caption, string message, Collection<FieldDescription> descriptions)
        {
            throw new NotImplementedException();
        }

        public override PSCredential PromptForCredential(string caption, string message, string userName, string targetName)
        {
            throw new NotImplementedException();
        }

        public override PSCredential PromptForCredential(string caption, string message, string userName, string targetName,
            PSCredentialTypes allowedCredentialTypes, PSCredentialUIOptions options)
        {
            return Creds(caption, message, userName, targetName, allowedCredentialTypes, options);

            var creds = new CredentialsView();

                return creds.ShowDialog() == true
                    ? new PSCredential(creds.User.Text, creds.Pass.SecurePassword)
                    : null;
        }

        public override int PromptForChoice(string caption, string message, Collection<ChoiceDescription> choices, int defaultChoice)
        {
            throw new NotImplementedException();
        }

        public override PSHostRawUserInterface RawUI
        {
            get { return _rawUI; }
        }
    }
}
