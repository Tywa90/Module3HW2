using System.Collections.Immutable;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;

namespace Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var phoneBook = new PhoneBook<Contact>();
            //phoneBook.Add(new Contact() { FirstName = "Alena", LastName = "Belkova"});
            //phoneBook.Add(new Contact() { FirstName = "Bob", LastName = "Muray" });














           Console.OutputEncoding = UTF8Encoding.UTF8;
            var cultureUS = new CultureInfo("en-US");
            var cultureUA = new CultureInfo("uk-UA");


            var userCollection = new List<User>();
            userCollection.Add(new User() { Name = "*Андрій" });
            userCollection.Add(new User() { Name = "Clair" });
            userCollection.Add(new User() { Name = "Steve" });
            userCollection.Add(new User() { Name = "Anna" });
            userCollection.Add(new User() { Name = "=Adelle" });
            userCollection.Add(new User() { Name = "Sam" });
            userCollection.Add(new User() { Name = "1-Eva" });
            userCollection.Add(new User() { Name = "Kriss" });
            userCollection.Add(new User() { Name = "Dan" });
            userCollection.Add(new User() { Name = "8Miles" });
            userCollection.Add(new User() { Name = "Alex" });



            userCollection.Sort();

            var dictionary = new Dictionary<string, List<User>>();
           
            //string alfabetUS = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
            //string keyDigit = "0-9";
            //string keyOthers = "#";

            CategoryKeys keys = new CategoryKeys(userCollection, dictionary);
            keys.KeysCreat();



            //for (int i = 0; i < alfabetUS.Length; i++)
            //{
            //    var tempList = new List<User>();

            //    for (int j = 0; j < userCollection.Count; j++)
            //    {
            //        key = userCollection[j].Name[0].ToString();
            //        if (key.Contains(alfabetUS[i]))
            //        {
            //            tempList.Add(userCollection[j]);
            //        }
            //    }

            //    key = alfabetUS[i].ToString();
            //    if (tempList.Count > 0)
            //    {
            //        dictionary.Add(key, tempList);
            //    }
            //}

            //var tempDigitList = new List<User>();
            //for (int i = 0; i < userCollection.Count; i++)
            //{
            //    key = userCollection[i].Name[0].ToString();
            //    if (int.TryParse(key, out int res))
            //    {
            //        tempDigitList.Add(userCollection[i]);
            //    }
            //    key = keyDigit;
            //}
            //if (tempDigitList.Count > 0)
            //{
            //    dictionary.Add(key, tempDigitList);
            //}



            //var tempOthersList = new List<User>();
            //for (int i = 0; i < userCollection.Count; i++)
            //{
            //    key = userCollection[i].Name[0].ToString();

            //        if (!key.Equals(alfabetUS[i]) && !int.TryParse(key, out int res1))
            //        {
            //            tempOthersList.Add(userCollection[i]);
            //        }

            //    key = keyOthers;
            //}
            //if (tempOthersList.Count > 0)
            //{
            //    dictionary.Add(key, tempOthersList);
            //}

            //for (int i = 0; i < userCollection.Count; i++)
            //{
            //    key = userCollection[i].Name[0].ToString();
            //    var tempList = new List<User>();

            //    if (key.Contains(alfabetUS[i]))
            //    {

            //        tempList.Add(userCollection[i]);
            //        key = alfabetUS[i].ToString();

            //if (!dictionary.ContainsKey(key))
            //{

            //}
            //dictionary.Add(key, userCollection[i]);
            //    }




            //}

            //dictionary.Add("I", userCollection);
            //dictionary.Add("E", userCollection);

            //foreach (var key in dictionary)
            //{
            //    key.Key.ToList().Sort();
            //}


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



            Console.WriteLine();
        }
    }
}