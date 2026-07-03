namespace Exercise_6_Library_Management_System
{

    public class Book
    {
        public int bookId;
        public String title;
        public String Author;

        Book(int bookid,String title,String author)
        {
            bookId = bookid;
            title = title;
            Author = author;
        }
    }
    internal class Program
    {

        static void LinearSearch(Book [] books , String title)
        {
            bool found = false;

            foreach(Book book in books)
            {
                if(book.title.Equals(title))
                {
                    Console.WriteLine("Book found");
                    Console.WriteLine(book.bookId);
                    Console.WriteLine(book.Author);
                    Console.WriteLine(book.title);
                    found = true;
                    break;

                }
            }

            if(!found)
            {
                Console.WriteLine("Not found");
            }
        }

        static void BinarySearch(Book[] books, string title)
        {
            int low = 0;
            int high = books.Length - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;

                int result = string.Compare(books[mid].title, title, true);

                if (result == 0)
                {
                    Console.WriteLine(" Found:");
                    Console.WriteLine( books[mid].bookId);
                    Console.WriteLine( books[mid].title);
                    Console.WriteLine( books[mid].Author);
                    return;
                }
                else if (result < 0)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            Console.WriteLine("Book Not Found.");
        }

        static void Main(string[] args)
        {
            
            Book[] books =
            {
                new Book(101, "C Programming", "Dennis Ritchie"),
                new Book(102, "Data Structures", "Mark Allen"),
                new Book(103, "Java Programming", "James Gosling"),
                new Book(104, "Python Basics", "Guido van Rossum"),
                new Book(105, "Web Development", "Jon Duckett")
            };

            
            LinearSearch(books, "Python Basics");

            
            BinarySearch(books, "Python Basics");

            Console.ReadKey();
        }
    }
}
