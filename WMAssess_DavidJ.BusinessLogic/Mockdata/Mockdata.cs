using System.Reflection.Metadata.Ecma335;
using WMAssess_DavidJ.Models;

namespace WMAssess_DavidJ.Services;
public class Mockdata
{
    public List<Buyer> _buyers = new List<Buyer>
    {
        new Buyer { Id = "49ec2a8703224eea9dec16b22546477e", Name = "Johnny Buyer", Email = "jbuyer@test.com" },
        new Buyer { Id = "a790a7b6bf2a48569066c46306c3332d", Name = "Jennie Purchaser", Email = "jpurchaser@test.com" }
    };

    public List<Product> _products = new List<Product>();
}
