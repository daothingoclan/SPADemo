using SPADemo.Data.Migrations;
using SPADemo.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPADemo.Data.DAL
{
    public class AnimalInitializer : MigrateDatabaseToLatestVersion<AnimalContext, Configuration>
    {
    }
}
