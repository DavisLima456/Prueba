using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_EnviarCorreo
    {

        public static bool Enviar(string correo, string total, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = String.Empty;

            string asunto = "Cancelacion de Factura";

            try
            {

                MailMessage mail = new MailMessage();
                mail.To.Add(correo);
                mail.From = new MailAddress("umgmariano84@gmail.com");
                mail.Subject = asunto;
                mail.Body = total;
                mail.IsBodyHtml = true;

                var smtp = new SmtpClient()
                {
                    Credentials = new NetworkCredential("umgmariano84@gmail.com", "giqpfihafxrbxhrr"),
                    Host = "smtp.gmail.com",
                    Port = 25,
                    EnableSsl = true
                };

                smtp.Send(mail);
                resultado = true;
                Mensaje = "se envio el total";

            }
            catch (Exception ex)
            {
                Mensaje = "no se envio el correo";

                resultado = false;
            }

            return resultado;

        }
    }
}
