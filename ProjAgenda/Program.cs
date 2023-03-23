using ProjAgenda;

List<Contact> phoneBook = new List<Contact>();

if (File.Exists("AgendaContatos.txt"))
{
    try
    {
        phoneBook = ReadFile("AgendaContatos.txt");
    }
    catch (Exception e)
    {
        Console.WriteLine("Leitura não foi possível");
        Console.WriteLine(e);
    }
}

do
{
    int op = Menu();
    switch (op)
    {
        case 1:
            Contact contact = CreateContact();
            if (VerifyDups(contact))
            {
                Console.WriteLine("Número duplicado");
                Console.WriteLine("Aperte qualquer tecla para continuar");
                Console.ReadKey();
            }
            else
            {
                phoneBook.Add(contact);
            }
            phoneBook = phoneBook.OrderBy(x => x.Name).ToList();
            WriteFile(phoneBook, "AgendaContatos.txt");
            Console.Clear();
            break;

        case 2:
            EditContact(FindContact());
            WriteFile(phoneBook, "AgendaContatos.txt");
            Console.Clear();
            break;

        case 3:
            phoneBook.Remove(FindContact());
            WriteFile(phoneBook, "AgendaContatos.txt");
            Console.Clear();
            break;

        case 4:
            PrintPhoneBook(phoneBook);
            Console.WriteLine("Aperte qualquer tecla para continuar");
            Console.ReadKey();
            break;

        case 5:
            FindByInitialLetter();
            Console.WriteLine("Aperte qualquer tecla para continuar");
            Console.ReadKey();
            break;

        case 6:
            System.Environment.Exit(0);
            break;

        default:
            Console.WriteLine("Opção inválida");
            Console.Clear();

            break;
    }

} while (true);

void FindByInitialLetter()
{
    Console.Clear();

    Console.WriteLine("Informe a inicial do contato: ");
    var name = Console.ReadLine();

    foreach (var item in phoneBook)
    {
        if (item.Name.StartsWith(name))
        {
            Console.WriteLine(item);
        }
    }
}

bool VerifyDups(Contact contact)
{
    foreach (var item in phoneBook)
    {
        if (item.Phone == contact.Phone)
        {
            return true;
        }
    }
    return false;
}

Contact CreateContact()
{
    Console.Clear();
    Console.Write("Informe o nome: \n");
    string name = Console.ReadLine();
    Console.Write("Informe o telefone: \n");
    string phone = Console.ReadLine();
    Contact contact = new Contact(name, phone);

    return contact;
}

Contact FindContact()
{
    Console.WriteLine("Informe o contato: ");
    var name = Console.ReadLine();

    foreach (var item in phoneBook)
    {
        if (item.Name.Equals(name))
        {
            return item;
        }
    }
    return null;
}

void EditContact(Contact contact)
{
    bool condition = true;
    do
    {
        int aux = EditMenu();
        switch (aux)
        {
            case 1:
                Console.WriteLine("Digite o nome do contato");
                contact.Name = Console.ReadLine();
                Console.Clear();
                break;

            case 2:
                Console.Write("Digite o telefone do contato: ");
                contact.Phone = Console.ReadLine();
                Console.Clear();
                break;

            case 3:
                Console.Write("Digite o email do contato: ");
                contact.Email = Console.ReadLine();
                Console.Clear();

                break;

            case 4:
                Console.Write("Digite o endereço: ");
                contact.Address.Street = Console.ReadLine();
                Console.Write("Digite a cidade: ");
                contact.Address.City = Console.ReadLine();
                Console.Write("Digite o estado: ");
                contact.Address.State = Console.ReadLine();
                Console.Write("Digite o país: ");
                contact.Address.Country = Console.ReadLine();
                Console.Write("Digite o CEP: ");
                contact.Address.PostalCode = Console.ReadLine();
                break;

            case 5:
                Console.Clear();
                condition = false;
                break;

            default:
                Console.WriteLine("Opção inválida");
                Console.Clear();

                break;
        }
    } while (condition);
    Console.WriteLine("Aperte qualquer tecla para continuar");
    Console.ReadKey();
}

void PrintPhoneBook(List<Contact> list)
{
    Console.Clear();

    foreach (var item in list)
    {
        Console.WriteLine(item);
    }
}

int Menu()
{
    Console.Clear();
    Console.WriteLine(">>>Menu de opções<<<\n\n1 - Insere Contato\n2 - Editar contato\n" +
        "3 - Remover contato\n4 - Mostrar contatos\n5 - Buscar contato por inicial\n6 - Sair\n\n" +
        "Escolha uma opção: ");

    var aux = IsInt();

    return aux;

}

int EditMenu()
{
    Console.Clear();
    Console.WriteLine(">>>Menu de opções<<<\n\n1 - Editar nome\n2 - Editar telefone\n" +
        "3 - Editar email\n4 - Editar endereço\n5 - Sair\n\n" +
        "Escolha uma opção: ");

    var aux = int.Parse(Console.ReadLine());

    return aux;
}

int IsInt()
{
    int value;
    do
    {
        if (!int.TryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine("Digite um número inteiro");
        }
        else
        {
            return value;
        }

    } while (true);
}

void WriteFile(List<Contact> contacts, string archiveName)
{
    try
    {
        StreamWriter sw = new StreamWriter(archiveName);
        foreach (var item in contacts)
        {
            sw.WriteLine(item.ToString());
        }
        sw.Close();
    }
    catch (Exception)
    {

        throw;
    }
    finally
    {
        Console.WriteLine("Arquivo gravado");
    }

}

List<Contact> ReadFile(string archiveName)
{
    List<Contact> contacts = new List<Contact>();
    Contact contact;
    Address address;
    try
    {
        string line;
        string[] aux = new string[8];
        StreamReader sr = new StreamReader(archiveName);
        while ((line = sr.ReadLine()) != null)
        {
            aux = line.Split(";");

            contact = new(aux[0], aux[1], aux[2]);
            address = new(aux[3], aux[4], aux[5], aux[6], aux[7]);
            contact.Address = address;

            contacts.Add(contact);
        }
        sr.Close();
        return contacts;
    }
    catch (Exception)
    {

        throw;
    }
    finally
    {
        Console.WriteLine("Arquivo lido");
        Thread.Sleep(1000);
    }

}