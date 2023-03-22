using System.Linq.Expressions;
using System.Xml.Linq;
using ProjAgenda;

List<Contact> phoneBook = new List<Contact>();

//Contact contact = new();//("Giovani Ferro", "16 997756688");

//contact.Address.EditStreet("Rua nove de julho, 1910");
//contact.Address.EditPostalCode("15990-000");
//contact.Address.EditState("São Paulo");
//contact.Address.EditCountry("Basil");
//contact.Address.EditCity("Matão");

//phoneBook.Add(contact);

//Contact contact3 = new("Beatriz", "16 997756688");

//contact3.Address.EditStreet("Rua 6, 1856");
//contact3.Address.EditPostalCode("15990-000");
//contact3.Address.EditState("São Paulo");
//contact3.Address.EditCountry("Basil");
//contact3.Address.EditCity("Matão");

//phoneBook.Add(contact3);

//Contact contact2 = new("Felipe", "16 997756688");

//contact2.Address.EditStreet("Rua 15 de novembro, 185");
//contact2.Address.EditPostalCode("15990-000");
//contact2.Address.EditState("São Paulo");
//contact2.Address.EditCountry("Basil");
//contact2.Address.EditCity("Matão");

//phoneBook.Add(contact2);

//phoneBook.Remove(contact);

PrintPhoneBook(phoneBook);

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
            Console.Clear();
            break;

        case 2:
            EditContact(FindContact());
            Console.Clear();
            break;

        case 3:
            phoneBook.Remove(FindContact());
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
    //Console.WriteLine("Adicione as informações necessárias a seguir: \n");
    //Console.Write("Nome: ");
    //contact.Name = Console.ReadLine() + "\n";
    //Console.Write("Telefone: ");
    //contact.EditPhone(Console.ReadLine());
    //Console.Write("\nEmail: ");
    //contact.EditEmail(Console.ReadLine());
    //Console.Write("\nEndereço: ");
    //contact.Address.EditStreet(Console.ReadLine());
    //Console.Write("Cidade: ");
    //contact.Address.EditCity(Console.ReadLine());

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
                contact.EditPhone(Console.ReadLine());
                Console.Clear();
                break;

            case 3:
                Console.Write("Digite o email do contato: ");
                contact.EditEmail(Console.ReadLine());
                Console.Clear();

                break;

            case 4:
                Console.Write("Digite o endereço: ");
                contact.Address.EditStreet(Console.ReadLine());
                Console.Write("Digite a cidade: ");
                contact.Address.EditCity(Console.ReadLine());
                Console.Write("Digite o estado: ");
                contact.Address.EditState(Console.ReadLine());
                Console.Write("Digite o país: ");
                contact.Address.EditCountry(Console.ReadLine());
                Console.Write("Digite o CEP: ");
                contact.Address.EditPostalCode(Console.ReadLine());
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

    var aux = int.Parse(Console.ReadLine());

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
