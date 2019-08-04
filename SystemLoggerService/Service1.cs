using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace SystemLoggerService
{
    public partial class Service1 : ServiceBase
    {
        DateTime outTime = new DateTime();
        public Service1()
        {
            InitializeComponent();
            outTime = DateTime.Now;
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
            this.Dispose();
        }
        protected override void OnSessionChange(SessionChangeDescription changeDescription)
        {

            string filePath = @"C:\Windows\SystemTimeLogger.txt";
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            StreamWriter sWriter = new StreamWriter(fs);

            sWriter.BaseStream.Seek(0, SeekOrigin.End);
            string activity = string.Empty;
            string duration = string.Empty;
            switch (changeDescription.Reason)
            {
                case SessionChangeReason.SessionLogon:
                    duration = (DateTime.Parse(DateTime.Now.TimeOfDay.ToString()).Subtract(DateTime.Parse(outTime.TimeOfDay.ToString()))).ToString();

                    activity = "Log On";
                    break;
                case SessionChangeReason.SessionLogoff:
                    outTime = DateTime.Now;
                    activity = "Log Off";
                    break;
                case SessionChangeReason.SessionLock:
                    outTime = DateTime.Now;
                    activity = "Lock ";
                    break;
                case SessionChangeReason.SessionUnlock:
                    duration = (DateTime.Parse(DateTime.Now.TimeOfDay.ToString()).Subtract(DateTime.Parse(outTime.TimeOfDay.ToString()))).ToString();
                    activity = "Unlock";
                    break;

                default:
                    break;
            }
            sWriter.WriteLine(string.Format("{0} : {1}", activity, DateTime.Now.ToString()));
            if (!string.IsNullOrEmpty(duration))
            {
                sWriter.WriteLine("Idle time : " + duration);
                sWriter.WriteLine();
            }
            sWriter.Flush();
            sWriter.Close();
        }
    }
}
