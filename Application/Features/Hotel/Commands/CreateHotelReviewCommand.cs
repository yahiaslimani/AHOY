﻿using Application.Models.Common;

namespace Application.Features.Hotel.Commands;
public class CreateHotelReviewCommand : IRequest<BaseModel>
{
    public string ReviewName { get; set; }
    public string ReviewerEmail { get; set; }
    public string Description { get; set; }
    public int Rating { get; set; }
    public int HotelId { get; set; }

    public class CreateHotelReviewCommandHandler : IRequestHandler<CreateHotelReviewCommand, BaseModel>
    {
        private readonly IApplicationDbContext _context;
        public CreateHotelReviewCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<BaseModel> Handle(CreateHotelReviewCommand command, CancellationToken cancellationToken)
        {
            Review review = new()
            {
                ReviewName = command.ReviewName,
                ReviewerEmail = command.ReviewerEmail,
                Description = command.Description,
                Rating = command.Rating,
                HotelId = command.HotelId,
            };
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return new BaseModel
            {
                StatusCode = 200,
                Message = "Data has been added successfully"
            };
        }
    }


}
 
