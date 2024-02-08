using System.Reflection.Metadata.Ecma335;

namespace WMAssess_DavidJ.Mockdata;

using WMAssess_DavidJ.Models;

public static class Mockdata
{
    public static List<Buyer> _buyers = new List<Buyer>
    {
        new Buyer { Id = "49ec2a8703224eea9dec16b22546477e", Name = "Johnny Buyer", Email = "jbuyer@test.com" },
        new Buyer { Id = "a790a7b6bf2a48569066c46306c3332d", Name = "Jennie Purchaser", Email = "jpurchaser@test.com" }
    };

    public static List<Product> _products = new List<Product>();
}
