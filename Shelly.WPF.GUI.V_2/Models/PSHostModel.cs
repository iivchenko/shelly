using System;
using System.Globalization;
using System.Management.Automation.Host;
using System.Threading;

namespace Shelly.WPF.GUI.V_2.Models
{
    public sealed class PSHostModel : PSHost
    {
        // TODO: Provide in the constructor
        private readonly Guid _id = Guid.NewGuid();

        private readonly PSHostUserInterface _psHostUserInterface;
        
        public PSHostModel(PSHostUserInterface psHostUserInterface)
        {
            _psHostUserInterface = psHostUserInterface;
        }

        public override PSHostUserInterface UI
        {
            get { return _psHostUserInterface; }
        }

        public override void SetShouldExit(int exitCode)
        {
            throw new NotImplementedException();
        }

        public override void EnterNestedPrompt()
        {
            throw new NotImplementedException();
        }

        public override void ExitNestedPrompt()
        {
            throw new NotImplementedException();
        }

        public override void NotifyBeginApplication()
        {
            throw new NotImplementedException();
        }

        public override void NotifyEndApplication()
        {
            throw new NotImplementedException();
        }

        public override string Name
        {
            get { return "TestHost"; }
        }

        public override Version Version
        {
            // TODO: Fix version
            get { return new Version(1, 0); }
        }

        public override Guid InstanceId
        {
            // TODO: Fix id
            get { return _id; }
        }

        public override CultureInfo CurrentCulture
        {
            // TODO: Fix
            get { return Thread.CurrentThread.CurrentCulture; }
        }

        public override CultureInfo CurrentUICulture
        {
            // TODO: Fix
            get { return Thread.CurrentThread.CurrentUICulture; }
        }
    }
}
