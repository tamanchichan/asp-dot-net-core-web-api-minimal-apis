using asp_dot_net_core_web_api_minimal_apis.Model;

namespace asp_dot_net_core_web_api_minimal_apis.Data
{
    public class Database
    {
        public static int id = 1;

        public static HashSet<Product> Products = new HashSet<Product>()
        {
                new Product(id++, "Water", 1.50m),
                new Product(id++, "Pop", 2.00m),
                new Product(id++, "Coffee", 3.00m),
                new Product(id++, "Tea", 3.00m)
        };
    }
}
