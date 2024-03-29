﻿using Application.Models;

namespace Application.Features.Facility.Commands;
public class UpdateFacilityCommand : IRequest<FacilityModel>
{
    public int Id { get; set; }
    public string Name { get; set; }
    private readonly string _icon = null;
    public class UpdateFacilityCommandHandler : IRequestHandler<UpdateFacilityCommand, FacilityModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateFacilityCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<FacilityModel> Handle(UpdateFacilityCommand command, CancellationToken cancellationToken)
        {
            var facility = _context.Facilities.FirstOrDefault(a => a.Id == command.Id);

            if (facility == null)
            {
                return new FacilityModel
                {
                    Data = null,
                    StatusCode = 404,
                    Message = "Data not found"
                };
            }
            else
            {
                facility.Name = command.Name;
                facility.Description = command._icon;

                await _context.SaveChangesAsync();
                return new FacilityModel
                {
                    Data = _mapper.Map<FacilityDTO>(facility),
                    StatusCode = 200,
                    Message = "Data has been updated successfully"
                };
            }
        }
    }
}
