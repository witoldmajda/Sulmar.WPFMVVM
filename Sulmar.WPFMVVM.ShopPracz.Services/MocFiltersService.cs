using Sulmar.WPFMVVM.ShopPracz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sulmar.WPFMVVM.ShopPracz.Services
{
    public class MocFiltersService : IFiltersService
    {
        private IList<Filter> filters;

        public MocFiltersService()
        {
            filters = new List<Filter>
            {
                new Filter
                {
                    Id = 1,
                    Name = "Filtr 1",
                    Segments = new List<Segment>
                    {
                        new Segment {Name = "A"},
                        new Segment {Name = "AB"},
                        new Segment {Name = "B"},
                        new Segment {Name = "AC"},
                        new Segment {Name = "BD"},
                        new Segment {Name = "C"},
                        new Segment {Name = "CD"},
                        new Segment {Name = "D"},
                    }
                },

                new Filter
                {
                    Id = 2,
                    Name = "Filtr 2",
                    Segments = new List<Segment>
                    {
                        new Segment {Name = "A"},
                        new Segment {Name = "AB"},
                        new Segment {Name = "B"},
                        new Segment {Name = "AC"},
                        new Segment {Name = "BD"},
                        new Segment {Name = "C"},
                        new Segment {Name = "CD"},
                        new Segment {Name = "D"},
                    }
                },
            };
            
        }

        public Filter Get(int id)
        {
            return filters.SingleOrDefault(f => f.Id == id);
        }

        public void Update(IFiltersService filter)
        {
            throw new NotImplementedException();
        }
    }
}
