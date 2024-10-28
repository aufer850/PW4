

using System.Xml.Linq;

namespace PW4
{
    public class Recipe
    {
        public string name { get; set; }
        public List<string> ingridients { get; set; }
        public virtual void Cook()
        {
            Console.WriteLine("You need to mix all the ingridients and cook them!");
        }

        public virtual TimeSpan CalculateTime() // час обчислюється в секундах, після чого переводиться у TimeSpan
        {
            Console.WriteLine("Used default time calculation");
            int TimeToCook = ingridients.Count * 300;
            return TimeSpan.FromSeconds(TimeToCook);
        }

        public virtual TimeSpan CalculateTime(bool CountDifficulty) // перевантаження методу
        {
            if (CountDifficulty)
            {
                int TimeToCook = ingridients.Count * 300 + 450;
                return TimeSpan.FromSeconds(TimeToCook);
            }
            else return CalculateTime();
        }
    }

    public class Salad : Recipe
    {
        public Salad()
        {
            name = "Salad";
            ingridients = ["cabbage", "tomato", "cucumber"];
        }
        public override void Cook()
        {
            Console.WriteLine("To cook calad, you need to cut all the ingridients and mix them into the bowl");
        }
        public override TimeSpan CalculateTime()
        {
            int TimeToCook = ingridients.Count * 180;
            return TimeSpan.FromSeconds(TimeToCook);
        }
        public override TimeSpan CalculateTime(bool CountDifficulty)
        {
            if (CountDifficulty)
            {
                int TimeToCook = ingridients.Count * 180 + 90;
                return TimeSpan.FromSeconds(TimeToCook);
            }
            else return base.CalculateTime();
        }

    }
    public class Soup : Recipe
    {
        public Soup()
        {
            name = "Soup";
            ingridients = ["potato", "meat", "onion", "carrot", "beans", "water"];
        }
        public override void Cook()
        {
            Console.WriteLine("To cook soup, you need to cut the ingridients and boil them together in a pot");
        }
        public override TimeSpan CalculateTime()
        {
            int TimeToCook = ingridients.Count * 180;
            return TimeSpan.FromSeconds(TimeToCook);
        }
        public override TimeSpan CalculateTime(bool CountDifficulty)
        {
            if (CountDifficulty)
            {
                int TimeToCook = ingridients.Count * 180 + 1800;
                return TimeSpan.FromSeconds(TimeToCook);
            }
            else return base.CalculateTime();
        }
    }
    public class Dessert : Recipe
    {
        public Dessert()
        {
            name = "Dessert";
            ingridients = ["dough", "chocolate", "sugar"];
        }
        public override void Cook()
        {
            Console.WriteLine("To cook dessert, you need to mix all the ingridients, give dough the form you want and then bake it in the oven");
        }
        public override TimeSpan CalculateTime()
        {
            int TimeToCook = ingridients.Count * 200;
            return TimeSpan.FromSeconds(TimeToCook);
        }
        public override TimeSpan CalculateTime(bool CountDifficulty)
        {
            if (CountDifficulty)
            {
                int TimeToCook = ingridients.Count * 200 + 2000;
                return TimeSpan.FromSeconds(TimeToCook);
            }
            else return base.CalculateTime();
        }
    }
    public class Mojito : Recipe
    {
        public Mojito()
        {
            name = "Mojito";
            ingridients = ["lime", "ice", "mint","sprite"];
        }
        public override void Cook()
        {
            Console.WriteLine("To make mojito, just mix all of the ingridients in a glass ");
        }
        public override TimeSpan CalculateTime()
        {
            int TimeToCook = ingridients.Count * 60;
            return TimeSpan.FromSeconds(TimeToCook);
        }
        public override TimeSpan CalculateTime(bool CountDifficulty)
        {
            if (CountDifficulty)
            {
                int TimeToCook = ingridients.Count * 60 + 30;
                return TimeSpan.FromSeconds(TimeToCook);
            }
            else return base.CalculateTime();
        }
    }
    public class CheeseSauce : Recipe
    {
        public CheeseSauce()
        {
            name = "cheese sauce";
            ingridients = ["cheese", "sour cream"];
        }
        public override void Cook()
        {
            Console.WriteLine("To make cheese sauce, you need to melt the cheese if frying pan, and then add sour cream until they mix together in a sauce");
        }
        public override TimeSpan CalculateTime()
        {
            int TimeToCook = ingridients.Count * 50;
            return TimeSpan.FromSeconds(TimeToCook);
        }
        public override TimeSpan CalculateTime(bool CountDifficulty)
        {
            if (CountDifficulty)
            {
                int TimeToCook = ingridients.Count * 50 + 120;
                return TimeSpan.FromSeconds(TimeToCook);
            }
            else return base.CalculateTime();
        }
    }


