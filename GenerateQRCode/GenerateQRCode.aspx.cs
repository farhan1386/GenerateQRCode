using IronBarCode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GenerateQRCode
{
    public partial class GenerateQRCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ImageGeneratedBarcode.Visible = false;
        }

        protected void BtnGenerateQRCode_Click(object sender, EventArgs e)
        {
            string generatebarcode = txtGenerateQRCode.Text;
            GeneratedBarcode barcode = QRCodeWriter.CreateQrCode(generatebarcode, 300);

            // Styling a QR code and adding annotation text

            //barcode.AddBarcodeValueTextAboveBarcode();
            barcode.AddBarcodeValueTextBelowBarcode();
            barcode.SetMargins(10);
            barcode.ChangeBarCodeColor(Color.BlueViolet);

            var folder = Server.MapPath("/App_Data/GeneratedQRcode");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string filePath = Server.MapPath("GeneratedQRcode/barcode.png");
            barcode.SaveAsPng(filePath);
            ImageGeneratedBarcode.ImageUrl = "~/GeneratedQRcode/" + Path.GetFileName(filePath);
            ImageGeneratedBarcode.Visible = true;

        }

    }
}