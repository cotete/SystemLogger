using Microsoft.Diagnostics.Tracing.Parsers;
using Microsoft.Diagnostics.Tracing.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemLogger.Watchers
{
    internal class SystemWatcher
    {
        public TraceEventSession session = new TraceEventSession("Monitor");
        public SystemWatcher() { }

        public void Start()
        {

            session.EnableKernelProvider(KernelTraceEventParser.Keywords.Process);


            session.Source.Kernel.ProcessStart += (data) =>
            {
                string exeName = data.ImageFileName;
                string cmdLine = data.CommandLine;
                var controle = cmdLine.Split("\\");
                string file = controle[controle.Length - 1];

                if (cmdLine.Contains(".pdf") || cmdLine.Contains(".docx") || cmdLine.Contains(".xlsx") || cmdLine.Contains(".pdf"))
                {
                    int index = cmdLine.IndexOf("--single-argument");
                    string singleArgumentValue = cmdLine.Substring(index + 1).Split(" ")[1];
                    Console.WriteLine($"Caminho do arquivo: {singleArgumentValue}");
                    Console.WriteLine($"Arquivo: {file}");
                }

            };
            Task.Run(() =>
            {
                session.Source.Process();
            });
        }
}
