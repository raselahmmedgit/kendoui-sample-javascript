using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using RnD.KendoUISample.ViewModels;

namespace RnD.KendoUISample
{
    public class VCardResultHelper : ActionResult
    {
        private VCardViewModel _card;

        protected VCardResultHelper() { }

        public VCardResultHelper(VCardViewModel card)
        {
            _card = card;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = "text/vcard";
            //response.AddHeader("Content-Disposition", "attachment; fileName=" + _card.FirstName + " " + _card.LastName + ".vcf");
            response.AddHeader("Content-Disposition", "attachment; fileName=" + _card.FirstName + ".vcf");

            var cardString = _card.ToString();
            var inputEncoding = Encoding.Default;
            var outputEncoding = Encoding.GetEncoding("windows-1257");
            var cardBytes = inputEncoding.GetBytes(cardString);

            var outputBytes = Encoding.Convert(inputEncoding,
                                    outputEncoding, cardBytes);

            response.OutputStream.Write(outputBytes, 0, outputBytes.Length);
        }
    }
}