﻿using Application.Models;

namespace Application.Features.Booking.Commands;
public class CreateBookingCommand : IRequest<BookingModel>
{
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public bool IsConfirmed { get; set; }
    public double Price { get; set; }
    public double Discount { get; set; }
    public double PaidAmount { get; set; }
    public string UserName { get; set; }
    public int RoomId { get; set; }

    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, BookingModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CreateBookingCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<BookingModel> Handle(CreateBookingCommand command, CancellationToken cancellationToken)
        {
            var booking = _mapper.Map<Domain.Entities.Booking>(command);
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
           
            return new BookingModel
            {
                Data = _mapper.Map<BookingDto>(booking),
                StatusCode = 200,
                Message = "Data has been added successfully"
            };
        }
    }
}
