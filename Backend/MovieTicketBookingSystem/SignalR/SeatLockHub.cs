using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;

namespace MovieTicketBookingSystem.SignalR
{
    public class SeatLockHub : Hub
    {
        /*
         * Each show will have its own SignalR group.
         * Group name format: "show-{showId}"
         */

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }

        public async Task JoinShowGroup(long showId)
        {
            await Groups.AddToGroupAsync(
                Context.ConnectionId,
                GetShowGroupName(showId));
        }

        public async Task LeaveShowGroup(long showId)
        {
            await Groups.RemoveFromGroupAsync(
                Context.ConnectionId,
                GetShowGroupName(showId));
        }

        /* ============================
           SERVER → CLIENT EVENTS
           ============================ */

        public async Task NotifySeatLocked(
            long showId,
            long showSeatStatusId,
            long userId,
            DateTime lockExpiryTime)
        {
            await Clients
                .Group(GetShowGroupName(showId))
                .SendAsync(
                    "SeatLocked",
                    new
                    {
                        ShowSeatStatusId = showSeatStatusId,
                        LockedByUserId = userId,
                        LockExpiryTime = lockExpiryTime
                    });
        }

        public async Task NotifySeatUnlocked(
            long showId,
            long showSeatStatusId)
        {
            await Clients
                .Group(GetShowGroupName(showId))
                .SendAsync(
                    "SeatUnlocked",
                    new
                    {
                        ShowSeatStatusId = showSeatStatusId
                    });
        }

        public async Task NotifySeatBooked(
            long showId,
            long showSeatStatusId,
            long bookingId)
        {
            await Clients
                .Group(GetShowGroupName(showId))
                .SendAsync(
                    "SeatBooked",
                    new
                    {
                        ShowSeatStatusId = showSeatStatusId,
                        BookingId = bookingId
                    });
        }

        /* ============================
           HELPER
           ============================ */

        private string GetShowGroupName(long showId)
        {
            return $"show-{showId}";
        }
    }
}
