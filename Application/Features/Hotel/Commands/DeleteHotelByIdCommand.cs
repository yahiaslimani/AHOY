﻿using Application.Models;
using Microsoft.Extensions.Logging;
using Nest;

namespace Application.Features.Hotel.Commands;
public class DeleteHotelByIdCommand : MediatR.IRequest<HotelModel>
{
    public int Id { get; set; }
    public class DeleteHotelByIdCommandHandler : IRequestHandler<DeleteHotelByIdCommand, HotelModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ElasticClient _elasticClient;
        private readonly ILogger _logger;
        public DeleteHotelByIdCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<DeleteHotelByIdCommand> logger, ElasticClient elasticClient = null)
        {
            _context = context;
            _mapper = mapper;
            _elasticClient = elasticClient;
            _logger = logger;
        }
        public async Task<HotelModel> Handle(DeleteHotelByIdCommand command, CancellationToken cancellationToken)
        {
            var hotel = await _context.Hotels.Where(a => a.Id == command.Id).FirstOrDefaultAsync(cancellationToken: cancellationToken);
            if (hotel == null)
            {
                return new HotelModel
                {
                    Data = null,
                    StatusCode = 404,
                    Message = "Data not found!"
                };
            }

            hotel.IsDeleted = true;
            await _context.SaveChangesAsync();

            try { await _elasticClient.DeleteAsync<Domain.Entities.Hotel>(hotel, ct: cancellationToken); }
            catch (Exception ex) { _logger.LogError(ex.ToString()); }

            return new HotelModel
            {
                Data = _mapper.Map<HotelDTO>(hotel),
                StatusCode = 200,
                Message = "Data has been Deleted successfully"
            };
        }
    }
}
