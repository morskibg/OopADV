using System;

public delegate void JobCompletedHandler(Job job);

public class Job
{
    private Employee employeeAssigned;

    private int hoursRequired;

    public Job(string name, int hoursRequired, Employee employee)
    {
        this.Name = name;
        this.hoursRequired = hoursRequired;
        this.employeeAssigned = employee;
    }

    public event JobCompletedHandler JobCompleted;

    public string Name { get; private set; }

    public override string ToString()
    {
        return $"Job: {this.Name} Hours Remaining: {this.hoursRequired}";
    }

    public void Update()
    {
        this.hoursRequired -= this.employeeAssigned.HoursPerWeek;

        if (this.hoursRequired <= 0)
        {
            Console.WriteLine($"Job {this.Name} done!");
            this.JobCompleted.Invoke(this);
        }
    }
}