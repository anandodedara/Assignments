using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.AutomapperConfig
{
    public class MapperConfig
    {
        public IMapper mapper { get; set; }

        public MapperConfig()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                //Create all maps here
                cfg.CreateMap<Models.Hotel, Database.Hotel>();
                cfg.CreateMap<Database.Hotel, Models.Hotel>();

            });
            mapper = config.CreateMapper();
        }

        
        
    }
}
