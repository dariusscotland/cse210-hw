using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();
        
        // Running: 30 min, 4.8 km distance
        activities.Add(new Running(
            new DateTime(2025, 12, 01), 
            30, 
            4.8));

        // Cycling: 45 min, 25 kph speed
        activities.Add(new Cycling(
            new DateTime(2025, 12, 02), 
            45, 
            25.0));

        // Swimming: 60 min, 40 laps (40 * 50m / 1000 = 2 km)
        activities.Add(new Swimming(
            new DateTime(2025, 12, 03), 
            60, 
            40));
            
        // Another Running: 20 min, 3.5 km distance
        activities.Add(new Running(
            new DateTime(2025, 12, 03), 
            20, 
            3.5));


        Console.WriteLine("--- Exercise Activity Summary (Kilometer Units) ---");
        Console.WriteLine("---------------------------------------------------");
        
        // 3. Iterate through the list and call GetSummary()
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}