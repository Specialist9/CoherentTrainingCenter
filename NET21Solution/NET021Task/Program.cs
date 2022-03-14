using NET021Task;

try
{
    Author JackBlack = new("Jack", "Black");
    //Author JackWhite = new("", "White");
    Book newBook1 = new("1234567891234", "NewTitle1", new(), new Author[1]);
    Book newBook2 = new("123-4-56-789123-4", "NewTitle2", DateTime.Now, new Author[]{ JackBlack });
    Book newBook3 = new("1234567891236", "NewTitle3", new(2022, 03, 14), new []{new Author("Mike", "Brown"), JackBlack}) ;

    Console.WriteLine(newBook1.Equals(newBook2));

}
catch (ArgumentOutOfRangeException argRangeEx)
{
    Console.WriteLine(argRangeEx.Message);
}
catch (ArgumentException argEx)
{
    Console.WriteLine(argEx.Message);
}