using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using System.Threading;
using System.IO;

using System.Windows.Forms;

namespace LuxPower_Downloader
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Enter username, password, station number 
            // How to find station number will be shown in readme
            Console.WriteLine("Enter username:");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();
            Console.WriteLine("Enter Station Number");
            string station_number = Console.ReadLine();

            // Open folder browser to set save location for power data
            string DownloadDirectory = "";
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                Console.WriteLine(result);
                if (result == DialogResult.OK)
                {
                    Console.WriteLine(dialog.SelectedPath);
                    DownloadDirectory = dialog.SelectedPath;

                }
            }

            // Setup chrome driver
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("download.default_directory", DownloadDirectory);
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            ChromeDriver driver = new ChromeDriver(chromeOptions);

            // Navigate to login page and enter username and password
            driver.Navigate().GoToUrl("http://server.luxpowertek.com/WManage/web/login");
            driver.FindElement(By.Id("account")).Clear();
            driver.FindElement(By.Id("account")).SendKeys(userName);
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Monitor Center'])[1]/following::button[1]")).Click();

            // Download power data from site from a specific date stamp
            for (DateTime date = new DateTime(2019, 3, 2); date < DateTime.Today; date = date.AddDays(1.0))
            {

                string DownloadedFile = station_number + " - " + date.ToString("yyyy-MM-dd") + ".xls";
                string FilePath = DownloadDirectory + @"\" + DownloadedFile;

                // Check if file has already been downloaded if not download 
                if (File.Exists(FilePath) == false)
                {
                    driver.Navigate().GoToUrl("http://server.luxpowertek.com/WManage/web/analyze/data/export/" + station_number + "/" + date.ToString("yyyy-MM-dd"));
                    while (File.Exists(FilePath) == false)
                    {
                        Thread.Sleep(250);
                    }
                }
            }

            Console.WriteLine("Retived Power Data");

        }
    }
}
