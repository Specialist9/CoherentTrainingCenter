﻿using NET021Task;

try
{
    Author jackBlack = new("Jack", "Black");
    Author jackWhite = new("Jack", "White");
    Author[] twoAuthors = { jackBlack, jackWhite };
    Book newBook1 = new("1234567891234", "NewTitle11", new(), new[] { jackWhite});
    Book newBook2 = new("123-4-56-789123-5", "NewTitle2", DateTime.Now, new Author[]{ jackBlack });
    Book newBook3 = new("1234567891236", "NewTitle0", new(2022, 03, 14), new []{new Author("Mike", "Brown"), jackBlack});
    Book newBook4 = new("1234567891238", "NewTitle0", new(2022, 03, 14), twoAuthors);


    Console.WriteLine(newBook1.Equals(newBook2));

    Catalog newCatalog = new Catalog();
    newCatalog.AddBook(newBook1);
    newCatalog.AddBook(newBook2);
    newCatalog.AddBook(newBook3);
    newCatalog.AddBook(newBook4);


    //Console.WriteLine(newCatalog["1234567891236"].ToString());
    foreach (var item in newCatalog)
    {
        Console.WriteLine(item.ToString());
    }
    Console.WriteLine("//////////////////////////////");
    var temp = newCatalog.GetBooksByAuthorName("Jack", "Black");

    foreach (var item in temp)
    {
        Console.WriteLine(item);
    }



}
catch (ArgumentOutOfRangeException argRangeEx)
{
    Console.WriteLine(argRangeEx.Message);
}
catch (ArgumentException argEx)
{
    Console.WriteLine(argEx.Message);
}
catch(KeyNotFoundException keyEx)
{
    Console.WriteLine(keyEx.Message);
}
catch(InvalidOperationException invOpex)
{
    Console.WriteLine(invOpex.Message);
}