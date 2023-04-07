using System;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Shardion.Identic
{
    public class ViewSourceElement : ClickableButtonElement
    {
        public override void ButtonClicked(string parameter)
        {
            OpenURI(parameter);
        }

        private static void OpenURI(string uri)
        {
            if (OperatingSystem.IsLinux())
            {
                Task.Run(() => Process.Start("xdg-open", uri)).ConfigureAwait(false);
                return;
            }
            if (OperatingSystem.IsMacOS())
            {
                Task.Run(() => Process.Start("open", uri)).ConfigureAwait(false);
                return;
            }
            if (OperatingSystem.IsWindows())
            {
                Task.Run(() => Process.Start(uri)).ConfigureAwait(false);
                return;
            }
        }
    }
}