Console.WriteLine("Bienvenido a mi lista de Contactes");

//Lenny Nicoll Nuñez Rosario Matricula: 2025-1878

//names, lastnames, addresses, telephones, emails, ages, bestfriend
bool runing = true;
List<int> ids = new List<int>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, string> telephones = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();


while (runing)
{
    Console.WriteLine(@"1. Agregar Contacto     2. Ver Contactos    3. Buscar Contactos     4. Modificar Contacto   5. Eliminar Contacto    6. Salir");
    Console.WriteLine("Digite el número de la opción deseada");

    int typeOption = Convert.ToInt32(Console.ReadLine());

    switch (typeOption)
    {
        case 1:
            {
                //Console.WriteLine("Digite el nombre de la persona");
                //string name = Console.ReadLine();
                //Console.WriteLine("Digite el apellido de la persona");
                //string lastname = Console.ReadLine();
                //Console.WriteLine("Digite la dirección");
                //string address = Console.ReadLine();
                //Console.WriteLine("Digite el telefono de la persona");
                //string phone = Console.ReadLine();
                //Console.WriteLine("Digite el email de la persona");
                //string email = Console.ReadLine();
                //Console.WriteLine("Digite la edad de la persona en números");
                //int age = Convert.ToInt32(Console.ReadLine());
                //Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No");
                ////var temp = Convert.ToInt32(Console.ReadLine());
                ////bool isBestFriend;
                ////if (temp == 1)
                ////{ isBestFriend = true; }
                ////else
                ////{ isBestFriend = false; }
                //bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

                //var id = ids.Count + 1;
                //ids.Add(id);
                //names.Add(id, name);
                //lastnames.Add(id, lastname);
                //addresses.Add(id, address);
                //telephones.Add(id, phone);
                //emails.Add(id, email);
                //ages.Add(id, age);
                //bestFriends.Add(id, isBestFriend);

                AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);

            }
            break;
        case 2: //extract this to a method
            {
                Console.WriteLine($"Nombre          Apellido            Dirección           Telefono            Email           Edad            Es Mejor Amigo?");
                Console.WriteLine($"____________________________________________________________________________________________________________________________");
                foreach (var id in ids)
                {
                    var isBestFriend = bestFriends[id];

                    //string isBestFriendStr;

                    //if (isBestFriend == true)
                    //{
                    //    isBestFriendStr = "Si";
                    //}
                    //else {
                    //    isBestFriendStr = "No";
                    //}

                    string isBestFriendStr = (isBestFriend == true) ? "Si" : "No";
                    Console.WriteLine($"{names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}            {emails[id]}            {ages[id]}          {isBestFriendStr}");
                }

            }
            break;
        case 3: //search
            {
                Console.WriteLine(" Digite el nombre del contacto. ");
                string searchname = Console.ReadLine();

                bool found = false;

                foreach (var id in ids)
                {
                    if (names[id].ToLower() == searchname.ToLower())
                    {
                        string isBestFriendStr = bestFriends[id] ? "Si" : "No";

                        Console.WriteLine($"Nombre: {names[id]}");
                        Console.WriteLine($"Apellido: {lastnames[id]}");
                        Console.WriteLine($"Dirección: {addresses[id]}");
                        Console.WriteLine($"Telefono: {telephones[id]}");
                        Console.WriteLine($"Email: {emails[id]}");
                        Console.WriteLine($"Edad: {ages[id]}");
                        Console.WriteLine($"Mejor Amigo: {isBestFriendStr}");
                        Console.WriteLine("__________________________________");

                        found = true;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Contacto no encontrado.");
                }
            }
            break;
        case 4: //modify
            {
                Console.WriteLine("Ingresa el id del contacto que desea modificar.");
                int modify = Convert.ToInt32(Console.ReadLine());

                if (ids.Contains(modify))
                {
                    Console.WriteLine("Ingrese el nuevo nombre:");
                    names[modify] = Console.ReadLine();

                    Console.WriteLine("Ingrese el nuevo apellido:");
                    lastnames[modify] = Console.ReadLine();

                    Console.WriteLine("Ingrese la nueva dirección:");
                    addresses[modify] = Console.ReadLine();

                    Console.WriteLine("Ingrese el nuevo telefono:");
                    telephones[modify] = Console.ReadLine();

                    Console.WriteLine("Ingrese el nuevo email:");
                    emails[modify] = Console.ReadLine();

                    Console.WriteLine("Ingrese la nueva edad:");
                    ages[modify] = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Defina si el contacto es su mejor amigo: 1. Si, 2. No");
                    bestFriends[modify] = Convert.ToInt32(Console.ReadLine()) == 1;

                    Console.WriteLine("Registro actualizado correctamente.");
                }
                else
                {
                    Console.WriteLine("El Contacto no existe.");
                }
            }
            break;
        case 5: //delete
            {
                Console.WriteLine("Favor de ingresar el id del contacto que desea eliminar.");
                int deleteId = Convert.ToInt32(Console.ReadLine());

                if (ids.Contains(deleteId))
                {
                    ids.Remove(deleteId);
                    names.Remove(deleteId);
                    lastnames.Remove(deleteId);
                    addresses.Remove(deleteId);
                    telephones.Remove(deleteId);
                    emails.Remove(deleteId);
                    ages.Remove(deleteId);
                    bestFriends.Remove(deleteId);

                    Console.WriteLine("Contacto eliminado.");
                }
                else
                {
                    Console.WriteLine("El ID no existe.");

                }
                break;
        case 6:
                    runing = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
                }
            }

            static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
            {
                Console.WriteLine("Digite el nombre de la persona");
                string name = Console.ReadLine();
                Console.WriteLine("Digite el apellido de la persona");
                string lastname = Console.ReadLine();
                Console.WriteLine("Digite la dirección");
                string address = Console.ReadLine();
                Console.WriteLine("Digite el telefono de la persona");
                string phone = Console.ReadLine();
                Console.WriteLine("Digite el email de la persona");
                string email = Console.ReadLine();
                Console.WriteLine("Digite la edad de la persona en números");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No");

                bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

                var id = ids.Count + 1;
                ids.Add(id);
                names.Add(id, name);
                lastnames.Add(id, lastname);
                addresses.Add(id, address);
                telephones.Add(id, phone);
                emails.Add(id, email);
                ages.Add(id, age);
                bestFriends.Add(id, isBestFriend);
            }