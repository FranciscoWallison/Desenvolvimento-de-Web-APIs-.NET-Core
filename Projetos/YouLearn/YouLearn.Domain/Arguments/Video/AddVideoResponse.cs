using System;


namespace YouLearn.Domain.Arguments.Video
{
    public class AddVideoResponse
    {
        public AddVideoResponse(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
