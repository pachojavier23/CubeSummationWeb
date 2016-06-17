using CubeSummationLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CubeSummationWeb
{
    public partial class CubeSummation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// Ejecuta el evento del botón Ejecutar
        /// </summary>
        protected void ExecuteButton_Click(object sender, EventArgs e)
        {
            CubeSummationMain mainprogram = new CubeSummationMain(this.textAreaInput.Text);
            this.textAreaOutput.Text = mainprogram.ExecuteCubeSummation().Replace(@"\r\n\r\n",@"\r\n");

        }
    }
}