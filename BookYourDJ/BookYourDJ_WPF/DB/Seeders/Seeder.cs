using BookYourDJ_WPF.DB.Seeders;
using BookYourDJ_WPF.Model;
using System.Collections.Generic;
using System.Data.Entity;
using Bogus;

namespace BookYourDJ_WPF.DB.Seeders
{
    abstract class Seeder<Entity> : ISeeder where Entity : class
    {
        protected static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        protected static readonly string CREATED_LOG_MSG = "{0} created - Id={1}";

        protected static Faker<Entity> faker = new Faker<Entity>("fr");


        public abstract void Run(BookYourDJEntities context);

    }
}