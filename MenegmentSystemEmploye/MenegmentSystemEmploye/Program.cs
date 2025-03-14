using System;

namespace MenegmentSystemEmploye
{
    internal class Program
    {
        public delegate void PromotionEventHandle(Employee sender, EventArgs e);
        static void Main(string[] args)
        {
            int option = 1;
            do
            {
                // Console.WriteLine("1. Add | 2. Update| 3. Delete | 4. GetAll  | 5. Getby  | 0. Exit");
                Console.WriteLine("1. Designer | 2. Developer | 3. Manager 0. Exit");
                Console.Write("Your option: ");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 0:
                        return;
                    case 1:
                        Designer designer = new Designer();
                        break;
                    case 2:
                        Developer developer = new Developer();
                        break;
                    case 3:
                        Manager manager = new Manager();
                        break;
                }
            }
            while (option != 0);
        }


    }
}
