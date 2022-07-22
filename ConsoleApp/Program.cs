// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//membuat database code first
using Kelompok_1.Data;

DataContext _context = new DataContext();
_context.Database.EnsureCreated();
