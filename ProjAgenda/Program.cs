using ProjAgenda;

List<Contact> phoneBook = new List<Contact>();

Contact contact = new("Giovani Ferro", "16 997756688");

contact.Address.EditStreet("Rua nove de julho, 1910");
contact.Address.EditPostalCode("15990-000");
contact.Address.EditState("São Paulo");
contact.Address.EditCountry("Basil");
contact.Address.EditCity("Matão");

phoneBook.Add(contact);

Contact contact3 = new("Beatriz", "16 997756688");

contact3.Address.EditStreet("Rua 6, 1856");
contact3.Address.EditPostalCode("15990-000");
contact3.Address.EditState("São Paulo");
contact3.Address.EditCountry("Basil");
contact3.Address.EditCity("Matão");

phoneBook.Add(contact3);

Contact contact2 = new("Felipe", "16 997756688");

contact2.Address.EditStreet("Rua 15 de novembro, 185");
contact2.Address.EditPostalCode("15990-000");
contact2.Address.EditState("São Paulo");
contact2.Address.EditCountry("Basil");
contact2.Address.EditCity("Matão");

phoneBook.Add(contact2);

//phoneBook.Remove(contact);



PrintPhoneBook(phoneBook);

void PrintPhoneBook(List<Contact> list)
{
    foreach (var item in list)
    {
        Console.WriteLine(item);
    }
}