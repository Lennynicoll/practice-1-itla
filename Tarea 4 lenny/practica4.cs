using System;
using System.Collections.Generic;
using System.Linq;

﻿//Lenny Nicoll Nuñez matricula: 2025-1878

public class Contact
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

    public Contact(int id, string name, string phone, string email, string address)
    {
        Id = id;
        Name = name;
        Phone = phone;
        Email = email;
        Address = address;
    }
}

public class AddressBook
{
    private List<Contact> contactList = new List<Contact>();
    private int idCounter = 1;

    public void Add()
    {
        Console.WriteLine("\n--- AGREGAR NUEVO CONTACTO ---");
        Console.Write("Nombre: ");
        string name = Console.ReadLine();
        Console.Write("Teléfono: ");
        string phone = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();
        Console.Write("Dirección: ");
        string address = Console.ReadLine();

        Contact newContact = new Contact(idCounter++, name, phone, email, address);
        contactList.Add(newContact);
        Console.WriteLine("\n>> ¡Contacto guardado con éxito!");
    }

    public void ShowAll()
    {
        Console.WriteLine("\n--- LISTA DE CONTACTOS ---");
        if (contactList.Count == 0)
        {
            Console.WriteLine("La agenda está vacía actualmente.");
            return;
        }

        Console.WriteLine("ID | Nombre | Teléfono");
        Console.WriteLine("------------------------------");
        foreach (var c in contactList)
        {
            Console.WriteLine($"{c.Id} | {c.Name} | {c.Phone}");
        }
    }

    public void Search()
    {
        Console.Write("\nIngrese el ID a buscar: ");
        if (int.TryParse(Console.ReadLine(), out int searchId))
        {
            var contact = contactList.FirstOrDefault(x => x.Id == searchId);
            if (contact != null)
            {
                Console.WriteLine($"\n--- CONTACTO ENCONTRADO ---");
                Console.WriteLine($"Nombre: {contact.Name}");
                Console.WriteLine($"Teléfono: {contact.Phone}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine($"Dirección: {contact.Address}");
            }
            else
            {
                Console.WriteLine("No se encontró ningún contacto con ese ID.");
            }
        }
    }

    public void Edit()
    {
        Console.Write("\nID del contacto a editar: ");
        if (int.TryParse(Console.ReadLine(), out int editId))
        {
            var c = contactList.FirstOrDefault(x => x.Id == editId);
            if (c != null)
            {
                Console.Write($"Nombre actual ({c.Name}). Nuevo nombre: ");
                string newName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newName)) c.Name = newName;

                Console.Write($"Teléfono actual ({c.Phone}). Nuevo teléfono: ");
                string newPhone = Console.ReadLine();
                if (!string.IsNullOrEmpty(newPhone)) c.Phone = newPhone;

                Console.WriteLine("\n>> Datos actualizados correctamente.");
            }
            else
            {
                Console.WriteLine("El ID ingresado no es válido.");
            }
        }
    }

    public void Delete()
    {
        Console.Write("\nID del contacto a eliminar: ");
        if (int.TryParse(Console.ReadLine(), out int deleteId))
        {
            var c = contactList.FirstOrDefault(x => x.Id == deleteId);
            if (c != null)
            {
                Console.Write($"¿Seguro que quieres borrar a {c.Name}? (1. Si / 2. No): ");
                if (Console.ReadLine() == "1")
                {
                    contactList.Remove(c);
                    Console.WriteLine("\n>> Contacto eliminado.");
                }
                else
                {
                    Console.WriteLine("\nOperación cancelada.");
                }
            }
        }
    }
}

class Program
{
    static void Main()
    {
        AddressBook myAgenda = new AddressBook();
        bool exit = false;

        Console.WriteLine("Mi Agenda linda");
        Console.WriteLine("Bienvenido a tu lista de contactos POO");

        while (!exit)
        {
            Console.WriteLine("\n--- MENÚ ---");
            Console.WriteLine("1. Agregar Contacto");
            Console.WriteLine("2. Ver Lista");
            Console.WriteLine("3. Buscar por ID");
            Console.WriteLine("4. Editar Contacto");
            Console.WriteLine("5. Eliminar Contacto");
            Console.WriteLine("6. Salir");
            Console.Write("\nElige la opcion: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1": myAgenda.Add(); break;
                case "2": myAgenda.ShowAll(); break;
                case "3": myAgenda.Search(); break;
                case "4": myAgenda.Edit(); break;
                case "5": myAgenda.Delete(); break;
                case "6": exit = true; break;
                default: Console.WriteLine("Esa opción no existe, intente de nuevo Por favor."); break;
            }
        }
        Console.WriteLine("\nCerranda la Agenda Linda... ");
    }
}
