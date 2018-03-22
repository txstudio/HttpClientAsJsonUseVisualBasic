using System;

namespace DataContract
{
    public class LoginRequest
    {
        public string Account { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public bool IsSuccess { get; set; }
        public Nullable<DateTime> TimeUtc { get; set; }
    }
}
