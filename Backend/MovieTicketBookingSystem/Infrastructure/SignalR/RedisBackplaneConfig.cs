using Microsoft.AspNetCore.SignalR;

namespace MovieTicketBookingSystem.Infrastructure.SignalR
{
    namespace MovieTicketBookingSystem.Infrastructure.SignalR
    {
        public static class RedisBackplaneConfig
        {
            public static void AddRedisBackplane(
                ISignalRServerBuilder builder,
                string redisConnection)
            {
                builder.AddStackExchangeRedis(redisConnection, options =>
                {
                    options.Configuration.ChannelPrefix = "MovieTicketBooking";
                });
            }
        }
    }
}
