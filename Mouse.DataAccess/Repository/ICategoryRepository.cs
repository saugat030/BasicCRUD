using Mouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mouse.DataAccess.Repository
{
    public  interface ICategoryRepository: IRepository<Categ> //yo chai k vako ta vanda since the update logic for every repo might vary , we make a specific repo for each model.
    { //Since this ICategegory repo ingerits the IRepository of type <Categ> , we can directly use this repo to inherit from in the CategoryRepository.
        void Update(Categ obj);
        
    }
}