    internal class Program
    {
        public static void Line()
        {
            Console.WriteLine("---===============---");
        }
        public static void PrintIngridients(Recipe R)
        {
            Console.WriteLine("The ingridients are: ");
            for (int i = 0; i < R.ingridients.Count; i++)
            {
                string v = ", ";
                if (i == R.ingridients.Count - 1) v = ".";
                Console.Write(R.ingridients[i] + v);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Application started!");
            Line();
            while (true)
            {
                Recipe Dish = new Recipe();
                try
                {
                    int RecipeChoice;
                    
                    while (true) // головне меню, вибір блюда
                    {
                        Console.WriteLine("What do you want to cook?");
                        Console.WriteLine("1. Salad");
                        Console.WriteLine("2. Soup");
                        Console.WriteLine("3. Dessert");
                        Console.WriteLine("4. Mojito");
                        Console.WriteLine("5. Cheese sauce");
                        Console.WriteLine("0. Exit");
                        RecipeChoice = Convert.ToInt32(Console.ReadLine());
                        switch (RecipeChoice)
                        {
                            case 0: Environment.Exit(0); break;
                            case 1: Dish = new Salad(); break;
                            case 2: Dish = new Soup(); break;
                            case 3: Dish = new Dessert(); break;
                            case 4: Dish = new Mojito(); break;
                            case 5: Dish = new CheeseSauce(); break;
                            default: Console.WriteLine("Wrong input data, please try again!"); continue; break;
                        }
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine("You choosed " + Dish.name.ToLower() + "!");
                    Line();
                    int ingridientschoice;
                    while (true) // чи бажає користувач змінити інгрідієнти?
                    {
                        PrintIngridients(Dish);
                        Console.WriteLine();
                        Console.WriteLine("Would you like to change them?");
                        Console.WriteLine("1. Yes");
                        Console.WriteLine("2. No");
                        Console.WriteLine("0. Exit program");
                        ingridientschoice = Convert.ToInt32(Console.ReadLine());
                        switch (ingridientschoice)
                        {
                            case 0: Environment.Exit(0); break;
                            case 1: break; 
                            case 2: break;
                            default: Console.WriteLine("Wrong input data, please try again!"); continue; break;
                        }
                        break;
                    }
                    Console.Clear();
                    if(ingridientschoice == 1)
                    {
                        Dish.ingridients.Clear();
                        Console.WriteLine("Enter your ingridients one by one! Enter 0 to stop!");
                        Line();
                        while (true)
                        {
                            string Ing = Console.ReadLine();
                            if (Ing == "0")
                            {
                                if (Dish.ingridients.Count > 0) break; else Console.WriteLine("Please enter at least 1 ingridient!");
                            }
                            else { Dish.ingridients.Add(Ing.ToLower()); }

                        }
                        Console.Clear();
                        PrintIngridients(Dish);
                        Line();
                    }
                    int calculationchoice;
                    while (true)
                    {
                        Console.WriteLine("Let's count the time to cook " + Dish.name.ToLower());
                        Line();
                        Console.WriteLine("1. Default calculation");
                        Console.WriteLine("2. Include the recipe difficulty");
                        Console.WriteLine("0. Exit program");
                        calculationchoice = Convert.ToInt32(Console.ReadLine());
                        switch (calculationchoice)
                        {
                            case 0: Environment.Exit(0); break;
                            case 1: break;
                            case 2: break;
                            default: Console.WriteLine("Wrong input data, please try again!"); continue; break;
                        }
                        break;
                    }
                    TimeSpan CookTime;
                    if (calculationchoice == 1) CookTime = Dish.CalculateTime(); else CookTime = Dish.CalculateTime(true);
                    Console.Clear();
                    Console.WriteLine("Summary");
                    Line();
                    PrintIngridients(Dish);
                    Dish.Cook();
                    Console.WriteLine("Time needs to cook " + Dish.name + " : " + CookTime.ToString());
                    Console.WriteLine("Good luck cooking!");
                    Line();
                    int exitchoice;
                    while (true)
                    {
                        Console.WriteLine("Please enter 1 to start again or press 0 to exit!");
                        exitchoice = Convert.ToInt32(Console.ReadLine());
                        switch (exitchoice)
                        {
                            case 0: Environment.Exit(0); break;
                            case 1: break;
                            default: Console.WriteLine("Wrong input data, please try again!"); continue; break;
                        }
                        Console.Clear();
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("An unexpected error occured! restarting the program...");
                    System.Threading.Thread.Sleep(5000);
                    Console.Clear();
                    continue;
                }
            }
        }
    }
}
