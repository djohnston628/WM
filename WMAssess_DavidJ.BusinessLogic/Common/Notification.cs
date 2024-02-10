using System.Diagnostics;
using WMAssess_DavidJ.Models.Interfaces;

namespace WMAssess_DavidJ.Services;

public class Notification: INotify
{
    public void Notify(string? userId, string message)
    {
        Debug.WriteLine($"Sending message...{userId} - {message}");
    }

    public void Notify(string message)
    {
        Debug.WriteLine(message);
    }
}
