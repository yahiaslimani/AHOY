using Application.Models;
using Application.Models.Common;

namespace Application.Features.Facility.Queries;
public class GetAllFacilitiesQuery : Pagination, IRequest<FacilitiesModel>
{

    public class GetAllFacilityQueryHandler : IRequestHandler<GetAllFacilitiesQuery, FacilitiesModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetAllFacilityQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<FacilitiesModel> Handle(GetAllFacilitiesQuery query, CancellationToken cancellationToken)
        {
           
            var facilityList = await _context.Facilities
                    .OrderBy(o => o.Name)
                    .Skip((query.PageNumber - 1) * query.PageSize)
                    .Take(query.PageSize)
                    .ToListAsync(cancellationToken: cancellationToken);
            _mapper.Map<List<FacilityDTO>>(facilityList);
            return new FacilitiesModel
            {
                Data = _mapper.Map<List<FacilityDTO>>(facilityList),
                StatusCode = 200,
                Message = "Data found"
            };
        }
  
    }
}
