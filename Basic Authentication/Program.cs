using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Authentication
{
    internal class Program
    {
        static List<User> Accounts = new List<User>();
        static void Main(string[] args)
        {
            string userInput;
            do
            {
                userInput = PemilihanMenu();
                ProsesInput(userInput);
            } while (userInput != "5");
        }
        static string PemilihanMenu()
        {
            Console.WriteLine("**BASIC USER AUTHENTICATION**");
            Console.WriteLine("1. Create");
            Console.WriteLine("2. Show");
            Console.WriteLine("3. Search/Remove");
            Console.WriteLine("4. Login");
            Console.WriteLine("5. Exit");
            Console.Write("Input : "); return Console.ReadLine();
        }
        static void ProsesInput(string input)
        {
            switch (input)
            {
                case "1":
                    CreateUser();
                    break;
                case "2":
                    ShowUser();
                    break;
                case "3":
                    SearchOrRemove();
                    break;
                case "4":
                    Login();
                    break;
                case "5":
                    Exit();
                    return;
            }
            Console.Clear();
        }
        static void PrintUserInfo(User user)
        {
            Console.WriteLine("==========================");
            Console.Write("First Name: ");
            Console.WriteLine(user.GetFirstName());
            Console.Write("Last Name: ");
            Console.WriteLine(user.GetLastName());
            Console.Write("Username: ");
            Console.WriteLine(user.GetUserName());
            Console.Write("Password: ");
            Console.WriteLine(user.GetPassword());
            Console.WriteLine("==========================");
        }
        static void CreateUser()
        {
            string firstName, lastName, userName, password, patternA, patternB, patternC, patternD;
            Boolean validPassword;
            Console.Clear();
            Console.WriteLine("==CREATE USER==");
            do
            {
                Console.Write("First Name: ");
                firstName = Console.ReadLine();
                if (firstName.Contains(" "))
                {
                    Console.WriteLine("Tidak boleh ada spasi.");
                }
                if (firstName.Length < 2)
                {
                    Console.WriteLine("Tidak boleh kurang dari dua huruf");
                }
            } while (firstName.Contains(" ") || firstName.Length < 2);
            do
            {
                Console.Write("Last Name: ");
                lastName = Console.ReadLine();
                if (lastName.Contains(" "))
                {
                    Console.WriteLine("Tidak boleh ada spasi.");
                }
                if (lastName.Length < 2)
                {
                    Console.WriteLine("Tidak boleh kurang dari dua huruf");
                }
            } while (lastName.Contains(" ") || lastName.Length < 2);
            Console.Write("Username: ");
            userName = $"{firstName.Substring(0, 2)}{lastName.Substring(0, 2)}".ToLower();
            //add a check here for a potential duplicate username
            int duplicate = 0;
            for (int i = 0; i < Accounts.Count; i++)
            {
                if (Accounts[i].GetUserName() == userName)
                {
                    duplicate += 1;
                }
            }
            if (duplicate > 0)
            {
                userName += duplicate;
            }
            Console.WriteLine(userName);
            //password pattern requirements
            patternA = @"[a-z]";
            patternB = @"[A-Z]";
            patternC = @"[0-9]";
            patternD = @"[^A-Za-z0-9]";
            do
            {
                Console.WriteLine("Password (Minimal 8 karakter mengandung alfabet besar & kecil, numerik, dan non-alfanumerik) : ");
                password = Console.ReadLine();
                validPassword = password.Length >= 8
                                && Regex.IsMatch(password, patternA)
                                && Regex.IsMatch(password, patternB)
                                && Regex.IsMatch(password, patternC)
                                && Regex.IsMatch(password, patternD);
                if (!validPassword)
                {
                    Console.WriteLine("Error: password tidak valid.");
                }
            } while (!validPassword);
            string hashPassword = BCrypt.Net.BCrypt.HashPassword(password);
            Accounts.Add(new User(firstName, lastName, userName, hashPassword));
        }
        static void ShowUser()
        {
            Console.Clear();
            Console.WriteLine("==SHOW USER==");
            if (Accounts.Count == 0)
            {
                Console.WriteLine("No user exists.\n(Press ENTER to go back)");
                Console.Read();
                return;
            }
            for (int i = 0; i < Accounts.Count; i++)
            {
                PrintUserInfo(Accounts[i]);
            }
            Console.ReadKey();
        }
        static void SearchOrRemove()
        {
            Console.Clear();
            Console.WriteLine("==SEARCH/REMOVE_USER==");
            if (Accounts.Count == 0)
            {
                Console.WriteLine("No user exists.\n(Press ENTER to go back)");
                Console.Read();
                return;
            }
            string keyword, reference;
            List<int> userIdx = new List<int>();
            Console.Write("Enter keyword (ref. first name and last name): ");
            keyword = Console.ReadLine();
            for (int i = 0; i < Accounts.Count; i++)
            {
                reference = Accounts[i].GetFirstName() + Accounts[i].GetLastName();
                if (reference.ToLower().Contains(keyword.ToLower()))
                {
                    userIdx.Add(i);
                }
            }
            int foundCount = userIdx.Count;
            if (foundCount > 0)
            {
                string ans, usrname;
                switch (foundCount)
                {
                    case 1:
                        User choosen = Accounts[userIdx[0]];
                        PrintUserInfo(choosen);
                        usrname = choosen.GetUserName();
                        Console.WriteLine($"Apakah anda ingin menghapus {usrname}? (Y/y)Ya / (T/t)Tidak");
                        ans = Console.ReadLine();
                        if (ans.ToLower() == "y")
                        {
                            Accounts.Remove(choosen);
                            Console.WriteLine($"{usrname} Terhapus.");
                        }
                        break;
                    case int n when (n > 1):
                        for (int i = 0; i < userIdx.Count; i++)
                        {
                            Console.WriteLine($"({i + 1})");
                            PrintUserInfo(Accounts[userIdx[i]]);
                        }
                        Console.WriteLine("Apakah anda ingin menghapus salah satu data? (Y)Ya / (T)Tidak");
                        ans = Console.ReadLine();
                        if (ans.ToLower().Contains("y"))
                        {
                            Console.Write("Pilih nomor dari daftar yang ingin dihapus: ");
                            int choiceNum = int.Parse(Console.ReadLine());
                            choosen = Accounts[userIdx[choiceNum - 1]];
                            PrintUserInfo(choosen);
                            usrname = choosen.GetUserName();
                            Console.WriteLine($"Apakah anda ingin menghapus {usrname}? (Y/y)Ya / (T/y)Tidak");
                            ans = Console.ReadLine();
                            if (ans.ToLower() == "y")
                            {
                                Accounts.Remove(choosen);
                                Console.WriteLine($"{usrname} Terhapus.");
                            }
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine("No user found.");
            }
            Console.ReadKey();
        }
        static void Login()
        {
            Console.WriteLine("==LOGIN_USER==");
            Console.Clear();
            if (Accounts.Count == 0)
            {
                Console.WriteLine("No user exists.\n(Press ENTER to go back)");
                Console.Read();
                return;
            }
            string username, password;
            User loginTarget = null;
            Console.WriteLine("(Enter 'x' to return to main menu)");
            Boolean usernameFound = false;
            do
            {
                Console.Write("Enter username: ");
                username = Console.ReadLine();
                for (int i = 0; i < Accounts.Count; i++)
                {
                    if (Accounts[i].GetUserName() == username)
                    {
                        usernameFound = true;
                        loginTarget = Accounts[i];
                        break;
                    }
                }
                if (username.ToLower() == "x")
                {
                    Console.Clear();
                    return;
                }
                else if (!usernameFound)
                {
                    Console.WriteLine("username doesn't exist.");
                }
            } while (!usernameFound);
            Boolean passwordMatch = false;
            do
            {
                Console.Write("Enter password: ");
                password = Console.ReadLine();
                if (BCrypt.Net.BCrypt.Verify(password, loginTarget.GetPassword()))
                {
                    passwordMatch = true;
                }
                else if (password.ToLower() == "x")
                {
                    Console.Clear();
                    return;
                }
                else if (!passwordMatch)
                {
                    Console.WriteLine("Wrong password.");
                }
            } while (!passwordMatch);
            Console.WriteLine("Login Success.");
            Console.ReadKey();
        }
        static void Exit()
        {
            Console.WriteLine("Selamat Tinggal.");
        }
    }
}
