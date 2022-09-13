using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LiveCards.Models;
using LiveCards.Web.Models;

namespace LiveCards.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }



        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Brand>  Brands { get; set; }
        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<Card> Cards { get; set; }  
        public virtual DbSet<AgentCard> AgentCards { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        


        
        public virtual DbSet<DealerBill> DealerBills { get; set; }
        public virtual DbSet<DealerInvoice> DealerInvoices { get; set; }
        public virtual DbSet<DelearsAdverty> DelearsAdvertys { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CreditChanx> CreditChanges { get; set; }
        public virtual DbSet<Adverty> Advertys { get; set; }
        public virtual DbSet<APILog> APILogs { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<InvoicePayment> InvoicePayments { get; set; }
        public virtual DbSet<Number> Numbers { get; set; }

      
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentsTax> PaymentsTaxes { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }

        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<SubscriptionBill> SubscriptionBills { get; set; }
        public virtual DbSet<SubscriptionPrice> SubscriptionPrices { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<SubscriptionStatusLog> SubscriptionStatusLogs { get; set; }
        public virtual DbSet<TicketNote> TicketNotes { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TicketStatu> TicketStatus { get; set; }
        public virtual DbSet<TicketTopic> TicketTopics { get; set; }
        public virtual DbSet<UploadedFile> UploadedFiles { get; set; }
        

        public virtual DbSet<LiveCards.Models.PrepaidForgeAPI.ProductAPIDetails> ProductAPIDetails { get; set; }
        public virtual DbSet<LiveCards.Models.PrepaidForgeAPI.DefaultPrice> DefaultPrice { get; set; }
        public virtual DbSet<LiveCards.Models.PrepaidForgeAPI.FaceValue> FaceValue { get; set; }
        public virtual DbSet<LiveCards.Models.PrepaidForgeAPI.ProductAPIStock> ProductAPIStocks { get; set; }

      
        
        
        public virtual DbSet<LiveCards.Models.PrepaidForgeAPI.ProductAPIStock1> Temp_PrepaidForgeStocks { get; set; }
        public virtual DbSet<LiveCards.Models.PrepaidForgeAPI.ProductAPIDetails1> Temp_ProductAPIDetails { get; set; }


    }
}