﻿using Application.Models.Common;

namespace Application.Features.Hotel.Commands;
public class CreateHotelFacilityCommand : IRequest<BaseModel>
{
   
    public int FacilityId { get; set; }
    public int HotelId { get; set; }

    public class CreateHotelFacilityCommandHandler : IRequestHandler<CreateHotelFacilityCommand, BaseModel>
    {
        private readonly IApplicationDbContext _context;
        public CreateHotelFacilityCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<BaseModel> Handle(CreateHotelFacilityCommand command, CancellationToken cancellationToken)
        {
            HotelFacility facility = new()
            {
                HotelId = command.HotelId,
                FacilityId = command.FacilityId,
            };
            _context.HotelFacilities.Add(facility);
            await _context.SaveChangesAsync();
            return new BaseModel
            {
                StatusCode = 200,
                Message = "Data has been added successfully"
            };
        }
    }


}
