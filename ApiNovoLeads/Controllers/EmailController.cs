using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNovosys.Dto.Email;
using ApiPlafonesWeb.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiNovosys.Controllers
{

    /// <summary>
    /// Email Controller
    /// </summary>
        [Route("api/email/")]
        [ApiController]
      [ApiExplorerSettings(GroupName = "ApiEmail")]
    public class EmailController : ControllerBase
        {

            private Generals generals;
            public EmailController()
            {
                generals = new Generals();
            }



        /// <summary>
        /// Send Email
        /// </summary>
        /// <param name="EmailDto"></param>
        /// <returns></returns>
            [HttpPost("sendemail")]
            public string Send([FromBody] EmailDto EmailDto)
            {
                var ajas = EmailDto.CorreoVar;
                string message = "";

                try
                {
                    generals = new Generals();

                    if (generals.SendEmailSMTP(EmailDto))
                    {
                        message = "success";
                    }
                    else
                    {
                        message = "error";
                    }

                }
                catch (Exception)
                {
                    return JsonConvert.SerializeObject(message);
                }

                return JsonConvert.SerializeObject(message);
            }



        }
    }
