using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace LoginAcessivel
{
    class Program
    {
        static void Main(string[] args)
        {
            string preferenciasDoUsuario = encontrarPreferenciasDeUsuario();
            if (preferenciasDoUsuario != null)
            {
                carregarPreferenciasDeUsuario(preferenciasDoUsuario);
            }
            //else:TERMINATE
        }

        static string encontrarPreferenciasDeUsuario()
        {
            string nomeDeUsuario = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            string[] usuarios = Properties.Resources.users.Split('\n');
            foreach (string usuario in usuarios)
            {
                if (usuario.Contains(nomeDeUsuario))
                {
                    return usuario;
                }
            }
            return null;
        }

        static void carregarPreferenciasDeUsuario(string usuario)
        {
            string[] preferencias = (usuario.Substring(usuario.IndexOf(':')+1)).Split(';');
            foreach(string preferencia in preferencias)
            {
                Console.WriteLine("Ativando: " + preferencia);
                ativarConfiguracao(preferencia);
            }
        }

        static void ativarConfiguracao(string preferencia)
        {
            if (preferencia.Contains("AltoContraste"))
            {
                preferencia = preferencia.Substring(preferencia.IndexOf('(')+1);
                preferencia = preferencia.Substring(0, preferencia.IndexOf(')'));
                altoContraste(preferencia);
            }
        }

        static void altoContraste(string value)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Accessibility\HighContrast", true);
            key.SetValue("High Contrast Scheme", value);
            key.SetValue("Flags", 1);
            key.SetValue("LastUpdatedThemeId", 3);

            RegistryKey ke2 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Appearance", true);
            ke2.SetValue("Current", "@themeui.dll, -852");
            ke2.SetValue("NewCurrent", "@themeui.dll,-852");

            //kill explorer
            //foreach(var process in Process.GetProcessesByName("Windows Explorer")){
            //Console.WriteLine("Matando " + process.ToString());
            //process.Kill();
            //}
           // Process processo = new Process();

           // processo.StartInfo = new ProcessStartInfo("taskkill", "/F /IM explorer.exe");

           // processo.StartInfo.WindowStyle = ProcessWindowStyle.Normal;

           // processo.Start();

            //processo.WaitForExit();
            //Process.Start("explorer.exe");

            // System.Windows.Forms.SendKeys.SendWait("(%+{PRTSC})");

            //InputSimulator inputSimulator = new InputSimulator();
            //inputSimulator.Keyboard.KeyPress();
            //inputSimulator.Keyboard.ModifiedKeyStroke(new[] { VirtualKeyCode.LMENU, VirtualKeyCode.LSHIFT, VirtualKeyCode.SNAPSHOT }, null);

            //inputSimulator.Keyboard.ModifiedKeyStroke(new[] { VirtualKeyCode.SHIFT, VirtualKeyCode.MENU, VirtualKeyCode.SNAPSHOT}, null);

            //inputSimulator.Keyboard.KeyDown(VirtualKeyCode.LSHIFT);
            //inputSimulator.Keyboard.KeyDown(VirtualKeyCode.LMENU);
            //inputSimulator.Keyboard.KeyPress(VirtualKeyCode.SNAPSHOT); 
            //inputSimulator.Keyboard.KeyUp(VirtualKeyCode.LSHIFT);
            //inputSimulator.Keyboard.KeyUp(VirtualKeyCode.LMENU);


            //inputSimulator.Keyboard.ModifiedKeyStroke(new[] { VirtualKeyCode.LWIN, VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C}, null);

            //Console.WriteLine("Teclou");
            //Thread.Sleep(5000);
        }
    }
}
