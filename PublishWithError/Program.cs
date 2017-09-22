namespace PublishWithError
{
    using System;

    using Models.Entities;

    /// <summary>
    /// The program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Main(string[] args)
        {
            var student = new User { Name = "Bob" };

            Console.WriteLine($"Hello {student.Name}!");
        }
    }
}
