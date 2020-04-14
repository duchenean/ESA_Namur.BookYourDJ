using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using BookYourDJ_WPF.DB.Seeders;
using BookYourDJ_WPF.Model;


namespace BookYourDJ_WPF.DB.Seeders
{
    class AnimatorsSeeder : Seeder<Animators>
    {
        public override void Run(BookYourDJEntities context)
        {
            int animatorId = 0;

            var testAnimators = faker
                .RuleFor(u => u.Id, f => animatorId++)
                .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName())
                .RuleFor(u => u.LastName, (f, u) => f.Name.LastName())
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                .RuleFor(u => u.StageName, (f, u) => f.Hacker.Noun())
                .RuleFor(u => u.Description, (f, u) => f.Lorem.Sentence())
                .RuleFor(u => u.Birthday, (f, u) => f.Date.Past())
                .RuleFor(u => u.Address, (f, u) => f.Address.FullAddress())
                .RuleFor(u => u.Phone, (f, u) => f.Phone.PhoneNumber())

                .FinishWith((f, u) =>
                {
                    logger.Info(CREATED_LOG_MSG, "Animator", u.Id);
                });
            var a = testAnimators.Generate(50);

            context.Animators.AddRange(a);

        }

    }
}


