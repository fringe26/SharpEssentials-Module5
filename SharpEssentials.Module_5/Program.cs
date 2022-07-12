using System;
using System.Linq;

namespace SharpEssentials.Module_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var user = UserRegistration();
            Console.WriteLine(new String('-',30));
            ShowUserInfo(user);
            Console.WriteLine(new String('-', 30));
        }
       
        static (string firstName, string lastName, int age, string[] pets, string[] favColors) UserRegistration()
        {
            (string firstName, string lastName, int age, string[] pets, string[] favColors) User = default;

            string name;
            Console.Write("Enter your name: ");
            do
            {

                name = Console.ReadLine();


            } while (!IsValidText(name));
            User.firstName = name;

            string lastName;
            Console.Write("Enter your last name: ");
            do
            {

                lastName = Console.ReadLine();


            } while (!IsValidText(lastName));
            User.lastName = lastName;
            
            

            //Ask for age and check if age is valid
            string ageString;
            do
            {
                Console.Write("Enter your age: ");
                ageString = Console.ReadLine();
            }
            while (!IsValidNumber(ageString,out int age));

            //Ask for pets Count and check if  everything valid
            Console.WriteLine("Do you have a pet?(true or false): ");
            bool.TryParse(Console.ReadLine(),out bool hasPet);
            if (hasPet)
            {
                string petCountString;
                int petCount;
                do
                {
                    Console.WriteLine("How many pets?: ");
                    petCountString = Console.ReadLine();
                }while(!IsValidNumber(petCountString,out petCount));

                User.pets= GetPetsArray(petCount);
            }


            string favColorsCountString;
            int favColorsCount;
            do
            {
                Console.WriteLine("How many favColors?: ");
                favColorsCountString = Console.ReadLine();
            } while (!IsValidNumber(favColorsCountString, out favColorsCount));

            User.favColors=GetColors(favColorsCount);

            return User;
        }

        static string[] GetPetsArray(int petCount)
        {
            string[] pets = new string[petCount];
            string petName;
            for (int i = 0; i < pets.Length; i++)
            {
                Console.WriteLine($"Enter your {i + 1} Pet Name Please: ");

                while (true)
                {
                   
                    petName = Console.ReadLine();
                    if (IsValidText(petName))
                    {
                        pets[i]=petName;
                        break;
                    }
                }
                

            }

            return pets;
        }

        static string[] GetColors(int colorsCount)
        {
            string[] colors = new string[colorsCount];
            string colorName;
            for (int i = 0; i < colors.Length; i++)
            {
                Console.WriteLine($"Enter your {i + 1} Color Name Please: ");

                while (true)
                {

                    colorName = Console.ReadLine();
                    if (IsValidText(colorName))
                    {
                        colors[i] = colorName ;
                        break;
                    }
                }


            }

            return colors;
        }

        static bool IsValidNumber(string ageStr, out int age)
        {
            return int.TryParse(ageStr, out age) ? (age > 0 ? true : false) : false;
        }

        static bool IsValidText(string text)
        {
            bool hasDigit = text.Any(c =>char.IsDigit(c));
            bool hasSymbol = text.Any(c => char.IsSymbol(c));
            bool isEmpty = string.IsNullOrEmpty(text);
            bool isWhiteSpace = string.IsNullOrWhiteSpace(text);

            if (hasDigit || hasSymbol || isEmpty || isWhiteSpace)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please Enter Correctly!");
                Console.ResetColor();
                return false;
            }
            else
            {
                return true;
            }
            
        }

        static void ShowUserInfo((string firstName, string lastName, int age, string[] pets, string[] favColors) user)
        {
            Console.WriteLine($"UserName: {user.firstName}\n"
                + $"LastName: {user.lastName}\n"
                + $"Age: {user.age}");

            Console.WriteLine("Your Pets: ");
            if (user.pets != null)
            {
                Array.ForEach(user.pets, Console.WriteLine);
            }
            else
            {
                Console.WriteLine("No pets!");
            }
            
            

            Console.WriteLine("Your Favorite Colors: ");
            foreach (string color in user.favColors)
            {
                Console.WriteLine($"-----{color}-----");
            }
               
        }
    }
}
