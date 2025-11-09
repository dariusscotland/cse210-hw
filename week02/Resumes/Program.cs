using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new job instance
        Job job1 = new Job();
        Job job2 = new Job();

        // Set the member variables
        job1._company = "Tech Corp";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2005;
        job1._endYear = 2020;

        job2._company = "Space Corp";
        job2._jobTitle = "Security Engineer";
        job2._startYear = 2007;
        job2._endYear = 2019;

        // Create a new resume instance
        Resume myResume = new Resume();

        // Set Person's name
        myResume._name = "Allison Rose";

        // Add two jobs to the list
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}