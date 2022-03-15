using NET021Task;

try
{
    Author JackBlack = new("Jack", "Black");
    //Author JackWhite = new("", "White");
    Book newBook1 = new("1234567891234", "NewTitle11", new(), new Author[1]);
    Book newBook2 = new("123-4-56-789123-5", "NewTitle2", DateTime.Now, new Author[]{ JackBlack });
    Book newBook3 = new("1234567891236", "NewTitle0", new(2022, 03, 14), new []{new Author("Mike", "Brown"), JackBlack}) ;

    Console.WriteLine(newBook1.Equals(newBook2));

    Catalog newCatalog = new Catalog();
    newCatalog.AddBook(newBook1);
    newCatalog.AddBook(newBook2);
    newCatalog.AddBook(newBook3);

    //Console.WriteLine(newCatalog["1234567891236"].ToString());
    foreach(var item in newCatalog)
    {
        Console.WriteLine(item.ToString());
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