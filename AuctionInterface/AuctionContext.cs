namespace AuctionInterface
{
    using AuctionInterface.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AuctionContext : DbContext
    {
        // Контекст настроен для использования строки подключения "AuctionContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "AuctionInterface.AuctionContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "AuctionContext" 
        // в файле конфигурации приложения.
        public AuctionContext()
            : base("name=AuctionContext")
        {
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Person> Clients { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Item> Items { get; set; }
    }

}