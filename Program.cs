using System.Collections.Immutable;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;

namespace Dictionary
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            var cultureUS = new CultureInfo("en-US");
            var cultureUA = new CultureInfo("uk-UA");

            var userCollection = new List<User>();
            userCollection.Add(new User() { Name = "*Adelle" });
            userCollection.Add(new User() { Name = "*Андрій" });
            userCollection.Add(new User() { Name = "Clair" });
            userCollection.Add(new User() { Name = "Steve" });
            userCollection.Add(new User() { Name = "Anna" });
            userCollection.Add(new User() { Name = "Sam" });
            userCollection.Add(new User() { Name = "1-Eva" });
            userCollection.Add(new User() { Name = "Kriss" });
            userCollection.Add(new User() { Name = "Dan" });
            userCollection.Add(new User() { Name = "8Miles" });
            userCollection.Add(new User() { Name = "Alex" });
            userCollection.Add(new User() { Name = "Евген" });

            userCollection.Sort(new UserComparer(cultureUA));

            var dictionary = new Dictionary<string, List<User>>();

            KeysCreate keys = new KeysCreate(userCollection, dictionary);
            keys.Creat();

            foreach (var item in dictionary)
            {
                item.Value.Sort(new UserComparer(cultureUS));
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key}");
                for (int i = 0; i < item.Value.Count; i++)
                {
                    Console.WriteLine(item.Value[i]);
                }
            }
        }
    }
}