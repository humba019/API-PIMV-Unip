using APIpimv_unip.Mapping;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIpimv_unip_test
{
    public class AutomapperSingletonModelToResource
    {
        private static IMapper _mapper;
        public static IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                {
                    // Auto Mapper Configurations
                    var mappingConfig = new MapperConfiguration(mc =>
                    {
                        mc.AddProfile(new ModelToResourceProfile());
                    });
                    IMapper mapper = mappingConfig.CreateMapper();
                    _mapper = mapper;
                }
                return _mapper;
            }
        }
    }
}
