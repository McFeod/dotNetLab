using System;
using System.IO;
using LabOneCinema.Artifacts;

namespace LabOneCinema.Logging
{
    public class LogEventArgs
    {
        public EventArgs Nested;
        public EventType Type;
        public TextWriter Output;
        public Film Sender;
    }
}