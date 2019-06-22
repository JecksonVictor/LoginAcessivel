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
               
            }
            
            //else:TERMINATE
            

        }

        static string encontrarPreferenciasDeUsuario()
        {
            string nomeDeUsuario = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string[] usuarios = System.IO.File.ReadAllLines(@"C:\Users\jecks\Documents\users.txt");
            //string[] usuarios = System.IO.File.ReadAllLines(@"C:\users.txt");
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

        }
    }
}
