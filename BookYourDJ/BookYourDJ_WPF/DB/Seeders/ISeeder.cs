using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookYourDJ_WPF.Model;

namespace BookYourDJ_WPF.DB.Seeders
{
    interface ISeeder
    {
        void Run(BookYourDJEntities context);
    }
}
