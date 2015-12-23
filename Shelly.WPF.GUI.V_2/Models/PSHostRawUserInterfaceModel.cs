using System;
using System.Management.Automation.Host;

namespace Shelly.WPF.GUI.V_2.Models
{
    public sealed class PSHostRawUserInterfaceModel : PSHostRawUserInterface
    {
        private string _windowTitle;

        public override KeyInfo ReadKey(ReadKeyOptions options)
        {
            throw new NotImplementedException();
        }

        public override void FlushInputBuffer()
        {
            throw new NotImplementedException();
        }

        public override void SetBufferContents(Coordinates origin, BufferCell[,] contents)
        {
            throw new NotImplementedException();
        }

        public override void SetBufferContents(Rectangle rectangle, BufferCell fill)
        {
            if (rectangle == new Rectangle(-1, -1, -1, -1))
            {
                Clearing(this, EventArgs.Empty);
            }
        }

        public override BufferCell[,] GetBufferContents(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        public override void ScrollBufferContents(Rectangle source, Coordinates destination, Rectangle clip, BufferCell fill)
        {
            throw new NotImplementedException();
        }

        public override ConsoleColor ForegroundColor { get; set; }
        public override ConsoleColor BackgroundColor { get; set; }
        public override Coordinates CursorPosition { get; set; }
        public override Coordinates WindowPosition { get; set; }
        public override int CursorSize { get; set; }

        // TODO: Fix this **** 
        public override Size BufferSize
        {
            get
            {
                return new Size(1000, 500);
            }

            set
            {
                
            }
        }

        public override Size WindowSize { get; set; }

        public override Size MaxWindowSize
        {
            get { throw new NotImplementedException(); }
        }

        public override Size MaxPhysicalWindowSize
        {
            get { throw new NotImplementedException(); }
        }

        public override bool KeyAvailable
        {
            get { throw new NotImplementedException(); }
        }

        public override string WindowTitle
        {
            get
            {
                return _windowTitle;
            }

            set
            {
                if (_windowTitle != value)
                {
                    _windowTitle = value;

                    if (WindowTitleChanged != null)
                    {
                        WindowTitleChanged(this, _windowTitle);
                    }
                }
            }
        }

        public event EventHandler<string> WindowTitleChanged;

        public event EventHandler Clearing;
    }
}
