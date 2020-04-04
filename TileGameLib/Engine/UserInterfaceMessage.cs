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
        private readonly UserInterfacePlaceholder MessagePlaceholder;
        private readonly string Message;
        public bool IsEmpty => string.IsNullOrWhiteSpace(Message);

        public UserInterfaceMessage(UserInterface ui, UserInterfacePlaceholder placeholder, string message)
        {
            Ui = ui;
            MessagePlaceholder = placeholder;
            Message = message;
        }

        public void Draw()
        {
            if (IsEmpty)
                return;

            ObjectPosition msgpos = MessagePlaceholder.Position;
            Tile msgtile = MessagePlaceholder.Tile;
            Ui.Graphics.PutString(msgpos.X, msgpos.Y, Message, msgtile.ForeColor, msgtile.BackColor);
        }
    }
}
