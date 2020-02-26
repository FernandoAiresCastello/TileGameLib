using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Exceptions;

namespace TileGameLib.Engine
{
    public class TextInput
    {
        public delegate void TextInputEventHandler(string inputId, string inputString);

        public bool IsActive { get; private set; } = false;
        public string InputPrompt { get; private set; }
        public int InputCursor { get; private set; } = 0;
        public char[] InputString { get; private set; } = new char[InputBufferLength];
        public UserInterfacePlaceholder InputPlaceholderStart { get; private set; }
        public UserInterfacePlaceholder InputPlaceholderEnd { get; private set; }
        public UserInterfacePlaceholder InputPlaceholderPrompt { get; private set; }

        private const int InputBufferLength = 256;
        private string InputId;
        private readonly UserInterface Ui;
        private TextInputEventHandler InputHandler;

        public TextInput(UserInterface ui)
        {
            Ui = ui;
        }

        private void ClearInputBuffer()
        {
            for (int i = 0; i < InputBufferLength; i++)
                InputString[i] = ' ';
        }

        public void Input(string prompt, string promptPlaceholder, string startPlaceholder, string endPlaceholder, string inputId, TextInputEventHandler handler)
        {
            if (IsActive)
                throw new TileGameLibException("Current input not yet processed");

            ClearInputBuffer();

            IsActive = true;
            InputId = inputId;
            InputPrompt = prompt;
            InputHandler = handler;
            InputCursor = 0;
            InputPlaceholderPrompt = new UserInterfacePlaceholder(Ui.Placeholders[promptPlaceholder]);
            InputPlaceholderStart = new UserInterfacePlaceholder(Ui.Placeholders[startPlaceholder]);
            InputPlaceholderEnd = new UserInterfacePlaceholder(Ui.Placeholders[endPlaceholder]);
            Ui.SetPlaceholderVisible(startPlaceholder, false);
            Ui.SetPlaceholderVisible(endPlaceholder, false);
        }

        public void HandleKeyEvent(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                IsActive = false;
                InputHandler(InputId, new string(InputString).Trim());
                return;
            }

            if (e.KeyCode == Keys.Escape)
            {
                IsActive = false;
                InputHandler(InputId, null);
                return;
            }

            bool isLastCol = InputCursor == InputPlaceholderEnd.Position.X - InputPlaceholderStart.Position.X;
            bool isControlChar = false;
            char character = (char)e.KeyCode;

            if (char.IsLetter(character))
            {
                if (Control.IsKeyLocked(Keys.CapsLock) || e.Shift)
                    character = char.ToUpper(character);
                else
                    character = char.ToLower(character);

            }
            else if (e.KeyCode == Keys.Left && InputCursor > 0)
            {
                isControlChar = true;
                InputCursor--;
            }
            else if (e.KeyCode == Keys.Right && InputCursor + InputPlaceholderStart.Position.X < InputPlaceholderEnd.Position.X)
            {
                isControlChar = true;
                InputCursor++;
            }
            else if (e.KeyCode == Keys.Space)
            {
                isControlChar = false;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                isControlChar = true;
                InputString[InputCursor] = ' ';
            }
            else if (e.KeyCode == Keys.Home)
            {
                isControlChar = true;
                InputCursor = 0;
            }
            else if (e.KeyCode == Keys.Back)
            {
                isControlChar = true;
                if (InputCursor > 0)
                    InputCursor--;

                InputString[InputCursor] = ' ';
            }
            else if (e.KeyCode == Keys.End)
            {
                isControlChar = true;
                InputCursor = InputPlaceholderEnd.Position.X - InputPlaceholderStart.Position.X;
            }
            else if (char.IsDigit(character))
            {
                isControlChar = false;
            }
            else
            {
                isControlChar = true;
            }

            if (!isControlChar && !isLastCol)
            {
                InputString[InputCursor] = character;

                if (InputCursor + InputPlaceholderStart.Position.X < InputPlaceholderEnd.Position.X)
                {
                    InputCursor++;
                }
            }
        }
    }
}
