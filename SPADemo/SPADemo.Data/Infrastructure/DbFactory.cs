using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPADemo.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private AnimalContext animalContext;

        public AnimalContext Init()
        {
            return animalContext ?? (animalContext = new AnimalContext());
        }

        protected override void DisposeCore()
        {
            if (animalContext != null)
                animalContext.Dispose();
        }
    }
}
