﻿namespace MeetupAPI.Application.Responses
{
    public class GetMeetupResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Plan { get; set; } = string.Empty;

        public string Creator { get; set; } = string.Empty;

        public string Speaker { get; set; } = string.Empty;

        public DateTimeOffset MeetupTime { get; set; }

        public string MeetupPlace { get; set; } = string.Empty;
    }
}
