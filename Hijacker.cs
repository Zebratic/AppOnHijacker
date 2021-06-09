using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppOnHijacker
{
    public partial class Hijacker : Form
    {
        public static TimeSpan waittime;
        public static int ID = 0;
        public Hijacker()
        {
            InitializeComponent();
        }

        private void Log(string content, int ID = -1)
        {
            rtxtLog.Invoke((MethodInvoker)delegate
            {
                if (ID == -1)
                    rtxtLog.AppendText(content + "\n");
                else
                    rtxtLog.AppendText($"[{ID}] " + content + "\n");

                rtxtLog.Select(rtxtLog.Text.Length, 1);
                rtxtLog.ScrollToCaret();
            });
        }

        private void CheckKeyword(string word, Color color, int startIndex)
        {
            rtxtLog.Invoke((MethodInvoker)delegate
            {
                if (rtxtLog.Text.Contains(word))
                {
                    int index = -1;
                    int selectStart = rtxtLog.SelectionStart;

                    while ((index = rtxtLog.Text.IndexOf(word, (index + 1))) != -1)
                    {
                        rtxtLog.Select((index + startIndex), word.Length);
                        rtxtLog.SelectionColor = color;
                        rtxtLog.Select(selectStart, 0);
                        rtxtLog.SelectionColor = Color.Black;
                    }
                }
            });
        }

        private void btnHijackVPS_Click(object sender, EventArgs e)
        {
            ID++;
            Log("Starting new thread...");
            Thread tr = new Thread(() => HijackVPS(cbIncognito.Checked, cbAdminHijack.Checked, cbFullscreen.Checked, ID));
            tr.Start();
        }

        private async Task HijackVPS(bool incognito, bool adminhijack, bool fullscreen, int threadid)
        {
            Log("------------------------------------------------------------------------------", threadid);
            Log("MAKE SURE YOU HAVE CHROME 90 INSTALLED!", threadid);
            Log("------------------------------------------------------------------------------", threadid);
            Log("Setting up driver...", threadid);
            ChromeOptions dco = new ChromeOptions();
            dco.SetLoggingPreference(LogType.Browser, LogLevel.All);
            dco.SetLoggingPreference(LogType.Client, LogLevel.Off);
            dco.SetLoggingPreference(LogType.Driver, LogLevel.Off);
            dco.SetLoggingPreference(LogType.Profiler, LogLevel.Off);
            dco.SetLoggingPreference(LogType.Server, LogLevel.Off);
            dco.AddArgument("--no-sandbox");
            dco.AddArgument("--silent");
            dco.AddArgument("--disable-gpu");
            dco.AddArgument("--log-level=3");
            dco.AddArgument("--disable-extensions");
            dco.AddArgument("--test-type");
            if (incognito)
                dco.AddArgument("--incognito");

            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\\ChromeDrivers"))
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\\ChromeDrivers");

            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\\ChromeDrivers\\chromedriver.exe"))
            {
                Log("No chrome driver found!", threadid);
                Log("Downloading chrome driver 90...", threadid);
                WebClient wc = new WebClient();
                wc.DownloadFile("https://cdn.discordapp.com/attachments/832638202057195602/840503885952712734/chromedriver.exe", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\\ChromeDrivers\\chromedriver.exe");
                Log("Chrome driver 90 downloaded & initialized!", threadid);
            }
            else
            {
                Log("Chrome driver found!", threadid);
            }

            var service = ChromeDriverService.CreateDefaultService(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\\ChromeDrivers");
            service.SuppressInitialDiagnosticInformation = true;
            service.HideCommandPromptWindow = true;

            var driver = new ChromeDriver(service, dco);
            waittime = driver.Manage().Timeouts().ImplicitWait;
            Log("Driver started!", threadid);

            driver.Manage().Window.Position = new Point(-100000000, -100000000);
            Log("Moved window to X: -100000000 | Y: -100000000", threadid);

            driver.Manage().Window.Minimize();
            Log("Minimized window!", threadid);

            if (adminhijack)
            {
                // scan for password packet and goto admin panel and login
                // https://htmlgw2.apponfly.com:4443/AccessNow/start.html
                Log("Attempting to hijack with admin method...", threadid);
                Log("THIS IS UNFINISHED!", threadid);
                Log("Now closing...", threadid);
                driver.Quit();
                return;
            }
            else
            {
                Log("Attempting to hijack with normal method...", threadid);
                driver.Navigate().GoToUrl("https://vps.apponfly.com/?autostart=true");
                try { new WebDriverWait(driver, waittime).Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")); } catch { Thread.Sleep(5000); }
                Log("Navigated to AppOnFly!", threadid);

                #region bypass trial
                Log($"Hijacking...", threadid);
                while (true)
                {
                    try
                    {
                        string time = driver.FindElement(By.Id("TrialCountdownTime")).Text;
                        if (time.Contains(":"))
                            Log($"Hijacking... | {time}", threadid);

                        if (time == "29:40")
                        {
                            break;
                        }
                    }
                    catch
                    {
                        try
                        {
                            if (driver.FindElement(By.XPath("/html/body/div[1]/div/div/h1")).Text == "Trial limit for your IP address has been reached.")
                            {
                                Log($"Hijack failed!... | IP limit reached! - Change VPN!", threadid);
                                driver.Quit();
                                return;
                            }
                        }
                        catch
                        {

                        }
                    }
                    Thread.Sleep(950);
                }

                Log($"Bypassing trial...", threadid);
                ((IJavaScriptExecutor)driver).ExecuteScript("$(\"#TrialCountdown\").hide();");
                ((IJavaScriptExecutor)driver).ExecuteScript("$(\"#RequireEmail\").hide();");
                ((IJavaScriptExecutor)driver).ExecuteScript("self.emailVerified = true;");
                ((IJavaScriptExecutor)driver).ExecuteScript("self.isTrial = false;");
                Log($"Trial bypassed!", threadid);
                #endregion bypass trial

                if (fullscreen)
                {
                    driver.Manage().Window.FullScreen();
                    Log($"Fullscreened window!", threadid);
                }
                else
                {
                    driver.Manage().Window.Position = new Point(0, 0);
                    Log($"Reset window position!", threadid);
                }
                Log($"Finished hijacking VPS!", threadid);
                Log($"If browser ends up on main screen,", threadid);
                Log($"then you need to connect to a new VPN!", threadid);
            }
        }

        private void btnKilldrivers_Click(object sender, EventArgs e)
        {
            try
            {
                int amount = 0;
                Process[] pros = Process.GetProcessesByName("chromedriver");
                foreach (Process pro in pros)
                {
                    pro.Kill();
                    amount++;
                }

                Log($"Killed old drivers! ({amount})");
            }
            catch { }
        }

        private void rtxtLog_TextChanged(object sender, EventArgs e)
        {
            CheckKeyword("Finished hijacking VPS!", Color.Green, 0);
            CheckKeyword("Killed old drivers!", Color.Green, 0);
            CheckKeyword("Chrome driver 90 downloaded & initialized!", Color.Green, 0);
            CheckKeyword("No chrome driver found!", Color.Orange, 0);
            CheckKeyword("------------------------------------------------------------------------------", Color.Orange, 0);
            CheckKeyword("MAKE SURE YOU HAVE CHROME 90 INSTALLED!", Color.Orange, 0);
            CheckKeyword("Hijack failed!... | IP limit reached! - Change VPN!", Color.Red, 0);
            CheckKeyword("THIS IS UNFINISHED!", Color.Red, 0);
            CheckKeyword("Now closing...", Color.Red, 0);
            CheckKeyword("[", Color.Black, 0);
            CheckKeyword("]", Color.Black, 0);
            CheckKeyword("0", Color.DarkMagenta, 0);
            CheckKeyword("1", Color.DarkMagenta, 0);
            CheckKeyword("2", Color.DarkMagenta, 0);
            CheckKeyword("3", Color.DarkMagenta, 0);
            CheckKeyword("4", Color.DarkMagenta, 0);
            CheckKeyword("5", Color.DarkMagenta, 0);
            CheckKeyword("6", Color.DarkMagenta, 0);
            CheckKeyword("7", Color.DarkMagenta, 0);
            CheckKeyword("8", Color.DarkMagenta, 0);
            CheckKeyword("9", Color.DarkMagenta, 0);
        }
    }
}