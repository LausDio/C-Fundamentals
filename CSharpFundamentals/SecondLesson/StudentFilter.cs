/* 
6) Create struct Student with fields last name and group number.
   Create an array of students and output names of students from 
   a given group whose last names start with a given letter.
*/

namespace Fundamentals.SecondLesson
{
    internal class StudentFilter
    {
        // --- Struct definition ---
        private struct Student
        {
            public string LastName;
            public int GroupNumber;

            public Student(string lastName, int groupNumber)
            {
                LastName = lastName;
                GroupNumber = groupNumber;
            }

            public override string ToString() => $"{LastName} (Group {GroupNumber})";
        }

        // --- Main task method ---
        public static void Run()
        {
            Console.Write("Enter number of students: ");
            int count = InputCheck.ReadInt("→ ");

            Student[] students = new Student[count];

            Console.WriteLine("\nEnter student data:");
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Last name of student {i + 1}: ");
                string lastName = Console.ReadLine()?.Trim() ?? "Unknown";

                int group = InputCheck.ReadInt($"Group number of {lastName}: ");
                students[i] = new Student(lastName, group);
            }

            Console.Write("\nEnter group number to filter: ");
            int targetGroup = InputCheck.ReadInt();

            Console.Write("Enter starting letter of last name: ");
            char letter = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            // Filter logic (LINQ for clarity)
            var filtered = students
                .Where(s => s.GroupNumber == targetGroup &&
                            s.LastName.StartsWith(letter.ToString(), StringComparison.OrdinalIgnoreCase))
                .ToArray();

            // Output results
            Console.WriteLine($"\nStudents from group {targetGroup} whose last name starts with '{letter}':");

            if (filtered.Length == 0)
            {
                Console.WriteLine("No matches found.");
            }
            else
            {
                foreach (var s in filtered)
                    Console.WriteLine($" - {s.LastName}");
            }
        }
    }
}
