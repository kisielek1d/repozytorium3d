using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPracticalTasksConsoleApp;

/*
========================================
== POZIOM 1 � PODSTAWOWY ==
========================================

1. Znajd� wszystkie osoby z Krakowa.
2. Znajd� osoby pe�noletnie.
3. Posortuj osoby po wieku rosn�co.
4. Posortuj osoby po nazwisku malej�co.
5. Wypisz tylko imi� i nazwisko ka�dej osoby.
6. Wypisz tylko miasta bez duplikat�w.
7. Oblicz liczb� os�b z Warszawy.
8. Oblicz �redni� pensj� wszystkich os�b.
9. Znajd� najm�odsz� osob�.
10. Sprawd�, czy jest kto� z Gda�ska.


========================================
== POZIOM 2 � �REDNI ==
========================================

11. Posortuj osoby po mie�cie, a w ramach miasta po pensji malej�co.
12. Znajd� osoby w wieku od 25 do 35 lat (w��cznie).
13. Oblicz sum� pensji os�b z Kielc.
14. Znajd� pierwsz� osob�, kt�rej pensja jest wi�ksza ni� 10 000.
15. Znajd� ostatni� osob� w kolejno�ci alfabetycznej po nazwisku.
16. Wygeneruj dane os�b w formacie: "Imi� Nazwisko (Miasto)".
17. Sprawd�, czy wszyscy maj� co najmniej 18 lat.
18. Policz, ile jest kobiet.
19. Znajd� osoby, kt�re zarabiaj� wi�cej ni� �rednia pensja.
20. Znajd� najstarsz� osob� z Krakowa.


========================================
== POZIOM 3 � ZAAWANSOWANY ==
========================================

21. Znajd� osoby, kt�re maj� skill "C#".
22. Znajd� osoby, kt�re maj� co najmniej trzy skille.
23. Znajd� osoby z Warszawy, posortuj je po wieku malej�co i wypisz tylko ich imi�, nazwisko, wiek i pensj�.
24. Sprawd�, czy kto� ma skill "Azure".
25. Sprawd�, czy wszyscy zarabiaj� co najmniej 4000.
26. Znajd� osob� o najwi�kszej pensji.
27. Znajd� osob� o najmniejszej pensji.
28. Wypisz osoby, kt�re maj� taki sam wiek jak najstarsza osoba.


========================================
== POZIOM 4 � EKSTRA / DLA CH�TNYCH ==
========================================

29. Posortuj osoby wed�ug liczby posiadanych skilli.
30. Podziel osoby na dwie listy: zarabiaj�cych przynajmniej 8000 oraz zarabiaj�cych mniej ni� 8000.
31. Przyporz�dkuj ka�d� osob� do przedzia�u wiekowego (np. 20�29, 30�39, 40�49) i wypisz osoby z ka�dego przedzia�u.

*/

internal class Task1
{
    void Print<T>(string title, IEnumerable<T> data)
    {
        Console.WriteLine($"\n=== {title} ===");
        foreach (var item in data)
            Console.WriteLine(item);
    }

