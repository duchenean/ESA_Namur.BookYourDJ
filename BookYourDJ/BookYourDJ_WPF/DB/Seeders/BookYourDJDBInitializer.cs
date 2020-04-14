using BookYourDJ_WPF.DB.Seeders;
using BookYourDJ_WPF.Model;
using System.Collections.Generic;
using System.Data.Entity;

namespace BookYourDJ_WPF.DB.Seeders
{
    /// <summary>
    /// Initialize the DB with fake data
    /// </summary>
    public class BookYourDJDBInitializer : DropCreateDatabaseAlways<BookYourDJEntities>
    {
        /// <summary>
        /// Here we can register our seeders that will be runned to seed data in the DB
        /// </summary>
        private static readonly List<ISeeder> Seeders = new List<ISeeder>()
        {
            new RegionsSeeder(),
            new AnimatorsSeeder()
        };

        protected override void Seed(BookYourDJEntities context)
        {
            foreach (ISeeder seeder in Seeders)
            {
                seeder.Run(context);
            }
            base.Seed(context);
        }
    }
}