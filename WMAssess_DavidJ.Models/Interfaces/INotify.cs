namespace WMAssess_DavidJ.Models.Interfaces;

public interface INotify
{
    void Notify(string? userId, string message);
    void Notify(string message);
}
