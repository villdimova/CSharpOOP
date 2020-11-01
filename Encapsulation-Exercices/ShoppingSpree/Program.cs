using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
   public class Program
    {
        static void Main(string[] args)
        {
           
            var firstInput = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries).ToArray();
            var persons = new List<Person>();

            foreach (var person in firstInput)
            {
                var persoinInfo = person.Split("=",StringSplitOptions.RemoveEmptyEntries).ToArray();
                try
                {
                    Person currentPerson = new Person(persoinInfo[0], 
                                      decimal.Parse(persoinInfo[1]));
                    persons.Add(currentPerson);
                    
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            var secondInput= Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries).ToArray();
            var products = new List<Product>();
            foreach (var item in secondInput)
            {
                var productInfo = item.Split("=",StringSplitOptions.RemoveEmptyEntries).ToArray();

                try
                {
                    Product currentProduct = new Product(productInfo[0], decimal.Parse(productInfo[1]));
                    products.Add(currentProduct);

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    return;
                }
                
            }


            while (true)
            {
                string inputThree = Console.ReadLine();

                if (inputThree=="END")
                {
                    break;
                }
                else
                {
                    var purchaseInfo = inputThree.Split().ToArray();
                    string personName = purchaseInfo[0];
                    string productName = purchaseInfo[1];

                    var currentPerson = persons.First(p => p.Name == personName);
                        
                            var boughtProduct = products.First(p => p.Name == productName);


                            if (currentPerson.AddProduct(boughtProduct) == true)
                            {
                                Console.WriteLine($"{currentPerson.Name} bought {boughtProduct.Name}");
                               
                            }
 
                }
            }

            
            foreach (var person in persons)
            {
                if (person.BagOfProducts.Count==0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought ");
                }

                else
                {
                    Console.WriteLine($"{person.Name} - {String.Join(", ", person.BagOfProducts.Select(x=>x.Name))}");
                }
            }
        }
    }
}
