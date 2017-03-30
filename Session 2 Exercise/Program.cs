using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_2_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName;
            string userNameLogin;
            string passWord;
            string passWordLogin;
            string passWordRe;

            //Console.WriteLine("Please input your username:");
            //userName = Console.ReadLine().Trim();
            //Console.WriteLine(userName);
            //Console.ReadKey();
            //Keep inputing user name if is empty
            do
            {
                Console.WriteLine("Please input your username:");
                userName = Console.ReadLine().Trim();
            } while (userName == "");

            //Keep inputing password if password is empty
            do
            {
                Console.WriteLine("Please input your password:");
                passWord = Console.ReadLine().Trim();
            } while (passWord == "");

            ////Keep inputing password if password again is empty
            //do
            //{
            //    Console.WriteLine("Please input your password again:");
            //    passWordRe = Console.ReadLine().Trim();
            //} while (passWordRe == "");

            //Keep inputing password if passwords do not match
            do
            {
                Console.WriteLine("Please input your password again:");
                passWordRe = Console.ReadLine().Trim();
                if (!passWord.Equals(passWordRe))
                {
                    Console.WriteLine("Password does not match");
                }
            } while (passWord != passWordRe);

            //Press "L" to login
            do
            {
                Console.WriteLine("Please press 'L' button to login.");
            } while (Console.ReadLine()!="L");

            //Input username
            do
            {
                Console.WriteLine("Please input username:");
                userNameLogin = Console.ReadLine().Trim();
                if (!userName.Equals(userNameLogin))
                {
                    Console.WriteLine("Username does not exist.");
                }
            } while (userNameLogin=="" || userNameLogin != userName);

            //Input password
            do
            {
                Console.WriteLine("Please input password:");
                passWordLogin = Console.ReadLine().Trim();
                if (!passWord.Equals(passWordLogin))
                {
                    Console.WriteLine("Wrong password.");
                }
            } while (passWordLogin=="" || passWord != passWordLogin);

            Console.WriteLine("Welcome {0}...",userName);
            Console.ReadKey();
        }
    }
}
