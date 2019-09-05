using AutoMapper;

namespace FreeflyAcademy.Services.Business
{
    internal abstract class BaseBusinessService
    {
        protected readonly IMapper _mapper;

        protected BaseBusinessService(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
