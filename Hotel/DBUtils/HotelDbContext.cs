using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Hotel.DataModels;
namespace Hotel.DBUtils
{
    public class HotelDbContext:DbContext
    {

        /// <summary>
        /// Return DbSet of table CLIENT from database.
        /// </summary>
        public DbSet<Client> Clients { get; set; }
        /// <summary>
        /// Return DbSet of table ADDS from database.
        /// </summary>
        public DbSet<Add>Adds { get; set; }
        /// <summary>
        /// Return DbSet of table BOARDING from database.
        /// </summary>
        public DbSet<Boarding> Boardings { get; set; }
        /// <summary>
        /// Return DbSet of table RESERVATION from database.
        /// </summary>
        public DbSet<Reservation> Reservations { get; set; }
        /// <summary>
        /// Return DbSet of table ROOM from database.
        /// </summary>
        public DbSet<Room> Rooms { get; set; }
        /// <summary>
        /// Return DbSet of table ROOM_QUALITY from database.
        /// </summary>
        public DbSet<RoomQuality> RoomQualities { get; set; }
        /// <summary>
        /// Return DbSet of table ROOM_STATUS from database.
        /// </summary>
        public DbSet<RoomStatus> RoomStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=hoteldb.db", option => {
                option.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("CLIENT").HasKey(e => e.ClientId);
            modelBuilder.Entity<Add>().ToTable("ADDS").HasKey(e => e.AddId);
            modelBuilder.Entity<Boarding>().ToTable("BOARDING").HasKey(e => e.BoardingId);
            modelBuilder.Entity<Reservation>().ToTable("RESERVATION").HasKey(e => e.ReservationId);
            modelBuilder.Entity<Room>().ToTable("ROOM").HasKey(e => e.RoomId);
            modelBuilder.Entity<RoomQuality>().ToTable("ROOM_QUALITY").HasKey(e => e.RoomQualityId);
            modelBuilder.Entity<RoomStatus>().ToTable("ROOM_STATUS").HasKey(e => e.StatusId);
            base.OnModelCreating(modelBuilder);
        }
    }

    }
