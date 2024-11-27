namespace NetCoreDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*int[] numbers = new int[] { 14, 2, 36, 4, 59 };
            Linq语句   Where
             * 
             IEnumerable<int> result = numbers.Where(x => x % 2 == 0);
             foreach (var item in result)
             {
                 Console.WriteLine(item);
             }*/

            //Linq语句 OrderBy
            /* IEnumerable<int> result = numbers.OrderBy(x => x);
             foreach (var item in result)
             {
                 Console.WriteLine(item);
             }*/
            /*using (MyDbContext db = new MyDbContext())
            {
                Book b1 = new Book { Title = "C#高级编程", Price = 100 ,PublishDate= DateTime.Now};
                Book b2 = new Book { Title = "C#netCore入门", Price = 200 };
                db.Books.Add(b1);
                db.Books.Add(b2);
                await db.SaveChangesAsync();
            }*/

        }
    }
}
