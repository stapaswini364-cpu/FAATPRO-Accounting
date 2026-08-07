using System;

string hash = BCrypt.Net.BCrypt.HashPassword("Admin@123");

Console.WriteLine(hash);