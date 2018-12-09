using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Core.Common
{
    // Class to log results
    public class LogFile : IDisposable
    {
        protected string _filename;
        protected StreamWriter _writer;
        protected bool _disposed;

        /// <summary>
        /// Gets the current filename
        /// </summary>
        public string Filename { get { return _filename; } }

        /// <summary>
        /// Gets or sets if the file is closed between each call to Write()
        /// </summary>
        public bool KeepOpen { get; set; }

        /// <summary>
        /// Gets or sets if logging is active or suppressed
        /// </summary>
        public bool IsLogging { get; set; }

        /// <summary>
        /// Constructs a new LogFile object. Data will be appended to
        /// any existing data. File will be closed between writes.
        /// </summary>
        /// <param name="filename">Name of log file to write.</param>
        public LogFile(string filename)
            : this(filename, true, false)
        {
        }

        /// <summary>
        /// Constructs a new LogFile object. File will be closed between
        /// writes.
        /// </summary>
        /// <param name="filename">Name of log file to write.</param>
        /// <param name="append">If true, data is written to the end of any
        /// existing data; otherwise, existing data is overwritten.</param>
        public LogFile(string filename, bool append)
            : this(filename, append, false)
        {
        }

        /// <summary>
        /// Constructs a new LogFile object.
        /// </summary>
        /// <param name="filename">Name of log file to write.</param>
        /// <param name="append">If true, data is written to the end of any
        /// existing data; otherwise, existing data is overwritten.</param>
        /// <param name="keepOpen">If true, performance is improved by
        /// keeping the file open between writes; otherwise, the file
        /// is opened and closed for each write.</param>
        public LogFile(string filename, bool append, bool keepOpen)
        {
            _filename = filename;
            KeepOpen = keepOpen;
            IsLogging = true;

            _writer = null;
            _disposed = false;

            // Delete existing file if !append (ignore exceptions)
            if (!append)
            {
                try
                {
                    File.Delete(filename);
                }
                catch { }
            }
        }

        /// <summary>
        /// Closes the current log file
        /// </summary>
        public void Close()
        {
            if (_writer != null)
            {
                _writer.Dispose();
                _writer = null;
            }
        }

        /// <summary>
        /// Writes a formatted string to the current log file
        /// </summary>
        /// <param name="fmt"></param>
        /// <param name="args"></param>
        public void Write(string fmt, params object[] args)
        {
            Write(String.Format(fmt, args));
        }

        /// <summary>
        /// Writes a string to the current log file
        /// </summary>
        /// <param name="s"></param>
        public void Write(string s)
        {
            if (IsLogging)
            {
                // Establish file stream if needed
                if (_writer == null)
                    _writer = new StreamWriter(_filename, true);

                // Write string with date/time stamp
                _writer.WriteLine(String.Format("{0:d} {0:T} : {1}", DateTime.Now, s));

                // Close file if not keeping open
                if (!KeepOpen)
                    Close();
            }
        }
        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                // Need to dispose managed resources if being called manually
                if (disposing)
                    Close();
                _disposed = true;
            }
        }

        #endregion
    }
    public class Monitor
    {
        static LogFile _monitor;
        static StringBuilder stringbuilder = new StringBuilder();
        #region "generate file name"
        static string right(string stringValue, int length)
        {
            return stringValue.Substring(stringValue.Length - length, length);
        }
        static string makefilename(long seq)
        {
            string monitorFilename = AppDomain.CurrentDomain.FriendlyName.Split(new char[] { '.' })[0];
            return @"c:\docs\"  +monitorFilename + "_" + DateTime.Now.ToString("yyMMdd") + "_" + right("000" + seq, 3) + ".txt";
        }
        static string genFilename()
        {
            long seq = 0;
            while (File.Exists(makefilename(seq)))
            {
                seq++;
            }
            return makefilename(seq);
        }
        #endregion
        static Monitor()
        {
            string filename = Monitor.genFilename();
            _monitor = new LogFile(filename, true, false);
            Monitor.write("Starting Session");
          
        }
        public static void write(string message)
        {
            try
            {
                _monitor.Write(message);
                Monitor.stringbuilder.AppendLine(message);
            }
            catch { }
        }
        public static void write(string s,params object[] args)
        {
            string message = string.Format(s,args);
            _monitor.Write(message);
            Monitor.stringbuilder.AppendLine(message);
        }
        public static void close(){
            _monitor.Dispose();
            _monitor = null;
            Monitor.stringbuilder = null;
        }
        public static string peek()
        {
            string s = "";
            try{s = Monitor.stringbuilder.ToString();}catch (Exception){}
            return s;
        }
        public static void Console(string s)
        {
            _monitor.Write(s);
            System.Console.WriteLine(s);
        }
    }
}
