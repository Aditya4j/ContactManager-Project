using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp2
{
    class Contact 
    {
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public Contact(string name,long num,string email,string Add)
        {
            this.Name = name;
            this.PhoneNumber = num; 
            this.Email = email;
            this.Address = Add;

        }

        public override string ToString()
        {
            return $"Name: {this.Name} PhoneNumber: {this.PhoneNumber} Email: {this.Email} Address: {this.Address}";
        }
    }

    class ContactManager
    {
        List<Contact> contacts = new List<Contact>();

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
            Console.WriteLine("Contact Added Sucessfully");
        }

        public void RemoveContact(string name)
        {
            var n = contacts.FirstOrDefault(x => x.Name == name);
            if(n != null)
            {
                contacts.Remove(n);
                Console.WriteLine("Contact Removed Sucessfully");
            }
            else
            {
                Console.WriteLine("Contact Name Not Found");
            }
        }
        public void SearchContacts(string cont)
        {
            var c = contacts.Find(x => x.Name.IndexOf(cont, StringComparison.OrdinalIgnoreCase)>=0);
            if (c != null)
            {
                Console.WriteLine("Contact Found");
                Console.WriteLine($"Name: {c.Name} PhoneNumber: {c.PhoneNumber} Email: {c.Email} Address: {c.Address}");
    
            }
            else
            {
                Console.WriteLine("Contact Not Found");
            }
        }

        public void UpdateContact(string upd)
        {
            var u = contacts.Find(x => x.Name.IndexOf(upd, StringComparison.OrdinalIgnoreCase) >=0);
            if(u != null)
            {
                Console.WriteLine("Contact Found");
                Console.Write("Enter New Name: ");
                u.Name = Console.ReadLine();
                Console.Write("Enter number");
                u.PhoneNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("Contact Updated Sucessfully");
                
            }
            else
            {
                Console.WriteLine("Contact Not Found");
            }
        }
        public void ViewContacts()
        {
            Console.WriteLine("Name\t\tPhoneNumber\t\tEmail\t\tAddress");
            foreach (var item in contacts)
            {
                
                Console.WriteLine($"{item.Name}\t\t\t{item.PhoneNumber}\t\t\t{item.Email}\t\t\t{item.Address}\t\t\t");
            }
        }
    }

    internal class Program 
    {
        static void Main(string[] args)
        {
            //Contact c1 = new Contact("Adi", 9579342442, "Email@gmail.com", "India");
            //Contact c2 = new Contact("Raj", 9579342443, "Raj@gmail.com", "India");

            ContactManager cm = new ContactManager();
            while (true)
            {
                Console.WriteLine("Contact Book");
                Console.WriteLine("1.Add Contact");
                Console.WriteLine("2.Remove Contact");
                Console.WriteLine("3.UpdateContacts");
                Console.WriteLine("4.Search Contacts");
                Console.WriteLine("5.View All Contacts");

                Console.WriteLine("Enter Your Choice");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Write("Enter Your Name: ");
                        var name = Console.ReadLine();
                        Console.Write("Enter Your PhoneNumber: ");
                        var PhoneNumber = long.Parse(Console.ReadLine());
                        Console.Write("Enter Your Email: ");
                        var Email = Console.ReadLine();
                        Console.Write("Enter Your Address: ");
                        var Address = Console.ReadLine();
                        Contact c = new Contact(name, PhoneNumber, Email, Address);
                        cm.AddContact(c);
                        break;
                    case "2":
                        Console.Write("Enter Name Of Contact To Remove: ");
                        var remove = Console.ReadLine();
                        cm.RemoveContact(remove);
                        break;
                    case "3":
                        Console.Write("Enter Contact Name: ");
                        var update = Console.ReadLine();
                        cm.UpdateContact(update);
                        break;
                    case "4":
                        Console.WriteLine("Enter contact Name To Search Contact: ");
                        var search = Console.ReadLine();
                        cm.SearchContacts(search);
                        break;
                    case "5":
                        cm.ViewContacts();
                        break;
                    default:
                        break;
                }

            }


            //cm.AddContact(c1);
            //cm.AddContact(c2);

            //cm.ViewContacts();
            ////cm.SearchContacts("Raj");

            //cm.UpdateContact("Raj");

            //cm.ViewContacts();
            

            //cm.RemoveContact("Raj");

            //Console.WriteLine("---------------------------------------------------------------------------------");
            //cm.ViewContacts();


            Console.ReadKey();
        }
    }
}  
