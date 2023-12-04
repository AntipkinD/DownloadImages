using System.Drawing;
using System.Diagnostics;
using System.Net;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    private static async Task Main(string[] args)
    {
        bool ok;
        HttpClient client = new HttpClient();
        await Console.Out.WriteLineAsync("Введите (вставьте) ссылку на изображение или нажмите Enter, чтобы скачать изображение по умолчанию");
        var httpath = Console.ReadLine();
        if (httpath != "")
        {
            ok = false;
            try
            {
                string path = $"D:/VSWorks/DownloadImages/file{0}.jpg";
                File.Delete(path);
                WebClient wclient = new WebClient();
                wclient.DownloadFile(new Uri(httpath), path);
                ok = true;
                await Console.Out.WriteLineAsync("Изображение успешно загружено");
            }
            catch (Exception e)
            {
                e = new Exception("Неверная ссылка");
                Console.WriteLine(e.Message);
            }
            if (ok == true)
            {
                ProcessStartInfo play = new ProcessStartInfo();
                play.FileName = "cmd";
                play.Arguments = @$"/c D:/VSWorks/DownloadImages/file{0}.jpg";
                Process.Start(play);
            }
        }
        else
        {
            ok = false;
            try
            {
                string path = $"D:/VSWorks/DownloadImages/file{0}.jpg";
                File.Delete(path);
                string httpathfile = "D:/VSWorks/DownloadImages/pathtxt.txt";
                StreamReader reader1 = new StreamReader(httpathfile);
                httpath = await reader1.ReadToEndAsync();
                reader1.Close();
                WebClient wclient = new WebClient();
                wclient.DownloadFile(new Uri(httpath), path);
                ok = true;
                await Console.Out.WriteLineAsync("Изображение успешно загружено");
            }
            catch (Exception e)
            {
                e = new Exception("Неверная ссылка");
                Console.WriteLine(e.Message);
            }
            if (ok == true)
            {
                ProcessStartInfo opendefault = new ProcessStartInfo();
                opendefault.FileName = "cmd";
                opendefault.Arguments = @$"/c D:/VSWorks/DownloadImages/file{0}.jpg";
                Process.Start(opendefault);
            }
        }
    }
}