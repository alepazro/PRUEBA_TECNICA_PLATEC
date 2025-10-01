using AutoMapper;
using Product.Service.Application.Interfaces;
using Product.Service.Infrastructure.Persistence.UnitOfWork;

namespace Product.Service.Application.Services
{    
    public partial class ApplicationService : IApplicationService
    {
        private readonly ApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidationService _validationService;

        public ApplicationService(
            ApplicationUnitOfWork unitOfWork,
            IMapper mapper,
            IValidationService validationService
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationService = validationService;
        }
    }
}
