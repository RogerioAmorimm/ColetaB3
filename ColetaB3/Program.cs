using ColetaB3.Interfaces;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ColetaB3
{
    class Program
    {
 

        static async System.Threading.Tasks.Task Main(string[] args)
        {

            ArgsData datas = new ArgsData(args); //new string[] { "PETR4", "28,37", "25,37" });

            if (!datas.IsValid()) return;

            IDocument doc = new Document(@"config.txt");

            if (!doc.IsValid()) return;

            Share share;
            ICollect<Share> data = new DataCollect(datas.shareString);

            do
            {
                share = await data.GetCollect();

                if (data.IsValid())
                {
                    if (share.results[datas.shareString].price > datas.UpperLimit || share.results[datas.shareString].price < datas.InferiorLimit)
                    {
                        using (IEmail sender = new Email(doc.GetTo()))
                        {
                            await sender.SenderMail(string.Format("ALERTA DE ANALISE DA {0}", datas.shareString),
                                                    string.Format("A {0} BATEU VALOR: {1}", datas.shareString,
                                                                                            share.results[datas.shareString].price),
                                                    new SmtpClient(doc.GetHost(), doc.GetPort()));
                        }
                    }
                }
                await Task.Delay(500);

            } while (data.IsValid() && share.results[datas.shareString].price >= 0);
          

        }

     
        
    }
}
