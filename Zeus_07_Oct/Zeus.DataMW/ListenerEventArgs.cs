using System;

namespace Zeus.Data
{
	public class ListenerEventArgs:EventArgs
	{
        public ListenerEventArgs(string e)
        {
            _event = e;
        }

        private string _event;

        public string Event
        {
            get { return _event; }
            set { _event = value; }
        }
	}
}
