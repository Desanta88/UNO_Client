using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace UNO_Client
{
    public class CustomButton:Button
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.Enabled == true)
                base.OnPaint(e);
            else
                ButtonRenderer.DrawButton(e.Graphics, ClientRectangle, Text, Font, false, PushButtonState.Disabled);
        }
    }
}
