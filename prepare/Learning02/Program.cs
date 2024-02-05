//Abstraction Activity: Sean Porter
using System;

//Create a class called job to hold attributes of a job
public class Job //upper case to avoid confusion
{
    public string title;
    public string company;
    public int start_year;
    public int end_year;

    public void Display()
    {
        Console.WriteLine($"{title} ({company}) {start_year}-{end_year}"); //practice using a constructor like we were shown in class
    }
}

//create a class called resume to assign attributes in job class to a person
public class Resume
{
    public string name;

    public List<Job> jobs = new List<Job>(); //create a list with class Job

    public void Display()
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine("Jobs:");

        foreach (Job job in jobs)
        {
            job.Display();
        }
    }
}

//Add data to the attributes found in job class, and assign that to a person using resume class.
class Program
{
    static void Main(string[] args)
    {
        //used the same data as in the sample solution
        Job job1 = new Job();
        job1.title = "Software Engineer";
        job1.company = "Microsoft";
        job1.start_year = 2019;
        job1.end_year = 2022;

        Job job2 = new Job();
        job2.title = "Manager";
        job2.company = "Apple";
        job2.start_year = 2022;
        job2.end_year = 2023;

        Resume myResume = new Resume();
        myResume.name = "Allison Rose";

        myResume.jobs.Add(job1);
        myResume.jobs.Add(job2);

        myResume.Display();
        //The result should look like the sample solution
    }
}