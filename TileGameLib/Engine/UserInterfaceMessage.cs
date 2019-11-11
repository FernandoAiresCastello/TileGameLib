using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.GameElements;
using TileGameLib.Graphics;

namespace TileGameLib.Engine
{
    public class UserInterfaceMessage
    {
        private readonly UserInterface Ui;
        private readonly Timer MessageTimer;
        private string Message;
        private UserInterfacePlaceholder MessagePlaceholder;
        public  bool HasMessage => !string.IsNullOrWhiteSpace(Message);

        public UserInterfaceMessage(UserInterface ui)
        {
            Ui = ui;
            MessageTimer = new Timer();
            MessageTimer.Tick += MessageTimer_Tick;
        }

        private void MessageTimer_Tick(object sender, EventArgs e)
        {
            Message = "";
            MessageTimer.Stop();
        }

        public void Show(string placeholderObjectTag, string text, int duration)
        {
            MessagePlaceholder = Ui.Placeholders[placeholderObjectTag];

            Message = text;
            MessageTimer.Stop();
            MessageTimer.Interval = duration;
            MessageTimer.Start();
        }

        public void Draw()
        {
            if (!HasMessage)
                return;
                
            ObjectPosition msgpos = MessagePlaceholder.Position;
            Tile msgtile = MessagePlaceholder.Tile;
            Ui.Graphics.PutString(msgpos.X, msgpos.Y, Message, msgtile.ForeColorIx, msgtile.BackColorIx);
        }
    }
}
