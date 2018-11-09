using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BarcodeScanner.Controls
{
    struct RECT
    {
        public int Left, Top, Right, Bottom;
    }

    struct NCCALSIZE_PARAMS
    {
        public RECT NewWindow;
        public RECT OldWindow;
        public RECT ClientWindow;
        public IntPtr WindowPos;
    }
    
    static class DrawingHelper
    {
        private static readonly int _clientPadding = 1;

        public static readonly Color BorderColor = Color.FromArgb(209, 209, 209);
        public static readonly Color BorderColorFocused = Color.FromArgb(190, 190, 210);

        [DllImport("user32")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

        [DllImport("user32")]
        public static extern IntPtr GetWindowDC(IntPtr hwnd);

        [DllImport("user32")]
        public static extern bool ReleaseDC(IntPtr hwnd, IntPtr wdc);

        public static TextRenderingHint ControlRenderingHint = TextRenderingHint.ClearTypeGridFit;

        public static bool WndProcTextBoxControl(Control c, Message m, bool clearBg)
        {
            if (m.Msg == 0x85) //WM_NCPAINT    
            {
                IntPtr wdc = GetWindowDC(c.Handle);
                using (Graphics g = Graphics.FromHdc(wdc))
                {
                    Color color = c.Focused || c.ClientRectangle.Contains(c.PointToClient(Control.MousePosition))
                        ? BorderColorFocused
                        : BorderColor;
                    Rectangle rect = new Rectangle(0, 0, c.Size.Width, c.Size.Height);
                    ControlPaint.DrawBorder(g, rect, color, ButtonBorderStyle.Solid);
                    if (clearBg)
                    {
                        g.SetClip(new Rectangle(1, 1, c.Size.Width - 2, c.Size.Height - 2));
                        g.Clear(c.Enabled ? c.BackColor : Color.FromKnownColor(KnownColor.ControlDark));
                    }
                }
                ReleaseDC(c.Handle, wdc);
                return true;
            }

            if (m.Msg == 0x83) //WM_NCCALCSIZE
            {
                if (m.WParam != IntPtr.Zero)
                {
                    NCCALSIZE_PARAMS rects = (NCCALSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(NCCALSIZE_PARAMS));
                    rects.NewWindow.Left += _clientPadding;
                    rects.NewWindow.Right -= _clientPadding;
                    rects.NewWindow.Top += _clientPadding;
                    rects.NewWindow.Bottom -= _clientPadding;
                    Marshal.StructureToPtr(rects, m.LParam, false);
                }
            }

            return false;
        }
    }
}
