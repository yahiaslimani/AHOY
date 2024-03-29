﻿using Application.Models;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Nest;

namespace Application.Features.Hotel.Commands;
public class CreateHotelCommand : MediatR.IRequest<HotelModel>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Location { get; set; }
    public class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommand, HotelModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ElasticClient _elasticClient;
        private readonly ILogger _logger;
        public CreateHotelCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<CreateHotelCommand> logger, ElasticClient elasticClient = null)
        {
            _context = context;
            _mapper = mapper;
            _elasticClient = elasticClient;
            _logger = logger;
        }
        public async Task<HotelModel> Handle(CreateHotelCommand command, CancellationToken cancellationToken)
        {
            var hotel = _mapper.Map<Domain.Entities.Hotel>(command);
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
            try
            {
                await _elasticClient.IndexDocumentAsync(hotel, cancellationToken);
            }
            catch (Exception ex) { _logger.LogError(ex.ToString()); }
            return new HotelModel
            {
                Data = _mapper.Map<HotelDTO>(hotel),
                StatusCode = 200,
                Message = "Data has been added successfully"
            };
        }
    }


}
public class CreateHotelCommandValidator : AbstractValidator<CreateHotelCommand>
{
    public CreateHotelCommandValidator()
    {
        RuleFor(x => x.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Length(0, 50)
            .WithMessage("Name should be not empty. NEVER!");
        RuleFor(x => x.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Length(0, 50)
            .WithMessage("Email should be not empty. NEVER!")
            .EmailAddress().WithMessage("Wrong Email Format");
    }
}