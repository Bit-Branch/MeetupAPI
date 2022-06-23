namespace MeetupAPI.Domain.Entities
{
    public class BaseEntity
    {
        public DateTimeOffset? CreatedDate { get; set; }

        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
