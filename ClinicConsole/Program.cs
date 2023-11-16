using ClinicServiceNamespace;

namespace ClinicConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Нажмите на любую клавишу для загрузки данных...");
            Console.WriteLine();
            Console.ReadKey();

            ClinicClient clinicClient = new ClinicClient("http://localhost:5274", new HttpClient());

            List<Client> clients = clinicClient.ClientGetAllAsync().Result.ToList();
            foreach (Client client in clients)
            {
                Console.WriteLine("Документ: " + client.Document);
                Console.WriteLine("Фамилия: " + client.SurName);
                Console.WriteLine("Имя: " + client.FirstName);
                Console.WriteLine("Очество: " + client.Patronymic);
                Console.WriteLine("Дата рождения: " + client.Birthday);
                Console.WriteLine();
            }

            Console.WriteLine("OK");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}