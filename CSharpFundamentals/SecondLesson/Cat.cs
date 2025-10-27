/* 11) Create class Cat. The cat should have a property "fullness level" and method "eat
something". Create enum Food (fish, mouse, ...). Each type of food should change the
level of satiety differently.*/
namespace Fundamentals.SecondLesson
{
    public class Cat
    {
        int fullnessLevel;
        public int FullnessLevel
        {
            get => fullnessLevel;
            private set => fullnessLevel = Math.Clamp(value, 0, 100);
        }
        public Cat(int initialFullness = 50)
        {
            FullnessLevel = initialFullness;
        }
        public void EatSomething(Food food)
        {
            int change = food switch
            {
                Food.Fish => 25,
                Food.Mouse => 15,
                Food.Chicken => 20,
                Food.Milk => 10,
                Food.Grass => -5, // makes the cat sick or less full
                _ => 0
            };
            FullnessLevel += change;
            Console.WriteLine($"😺 The cat ate {food} and its fullness is now {FullnessLevel}.");
        }
        public override string ToString()
        {
            string mood = FullnessLevel switch
            {
                < 20 => "hungry",
                < 60 => "content",
                < 90 => "happy",
                _ => "sleepy 😴"
            };
            return $"Cat fullness: {FullnessLevel} ({mood})";
        }
        public static void GreetCat()
        {
            Console.WriteLine("🐾 Meet your cat!");

            Cat myCat = new Cat(initialFullness: 40);
            Console.WriteLine(myCat); // uses ToString()

            Console.WriteLine("\nLet's feed the cat!");

            Console.WriteLine("Available foods:");
            foreach (var food in Enum.GetValues(typeof(Food)))
            {
                Console.WriteLine($" - {food}");
            }

            Console.Write("\nEnter food name (Fish, Mouse, Chicken, Milk, Grass): ");
            string? input = Console.ReadLine();

            if (Enum.TryParse(input, ignoreCase: true, out Food chosenFood))
            {
                myCat.EatSomething(chosenFood);
            }
            else
            {
                Console.WriteLine("That’s not valid food!");
            }

            Console.WriteLine("\nCurrent cat status:");
            Console.WriteLine(myCat);
        }
    }

    public enum Food
    {
        Fish,
        Mouse,
        Chicken,
        Milk,
        Grass
    }
}