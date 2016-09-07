namespace SPADemo.Data.Migrations
{
    using Domain;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<SPADemo.Data.AnimalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SPADemo.Data.AnimalContext context)
        {
            if(context.Animals.Count() == 0)
            {
                var animals = new List<Animal>
                {
                    new Animal {Name="Suki", AvatarURL="",Color="BackYellow", DOB= DateTime.Parse("2014-01-01")},
                    new Animal {Name="Lulu", AvatarURL="",Color="Back", DOB= DateTime.Parse("2015-02-01")},
                    new Animal {Name="Kiki", AvatarURL="",Color="Yellow", DOB= DateTime.Parse("2014-05-25")},
                    new Animal {Name="Mimi", AvatarURL="",Color="White", DOB= DateTime.Parse("2016-05-01")},
                    new Animal {Name="Lili", AvatarURL="",Color="BackYellow", DOB= DateTime.Parse("2015-01-01")}
                };
                animals.ForEach(a => context.Animals.AddOrUpdate(a));
                context.SaveChanges();
            }
        }
    }
}
