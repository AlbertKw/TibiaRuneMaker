using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using TibiaRuneMaker.Logic.Enums;
using TibiaRuneMaker.Logic.Interfaces;

namespace TibiaRuneMaker.Logic.Services
{
    public class ClientInjector : IClientInjector
    {
        [DllImport("user32.dll")]
        private static extern IntPtr PostMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        private IntPtr? _clientHwnd;
        private readonly Configuration _configuration;
        public ClientInjector(Configuration configuration)
        {
            _configuration = configuration;
        }
        
        public IntPtr SendKey(KeysEnum k)
        {
            var hwnd = Inject();
            return PostMessage(hwnd, 0x100, (IntPtr)k, (IntPtr)0);
        }

        private IntPtr Inject()
        {
            if (_clientHwnd != null) { return (IntPtr)_clientHwnd; }
            
            var processName = _configuration.ClientProcessName;
            var process = Process.GetProcessesByName(processName);
            _clientHwnd = process?.FirstOrDefault()?.MainWindowHandle;
            
            if (_clientHwnd == null)
            {
                throw new Exception("Client not found.");
            }

            return (IntPtr)_clientHwnd;
        }
        
    }
}
