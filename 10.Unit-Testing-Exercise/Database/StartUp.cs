namespace Database
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            var db = new PeopleDatabase(new Person("s",1), new Person("se", 2));
            db.Remove();
            db.FindByUserName(null);
        }
    }
}