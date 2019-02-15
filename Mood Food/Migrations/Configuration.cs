namespace Mood_Food.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Mood_Food.DAL;

    public sealed class Configuration : DbMigrationsConfiguration<Mood_Food.DAL.MoodFoodContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Mood_Food.DAL.MoodFoodContext";
        }

        protected override void Seed(Mood_Food.DAL.MoodFoodContext context)
        {
            MoodFoodInitializer.SeedMoodFood(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
