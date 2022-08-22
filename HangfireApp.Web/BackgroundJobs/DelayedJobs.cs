using System.Drawing;

namespace HangfireApp.Web.BackgroundJobs
{
    public class DelayedJobs
    {
        public static string WasserZeichenJobHinzufügen(string dateiname,string wasserZeichenText)
        {
           return Hangfire.BackgroundJob.Schedule(() => WasserzeichenAnwenden(dateiname, wasserZeichenText),
                TimeSpan.FromSeconds(15));
            
        }

        public static void WasserzeichenAnwenden(string dateiname, string wasserZeichenText)
        {
            string weg=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/bilder", dateiname);

            using (var bitMap = Bitmap.FromFile(weg))
            {
               using(Bitmap tempBitMap = new Bitmap(bitMap.Width, bitMap.Height))
                {
                    using (Graphics graf=Graphics.FromImage(tempBitMap))
                    {
                        graf.DrawImage(bitMap, 0,0);
                        var font=new Font(FontFamily.GenericSansSerif,25,FontStyle.Bold);
                        var farbe = Color.FromArgb(255, 0, 0);
                        var pinsel = new SolidBrush(farbe);
                        var punkt = new Point(20, bitMap.Height - 50);
                        graf.DrawString(wasserZeichenText, font, pinsel, punkt);
                        tempBitMap.Save(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/bilder/wasserzeichen", dateiname));
                    }
                }
            }

        }
    }
}
