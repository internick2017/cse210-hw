using System;

class Program
{
    static void Main(string[] args)
    {
        // Create jobs
        Job job1 = new Job("Microsoft", "Software Engineer", 2019, 2022);

        Job job2 = new Job("Apple", "Manager", 2022, 2023);

        // Create resume
        Resume myResume = new Resume("Nick Granados");

        // Add jobs to the resume
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        // Display the resume
        myResume.Display();
    }
}