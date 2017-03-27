using RESTSampleApplication.RESTWebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTSampleApplication
{
    /// <summary>
    /// This is a sample of REST integration using Acumatica ERP
    /// This is for educationla purpose only to study if the code is also applicable
    /// in other ERP Application like Microsoft Dynamics 365
    /// </summary>
    class Program
    {
        static void Main()
        {
            int option;
            Console.WriteLine("Select an option you want to do:");
            Console.WriteLine("1. Create Customer");
            Console.WriteLine("2. Get Customer Info");
            Console.WriteLine("3. Create Sales Invoice");
            Console.WriteLine("4. Create Invoice to Payments");

            Console.Write("Enter option: ");
            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1:

                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 0:
                    Console.WriteLine("Value entered not in options.");
                    Console.WriteLine(System.Environment.NewLine);
                    Main();
                    break;
            }
        }

        void CreateCustomer(string customerID, string customerName, string email, string address1, string address2, string City)
        {
            using (DefaultEndpoint restClient = new DefaultEndpoint())
            {
                WebServiceConnector.InitializeWebService(restClient);

                try
                {
                    Customer newCust = new Customer
                    {
                        CustomerID = new StringValue { Value = customerID },
                        CustomerName = new StringValue { Value = customerName },
                        MainContact = new Contact
                        {
                            Email = new StringValue { Value = email },
                            Address = new Address
                            {
                                AddressLine1 = new StringValue { Value = address1 },
                                AddressLine2 = new StringValue { Value = address2 },
                                City = new StringValue { Value = City }
                            }
                        }
                    };
                }
                finally
                {
                    restClient.Logout();
                }
            }

        }
    }
}
