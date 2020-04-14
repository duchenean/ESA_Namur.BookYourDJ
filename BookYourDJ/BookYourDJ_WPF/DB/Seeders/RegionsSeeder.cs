using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using BookYourDJ_WPF.Model;

namespace BookYourDJ_WPF.DB.Seeders
{
    class RegionsSeeder : Seeder<Regions>
    {
        public override void Run(BookYourDJEntities context)
        {
            int regionId = 0;
            var testRegions = faker
                .RuleFor(u => u.Id, f => regionId++)
                .RuleFor(u => u.Name, f => f.Address.Country())
                .FinishWith((f, u) =>
                {
                   logger.Info(CREATED_LOG_MSG, "Region", u.Id);
                });
            var regionsList = testRegions.Generate(10);

            context.Regions.AddRange(regionsList);
        }
    }
}
