using ClinicServiceNamespace;

namespace ClinicConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClinicClient clinicClient = new ClinicClient("http://localhost:5274", new HttpClient());

            Console.WriteLine("Выберите действие...");
            Console.WriteLine("1 - получить список всех клиентов");
            Console.WriteLine("2 - получить данные о клиенте по ID");
            Console.WriteLine("3 - удалить клиента по ID");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("4 - получить список всех животных\n");

            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    List<Client> clients = clinicClient.ClientGetAllAsync().Result.ToList();
                    Console.WriteLine("СПИСОК ВСЕХ КЛИЕНТОВ\n");
                    foreach (Client client in clients)
                    {
                        Console.WriteLine("Документ: " + client.Document);
                        Console.WriteLine("Фамилия: " + client.SurName);
                        Console.WriteLine("Имя: " + client.FirstName);
                        Console.WriteLine("Очество: " + client.Patronymic);
                        Console.WriteLine("Дата рождения: " + client.Birthday);
                        Console.WriteLine();
                    }
                    break;
                case 2:
                    Console.WriteLine("Введите идентификатор (ID) клиента: \n");
                    int clientId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"ИНФОРМАЦИЯ О КЛИЕНТЕ С ID {clientId}\n");
                    Client curClient = clinicClient.ClientGetByIdAsync(clientId).Result;
                    Console.WriteLine("Документ: " + curClient.Document);
                    Console.WriteLine("Фамилия: " + curClient.SurName);
                    Console.WriteLine("Имя: " + curClient.FirstName);
                    Console.WriteLine("Очество: " + curClient.Patronymic);
                    Console.WriteLine("Дата рождения: " + curClient.Birthday);
                    Console.WriteLine();
                    break;
                case 3:
                    Console.WriteLine("Введите идентификатор (ID) клиента для удаления: \n");
                    int clientIdDel = Convert.ToInt32(Console.ReadLine());
                    int delClient = clinicClient.ClientDeleteAsync(clientIdDel).Result;
                    Console.WriteLine($"КЛИЕНТ {clientIdDel} УСПЕШНО УДАЛЁН");
                    Console.WriteLine();
                    break;
                case 4:
                    List<Pet> pets = clinicClient.PetGetAllAsync().Result.ToList();
                    Console.WriteLine("СПИСОК ВСЕХ ЖИВОТНЫХ\n");
                    foreach (Pet pet in pets)
                    {
                        Console.WriteLine("Кличка: " + pet.Name);
                        Console.WriteLine("Дата рождения: " + pet.Birthday);
                        Client owner = clinicClient.ClientGetByIdAsync(pet.ClientId).Result;
                        Console.WriteLine("Владелец: " + owner.SurName + " " + owner.FirstName);
                        Console.WriteLine();
                    }
                    break;

            }
            Console.WriteLine("\nНажмите любую клавишу для завершения...");
            Console.ReadKey();
        }
    }
}