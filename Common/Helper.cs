using System.Diagnostics;
using WMAssess_DavidJ.Interfaces;

namespace WMAssess_DavidJ.Common;

public class Notification: INotify
{
    public void Notify(string? userId, string message)
    {
        Debug.WriteLine($"Sending message...{userId} - {message}");
    }
}
