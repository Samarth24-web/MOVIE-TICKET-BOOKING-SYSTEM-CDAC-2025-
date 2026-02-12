using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieTicketBookingSystem.Infrastructure.PaymentGateways;
using MovieTicketBookingSystem.Repository.Interfaces;

namespace MovieTicketBookingSystem.BackgroundJobs
{
    public class RazorpayReconciliationJob : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public RazorpayReconciliationJob(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _scopeFactory.CreateScope();

                var paymentRepo = scope.ServiceProvider
                    .GetRequiredService<IPaymentRepository>();

                var gateway = scope.ServiceProvider
                    .GetRequiredService<IPaymentGateway>();

                var pendingPayments = paymentRepo.GetPendingPayments();

                foreach (var payment in pendingPayments)
                {
                    // reconciliation logic
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
