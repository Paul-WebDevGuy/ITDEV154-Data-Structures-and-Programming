using System;
using System.Collections;


namespace assignment6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            hashTable();
        }

        //create a new hashtable 
        public static void hashTable()
        {
            Hashtable newTable = new Hashtable();
            string city;
            string cityLowerCase;
            string citySearch;
            string citySearchLowerCase;
            string cityRemove;
            int cityRemoveInt;
            string index;
            string answer;

            Console.WriteLine("We will be creating a new hashtable of US cities.  You will add keys as an integer and values" +
                " as US cities to the hashtable");
                Console.WriteLine();
            do
            {
                Console.WriteLine("Please enter an integer value to represent a key: ");
                index = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Please enter a US city: ");
                city = Console.ReadLine();
                cityLowerCase = city.ToLower();
                Console.WriteLine();

                //pass these values to the addElement method
                addElement(newTable, cityLowerCase, index);

                //ask if user would like to add another element
                Console.WriteLine("Would you like to add another key and US city to the hashtable? enter y for yes");
                answer = Console.ReadLine();
                Console.WriteLine();
            } while (answer == "y");

            //Display the table
            DisplayTable(newTable);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            do
            {
                //Search the hashtable for a specific element
                Console.WriteLine("Search the hashtable for an element.  Please an enter a US city you would " +
                    "to search for: ");
                citySearch = Console.ReadLine();
                citySearchLowerCase = citySearch.ToLower();

                //search the hashtable for the user input
                ContainsElement(newTable, citySearchLowerCase);

                //ask if user would like to search for another element
                Console.WriteLine("Would you like to search for another US city in the hashtable? enter y for yes");
                answer = Console.ReadLine();
                Console.WriteLine();
            } while (answer == "y");

            do
            {
                //Remove elements from the hashtable
                Console.WriteLine("Remove elements from the hashtable.  Please enter the key value you would "
                    + "like to remove from the hashtable: ");
                cityRemove = Console.ReadLine();

                //Remove elements from the hashtable
                removeElement(newTable, cityRemove);

                //ask if user would like to remove another element
                Console.WriteLine("Would you like to remove another US city from the hashtable? enter y for yes");
                answer = Console.ReadLine();
                Console.WriteLine();
            } while (answer == "y");

            //Display the table
            DisplayTable(newTable);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        //add an element to an existing hashtable in a specified 
        //index using an integer for indexing
        public static void addElement(Hashtable name, string value, string index)
        {
            name.Add(index, value);
        }

        //remove an element from a hashtable using a specificed index integer
        public static void removeElement(Hashtable name, string index)
        {
            //check to see if the value is in hashtable
            if (name.ContainsKey(index))
            {
                name.Remove(index);
            }
            else
            {
                Console.WriteLine("Hashtable does not contain index " + index);
            }
        }

        //Search a hashtable for a specified value
        public static void ContainsElement(Hashtable name, string city)
        {
            if(name.ContainsValue(city))
            {
                Console.WriteLine("The hashtable contains the value " + city);
            }
            else
            {
                Console.WriteLine("The hashtable does not contain this value");
            }
        }

        //Display both the key and elements of a hashtable
        public static void DisplayTable(Hashtable name)
        {
            foreach(DictionaryEntry de in name)
            {
                Console.WriteLine(String.Format("Key: {0}, Value: {1}", de.Key, de.Value));
            }
        }
    }
}
