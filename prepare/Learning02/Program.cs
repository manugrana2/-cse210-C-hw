using System;
class Program
{
    static void Main(string[] args)
    {
        //First Job
        Job job1 = new Job();
        job1._company = "Microsoft";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2010;
        job1._endYear = 2020;
        //Second Job
        Job job2 = new Job();
        job2._company = "Uber";
        job2._jobTitle = "Software Developer Trainee";
        job2._startYear = 2009;
        job2._endYear = 2010;
        job2.Display();
        //Resume
        Resume resume = new Resume();
        resume._name = "Jonh Smith";
        resume._Jobs = new List<Job>();
        resume._Jobs.Add(job1);
        resume._Jobs.Add(job2);
        resume.Display();

    }
}