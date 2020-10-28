using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace VirastarE
{
    static class ShortcutManager
    {

        public static event KeyEventHandler KeyDown;


        delegate int LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        static readonly LowLevelKeyboardProc _proc = HookCallback;
        static IntPtr _hookID = IntPtr.Zero;
        const int WH_KEYBOARD = 2;
        const int HC_ACTION = 0;
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool UnhookWindowsHookEx(IntPtr idHook);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        static extern short GetKeyState(int nVirtKey);

        static bool _keyHookingStarted;
        public static void Start()
        {
            if (!_keyHookingStarted)
            {
#pragma warning disable 0618
                _hookID = SetWindowsHookEx(WH_KEYBOARD, _proc, IntPtr.Zero, (uint)AppDomain.GetCurrentThreadId());
#pragma warning restore 0618
                _keyHookingStarted = true;
            }
        }
        public static void Stop()
        {
            if (_keyHookingStarted)
            {
                UnhookWindowsHookEx(_hookID);
                _hookID = IntPtr.Zero;
                _keyHookingStarted = false;
            }
        }
        static void OnKeyPress(uint keys)
        {
            Func<Keys, bool> checkKey = key => keys == (uint)key && IsKeyDown(key);

            //checks that shift, alt, ctrl and win keys are not pressed
            Func<bool> checkModifiers = () => !IsKeyDown(Keys.ShiftKey)
                && !IsKeyDown(Keys.Menu) // Keys.Menu is Alt button code
                && !IsKeyDown(Keys.LWin) && !IsKeyDown(Keys.RWin);


            Keys keyx = (Keys)keys;
            KeyEventArgs kArg = new KeyEventArgs(keyx);
            if (KeyDown != null) KeyDown(null, kArg);

            if (checkModifiers() && (checkKey(Keys.Enter) || checkKey(Keys.Return)))
            {
                // Make you actions here. If it is some long action, do it in background thread
                // this code is just and example
                //Worksheet ws = Globals.ThisAddIn.Application.ActiveSheet;
                //Range cell = ws.Cells[1, 1];
                //cell.Interior.Color = 0xFF0000;
            }

        }
        static bool IsKeyDown(Keys keys)
        {
            return (GetKeyState((int)keys) & 0x8000) == 0x8000;
        }
        static int HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0)
            {
                return (int)CallNextHookEx(_hookID, nCode, wParam, lParam);
            }
            if (nCode == HC_ACTION)
            {
                OnKeyPress((uint)wParam);
            }
            return (int)CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
    }
}
