using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            System.Windows.Forms.SendKeys.SendWait("(%+{PRTSC})");
        }
    }
}
