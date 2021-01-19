
using ApiNovosys;
using ApiNovosys.Dto.Email;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ApiPlafonesWeb.Helpers
{
    public class Generals : ControllerBase
    {

        private ApplicationDbContext db;
        public Generals()
        {
            db = new ApplicationDbContext();
        }



        public bool Create(Object model, string nameModel)
        {

            if (ModelState.IsValid)
            {
                //if (nameModel == nameof(ContactosModel).ToString())
                //{
                //    ContactosModel contactosModel = new ContactosModel();
                //    contactosModel = (ContactosModel)model;

                //    db.ContactosModels.Add(contactosModel);
                //    db.SaveChanges();
                //}

            }


            return true;

        }





        //public bool SendEmailToBd(EmailDto e)
        //{
        //    string nombre = e.NombreVar;
        //    string telefono = e.TelefonoVar;
        //    string email = e.CorreoVar;
        //    string origen = e.OrigenVar;



        //    try
        //    {
        //        if (origen == "Home/JoinOurWorkTeam")
        //        {
        //            string area_interes = e.AreaInteresVar;
        //            string direccion = e.DireccionVar;
        //            string experiencia = e.ExperienciaVar;

        //            UneteModel unete = new UneteModel();
        //            unete.NombreVar = nombre;
        //            unete.ApellidoVar = nombre;
        //            unete.DireccionVar = direccion;
        //            unete.TelefonoVar = telefono;
        //            unete.CorreoVar = email;
        //            unete.FechaAltaDate = DateTime.Now;
        //            unete.AreaInteresVar = area_interes;
        //            unete.ExperienciaVar = experiencia;

        //            this.Create(unete, nameof(UneteModel).ToString());

        //            return true;


        //        }
        //        else if (origen == "Installation/EmailInstalacion")
        //        {

        //            string estado = e.EstadoVar;
        //            string descricion_obra = e.DescripcionObraVar;
        //            string M2 = e.MtsCuadradosInt.ToString();

        //            RequieresInstalacionModel installation = new RequieresInstalacionModel();
        //            installation.DescripcionObraVar = descricion_obra;
        //            installation.MtsCuadradosInt = Convert.ToInt32(M2);
        //            installation.EstadoVar = estado;
        //            installation.TelefonoVar = telefono;
        //            installation.CorreoVar = email;
        //            installation.FechaAltaDate = DateTime.Now;

        //            this.Create(installation, nameof(RequieresInstalacionModel).ToString());
        //            return true;

        //        }

        //        // if origen equals to  Productos/Details or Contact/Email

        //        string mensaje = e.MensajeVar;

        //        ContactosModel contact = new ContactosModel();
        //        contact.NombreVar = nombre;
        //        contact.TelefonoVar = telefono;
        //        contact.CorreoVar = email;
        //        contact.MensajeVar = mensaje;
        //        contact.FechaAltaDate = DateTime.Now;
        //        contact.OrigenVar = origen;

        //        this.Create(contact, nameof(ContactosModel).ToString());

        //        return true;



        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        //}





        public bool SendEmailSMTP(EmailDto e)
        {

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient();
            //SmtpClient SmtpServer = new SmtpClient("smtpout.secureserver.net");

            try
            {

                string origen = e.OrigenVar;
                string mensaje = e.MensajeVar;
                string descricion_obra = e.DescripcionObraVar;
                string area_interes = e.AreaInteresVar;
                string experiencia = e.ExperienciaVar;
                string direccion = e.DireccionVar;
                string M2 = e.MtsCuadradosInt != null ? e.MtsCuadradosInt.ToString() : "";


                String Body = @"<br></br>";


                Body += @"<center><div style=""background-color:#01426e;""><br/><img src=""https://scontent.fntr5-1.fna.fbcdn.net/v/t1.0-1/p720x720/117937518_2675114172804268_3724244392392071245_n.png?_nc_cat=101&ccb=2&_nc_sid=dbb9e7&_nc_ohc=MYkMLuv8VFkAX8sxNad&_nc_ht=scontent.fntr5-1.fna&_nc_tp=30&oh=4d19805fcd7db8e5e871a561035c1727&oe=602DD45B"" width=""320"" height=""80""></div></center>";

                Body += @"</br> <center> <h3> Información de contacto </h3> </center> </br>";

                Body += @"<center><table class='table'>";

                Body += TheadAdnTbodyEmail(e);

                Body += @"</table> </center>";

                Body += @"<br><br>";


                if (origen != "Installation/EmailInstalacion" && origen != "Home/JoinOurWorkTeam")
                {

                    Body += @"<h4> Mensaje </h4>";
                    Body += @"<p style=""text-align: justify;"">" + mensaje.ToString().Trim() + "</p>";

                }
                else if (origen == "Installation/EmailInstalacion")
                {
                    Body += @"<h4> Metros cuadrados: " + M2.ToString().Trim() + " </h4>";
                    Body += @"<h4> Descipción de la obra </h4>";
                    Body += @"<p style=""text-align: justify;"">" + descricion_obra.ToString().Trim() + "</p>";

                }
                else
                {
                    Body += @"<h4> Dirección  </h4>";
                    Body += @"<p style=""text-align: justify;"">" + direccion.ToString().Trim() + "</p>";
                    Body += @"<h4> Área de interés: " + area_interes.ToString().Trim() + " </h4>";
                    Body += @"<h4> Experiencia </h4>";
                    Body += @"<p style=""text-align: justify;"">" + experiencia.ToString().Trim() + "</p>";

                }


                mail.From = new MailAddress("info@plafones.com");
                //mail.From = new MailAddress("info.plafones@gmail.com");

                //mail.To.Add("egomez@plafones.com");
                mail.To.Add("lesquivel@plafones.com");
                //mail.Bcc.Add("uriel.quiroz187@gmail.com");

                mail.Subject = SubjectEmail(e);
                mail.IsBodyHtml = true;
                mail.Body = Body;

                SmtpServer.Port = 587;

                SmtpServer.EnableSsl = true;

                //Godaddy configuration
                //SmtpServer.Host = "relay-hosting.secureserver.net";
                SmtpServer.Host = "smtpout.secureserver.net";
                //SmtpServer.Host = "smtp.gmail.com";

                SmtpServer.UseDefaultCredentials = false;

                //Godaddy configurarion No Credentials
                //SmtpServer.Credentials = new System.Net.NetworkCredential("info.plafones@gmail.com", "pl@fonmail896?");
                SmtpServer.Credentials = new System.Net.NetworkCredential("info@plafones.com", "pl@fonmail896?");

                SmtpServer.Send(mail);

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }


        public string SubjectEmail(EmailDto e)
        {
            var origen = e.OrigenVar;
            var producto = e.NombreProductoVar;

            string subject = "";

            if (origen == "Home/JoinOurWorkTeam") { subject = "Plafones Web Unete a Nuestro Equipo de Trabajo"; }
            if (origen == "Installation/EmailInstalacion") { subject = "Plafones Web Requieres Instalación"; }
            if (origen == "Contact/Email") { subject = "Plafones Web Contacto"; }
            if (origen == "Productos/Details") { subject = "Plafones Web Detalle del Producto " + producto; }

            return subject;
        }


        public string TheadAdnTbodyEmail(EmailDto e)
        {
            string Body = "";
            string origen = e.OrigenVar;
            string nombre = e.NombreVar;
            string telefono = e.TelefonoVar;
            string email = e.CorreoVar;
            string mensaje = e.MensajeVar;

            try
            {



                if (origen == "Installation/EmailInstalacion")
                {


                    string estado = e.EstadoVar;

                    Body = Body + @"<thead>";
                    Body = Body + @"<tr>";
                    Body = Body + @"<th> Estado   </th>";
                    Body = Body + @"<th> Correo   </th>";
                    Body = Body + @"<th> Teléfono </th>";
                    Body = Body + @"</tr>";
                    Body = Body + @"</thead>";

                    Body = Body + @"<tbody>";
                    Body = Body + @"<tr> ";
                    Body = Body + @"<td>" + estado.ToString().Trim() + "</td> ";
                    Body = Body + @"<td>" + email.ToString().Trim() + "</td> ";
                    Body = Body + @"<td>" + telefono.ToString().Trim() + "</td> ";

                    Body = Body + @"</tr> ";
                    Body = Body + @"</tbody> ";

                }

                if (origen == "Home/JoinOurWorkTeam"
                || origen == "Productos/Details"
                || origen == "Contact/Email"
                )

                {


                    Body = Body + @"<thead>";
                    Body = Body + @"<tr>";
                    Body = Body + @"<th> Nombre   </th>";
                    Body = Body + @"<th> Correo   </th>";
                    Body = Body + @"<th> Teléfono </th>";
                    Body = Body + @"</tr>";
                    Body = Body + @"</thead>";

                    Body = Body + @"<tbody>";
                    Body = Body + @"<tr> ";
                    Body = Body + @"<td>" + nombre.ToString().Trim() + "</td> ";
                    Body = Body + @"<td>" + email.ToString().Trim() + "</td> ";
                    Body = Body + @"<td>" + telefono.ToString().Trim() + "</td> ";
                    Body = Body + @"</tr> ";
                    Body = Body + @"</tbody> ";

                }

            }

            catch (Exception)
            {

            }



            return Body;
        }




        //public List<Producto> GetUrlMetaProd(List<Producto> products)
        //{
        //    List<Producto> productList = new List<Producto>();
        //    foreach (var product in products.Where(x => x.EstatusInt == 1))
        //    {
        //        string cveProd = product.CveProdVar.Trim();

        //        cveProd = product.CveProdVar.Replace("/", "@").Trim();//TODO: Mejorar este replace
        //        if (string.IsNullOrEmpty(product.UrlMetaTagProdVar))
        //        {
        //            product.UrlMetaTagProdVar = cveProd;
        //        }
        //        product.UrlMetaTagProdVar = string.Format("{0}/{1}", cveProd, product.UrlMetaTagProdVar);

        //        productList.Add(product);
        //    }

        //    return productList;
        //}



    }//en class Generals
}
