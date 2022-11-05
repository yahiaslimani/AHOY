using Application.Models;
using FluentValidation;

namespace Application.Features.Facility.Commands;
public class CreateFacilityCommand : IRequest<FacilityModel>
{
    public string Name { get; set; }
    public string Icon { get; set; }

    public class CreateFacilityCommandHandler : IRequestHandler<CreateFacilityCommand, FacilityModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CreateFacilityCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<FacilityModel> Handle(CreateFacilityCommand command, CancellationToken cancellationToken)
        {
            var facility = _mapper.Map<Domain.Entities.Facility>(command);
            _context.Facilities.Add(facility);
            await _context.SaveChangesAsync();
            return new FacilityModel
            {
                Data = _mapper.Map<FacilityDTO>(facility),
                StatusCode = 200,
                Message = "Data has been added successfully"
            };
        }
    }


}
public class CreateFacilityCommandValidator : AbstractValidator<CreateFacilityCommand>
{
    public CreateFacilityCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("The Facility Name should not be empty!");
    }
}