    public void DoTasks()
    {
        var people = new List<Person>
        {
            new Person() { Id=1, FirstName="Anna",  LastName="Nowak",    Age=29, Gender=Gender.Female, City="Kielce", Salary=8200m,  Skills=["C#", "LINQ", "SQL"] },
            new() { Id=2, FirstName="Marek", LastName="Kowalski", Age=43, Gender=Gender.Male,   City="Warszawa", Salary=15000m, Skills=["Azure", "C#", "DevOps"] },
            new() { Id=3, FirstName="Ewa",   LastName="Wi�niewska",Age=35, Gender=Gender.Female, City="Krak�w", Salary=9800m,  Skills=["JavaScript", "React"] },
            new() { Id=4, FirstName="Jan",   LastName="Zieli�ski", Age=43, Gender=Gender.Male,   City="Gda�sk", Salary=12000m, Skills=["C#", "SQL"] },
            new() { Id=5, FirstName="Ola",   LastName="Maj",       Age=26, Gender=Gender.Female, City="Kielce", Salary=7200m,  Skills=["Python", "ML"] },
            new() { Id=6, FirstName="Piotr", LastName="Lewandowski",Age=37,Gender=Gender.Male,   City="Warszawa", Salary=13400m, Skills=["C#", "LINQ", "Azure"] },
            new() { Id=7, FirstName="Iga",   LastName="Kowal",     Age=31, Gender=Gender.Female, City="Krak�w", Salary=9900m,  Skills=["Go", "Kubernetes"] },
            new() { Id=8, FirstName="Tomek", LastName="Sikora",    Age=29, Gender=Gender.Male,   City="Kielce", Salary=8800m,  Skills=["C#", "MAUI", "Bluetooth"] },
        };

        // === POZIOM 1 ===

        //1
        var q1 = people.Where(p => p.City == "Kraków");
        Print("1. Osoby z Krakowa", q1);

        // 2
        var q2 = people.Where(p => p.Age >= 18);
        Print("2. Osoby pełnoletnie", q2);

        // 3
        var q3 = people.OrderBy(p => p.Age);
        Print("3. Sortowanie po wieku rosnąco", q3);

        // 4
        var q4 = people.OrderByDescending(p => p.LastName);
        Print("4. Sortowanie po nazwisku malejąco", q4);

        // 5
        var q5 = people.Select(p => $"{p.FirstName} {p.LastName}");
        Print("5. Imię i nazwisko", q5);

        // 6
        var q6 = people.Select(p => p.City).Distinct();
        Print("6. Miasta bez duplikatów", q6);

        // 7
        var q7 = people.Count(p => p.City == "Warszawa");
        Console.WriteLine($"\n7. Liczba osób z Warszawy: {q7}");

        // 8
        var q8 = people.Average(p => p.Salary);
        Console.WriteLine($"\n8. Średnia pensja: {q8}");

        // 9
        var q9 = people.OrderBy(p => p.Age).First();
        Console.WriteLine($"\n9. Najmłodsza osoba: {q9}");

        // 10
        var q10 = people.Any(p => p.City == "Gdańsk");
        Console.WriteLine($"\n10. Czy ktoś jest z Gdańska? {q10}");

        // === POZIOM 2 ===

        // 11
        var q11 = people
            .OrderBy(p => p.City)
            .ThenByDescending(p => p.Salary);
        Print("11. Sortowanie po mieście, a w mieście po pensji malejąco", q11);

        // 12
        var q12 = people.Where(p => p.Age >= 25 && p.Age <= 35);
        Print("12. Wiek 25–35", q12);

        // 13
        var q13 = people
            .Where(p => p.City == "Kielce")
            .Sum(p => p.Salary);
        Console.WriteLine($"\n13. Suma pensji z Kielc: {q13}");

        // 14
        var q14 = people.FirstOrDefault(p => p.Salary > 10000);
        Console.WriteLine($"\n14. Pierwsza osoba z pensją > 10000: {q14}");

        // 15
        var q15 = people
            .OrderBy(p => p.LastName)
            .Last();
        Console.WriteLine($"\n15. Ostatnia alfabetycznie po nazwisku: {q15}");

        // 16
        var q16 = people
            .Select(p => $"{p.FirstName} {p.LastName} ({p.City})");
        Print("16. Format: Imię Nazwisko (Miasto)", q16);

        // 17
        var q17 = people.All(p => p.Age >= 18);
        Console.WriteLine($"\n17. Czy wszyscy mają co najmniej 18 lat? {q17}");

        // 18
        var q18 = people.Count(p => p.Gender == Gender.Female);
        Console.WriteLine($"\n18. Liczba kobiet: {q18}");

        // 19
        var averageSalary = people.Average(p => p.Salary);
        var q19 = people.Where(p => p.Salary > averageSalary);
        Print("19. Osoby zarabiające więcej niż średnia", q19);

        // 20
        var q20 = people
            .Where(p => p.City == "Kraków")
            .OrderByDescending(p => p.Age)
            .FirstOrDefault();
        Console.WriteLine($"\n20. Najstarsza osoba z Krakowa: {q20}");



        // === POZIOM 3 ===

        // 21
        var q21 = people.Where(p => p.Skills.Contains("C#"));
        Print("21. Osoby ze skillem C#", q21);

        // 22
        var q22 = people.Where(p => p.Skills.Count >= 3);
        Print("22. Osoby z co najmniej 3 skillami", q22);

        // 23
        var q23 = people
            .Where(p => p.City == "Warszawa")
            .OrderByDescending(p => p.Age)
            .Select(p => new { p.FirstName, p.LastName, p.Age, p.Salary });
        Print("23. Warszawa – imię, nazwisko, wiek, pensja", q23);

        // 24
        var q24 = people.Any(p => p.Skills.Contains("Azure"));
        Console.WriteLine($"\n24. Czy ktoś ma skill Azure? {q24}");

        // 25
        var q25 = people.All(p => p.Salary >= 4000);
        Console.WriteLine($"\n25. Czy wszyscy zarabiają co najmniej 4000? {q25}");

        // 26
        var q26 = people.OrderByDescending(p => p.Salary).First();
        Console.WriteLine($"\n26. Osoba z największą pensją: {q26}");

        // 27
        var q27 = people.OrderBy(p => p.Salary).First();
        Console.WriteLine($"\n27. Osoba z najmniejszą pensją: {q27}");

        // 28
        var maxAge = people.Max(p => p.Age);
        var q28 = people.Where(p => p.Age == maxAge);
        Print("28. Osoby w wieku najstarszej osoby", q28);



        // === POZIOM 4 ===

        // 29
        var q29 = people
            .OrderByDescending(p => p.Skills.Count);
        Print("29. Sortowanie po liczbie skilli", q29);

        // 30
        var highEarners = people.Where(p => p.Salary >= 8000).ToList();
        var lowEarners = people.Where(p => p.Salary < 8000).ToList();

        Print("30a. Zarabiający >= 8000", highEarners);
        Print("30b. Zarabiający < 8000", lowEarners);

        // 31
        var q31 = people
            .GroupBy(p => $"{(p.Age / 10) * 10}-{(p.Age / 10) * 10 + 9}")
            .OrderBy(g => g.Key);

        Console.WriteLine("\n31. Podział na przedziały wiekowe:");
        foreach (var group in q31)
        {
            Console.WriteLine($"\nPrzedział {group.Key}:");
            foreach (var person in group)
                Console.WriteLine(person);
        }


    }
}