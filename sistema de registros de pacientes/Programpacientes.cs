// Lenny Nicoll Nuñez - Matrícula: 2025-1878

using System;
using System.Collections.Generic;
using System.Linq;

public class Patient
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public int Age { get; set; }
    public string BloodType { get; set; }
    public string Diagnosis { get; set; }

    public Patient(int id, string fullName, int age, string bloodType, string diagnosis)
    {
        Id = id;
        FullName = fullName;
        Age = age;
        BloodType = bloodType;
        Diagnosis = diagnosis;
    }
}

public class PatientManager
{
    private List<Patient> patients = new List<Patient>();
    private int idCounter = 1;

    public void AddPatient()
    {
        Console.Write("Nombre Completo: ");
        string name = Console.ReadLine();
        Console.Write("Edad: ");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.Write("Tipo de Sangre: ");
        string blood = Console.ReadLine();
        Console.Write("Diagnóstico: ");
        string diag = Console.ReadLine();

        patients.Add(new Patient(idCounter++, name, age, blood, diag));
        Console.WriteLine("Paciente registrado.");
    }

    public void ListPatients()
    {
        if (patients.Count == 0)
        {
            Console.WriteLine("No hay registros.");
            return;
        }

        foreach (var p in patients)
        {
            Console.WriteLine($"{p.Id} | {p.FullName} | {p.Age} años | Sangre: {p.BloodType}");
        }
    }

    public void SearchById()
    {
        Console.Write("ID a buscar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var p = patients.FirstOrDefault(x => x.Id == id);
            if (p != null)
            {
                Console.WriteLine($"Paciente: {p.FullName}");
                Console.WriteLine($"Diagnóstico: {p.Diagnosis}");
            }
            else Console.WriteLine("No encontrado.");
        }
    }

    public void DischargePatient()
    {
        Console.Write("ID para dar de alta: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var p = patients.FirstOrDefault(x => x.Id == id);
            if (p != null)
            {
                patients.Remove(p);
                Console.WriteLine("Paciente dado de alta.");
            }
            else Console.WriteLine("ID no válido.");
        }
    }
}

class Program
{
    static void Main()
    {
        PatientManager hospital = new PatientManager();
        bool active = true;

        while (active)
        {
            Console.WriteLine("\n1. Registrar  2. Ver  3. Buscar  4. Alta  5. Salir");
            Console.Write("Seleccione una opción: ");
            string op = Console.ReadLine();

            switch (op)
            {
                case "1": hospital.AddPatient(); break;
                case "2": hospital.ListPatients(); break;
                case "3": hospital.SearchById(); break;
                case "4": hospital.DischargePatient(); break;
                case "5": active = false; break;
                default: Console.WriteLine("Opción no válida."); break;
            }
        }
    }
}