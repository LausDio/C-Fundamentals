// 3) Show HTTP error name by code (400–404)
namespace Fundamentals.SecondLesson
{
    internal class CheckHttpError
    {
        public enum HttpError
        {
            BadRequest = 400,
            Unauthorized,
            PaymentRequired,
            Forbidden,
            NotFound
        };

        public static void Run()
        {
            int code = InputCheck.ReadIntInRange(400, 404, "Enter HTTP error code (400–404): ");
            HttpError error = (HttpError)code;
            Console.WriteLine($"Error {code}: {error}");
        }
    }
}