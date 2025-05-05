using Microsoft.Diagnostics.Tracing.Parsers;
using Microsoft.Diagnostics.Tracing.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemLogger.Sender;

namespace SystemLogger.Watchers
{
    internal class SystemWatcher
    {
        public TraceEventSession session = new TraceEventSession("Monitor");
        public SystemWatcher() { }


        /// <summary>
        /// Método que realiza todo o monitoramento do sistema, no quesito abertura de arquivos (.pdf,.xlsx,.docx).
        /// </summary>
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
                    string filePath = cmdLine.Substring(index + 1).Split(" ")[1];
                    Console.WriteLine($"Caminho do arquivo: {filePath}");
                    Console.WriteLine($"Arquivo: {file}");
                    object obj = new
                    {
                        tipoEvento = "File_Open",
                        Arquivo = file,
                        CaminhoArquivo = filePath,
                        timestamp = DateTime.Now,
                    };
                    PostToApi.Post(obj);
                }

            };
            Task.Run(() =>
            {
                session.Source.Process();
            });
        }

    }
}
