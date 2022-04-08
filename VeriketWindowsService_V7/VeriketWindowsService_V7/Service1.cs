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
using System.Timers;

namespace VeriketWindowsService_V7
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }
        Timer tmr = new Timer();
        string FilePath = "C:\\ProgramData\\VeriketAppTest_V7.txt";
        string ComputerName = System.Environment.GetEnvironmentVariable("COMPUTERNAME");
        string UserName = System.Environment.GetEnvironmentVariable("USERNAME");
        protected override void OnStart(string[] args)
        {
            File.AppendAllText(FilePath, "Start -" + "Tarih = " + DateTime.Now.ToString() + "/ Bilgisayaradı = " + ComputerName + "/ Kullanıcı Adı = " + UserName + "\r\n");
            tmr.Elapsed += new ElapsedEventHandler(tmr_Elapsed);
            tmr.Interval = 60000;
            tmr.Start();
        }

        void tmr_Elapsed(object sender, ElapsedEventArgs e)
        {
            File.AppendAllText(FilePath, "Working -" + "Tarih = " + DateTime.Now.ToString() + "/ Bilgisayaradı = " + ComputerName + "/ Kullanıcı Adı = " + UserName + "\r\n");


        }

        protected override void OnStop()
        {
            File.AppendAllText(FilePath, "Stoped -" + "Tarih = " + DateTime.Now.ToString() + "/ Bilgisayaradı = " + ComputerName + "/ Kullanıcı Adı = " + UserName + "\r\n");

            tmr.Enabled = false;
        }
        protected override void OnPause()
        {
            File.AppendAllText(FilePath, "Pauseed -" + "Tarih = " + DateTime.Now.ToString() + "/ Bilgisayaradı = " + ComputerName + "/ Kullanıcı Adı = " + UserName + "\r\n");

            tmr.Enabled = false;
        }
        protected override void OnContinue()
        {
            File.AppendAllText(FilePath, "Continues -" + "Tarih = " + DateTime.Now.ToString() + "/ Bilgisayaradı = " + ComputerName + "/ Kullanıcı Adı = " + UserName + "\r\n");

            tmr.Enabled = true;
        }
        protected override void OnShutdown()
        {
            File.AppendAllText(FilePath, "It is closed -" + "Tarih = " + DateTime.Now.ToString() + "/ Bilgisayaradı = " + ComputerName + "/ Kullanıcı Adı = " + UserName + "\r\n");

            tmr.Enabled = false;
        }
    }
}
