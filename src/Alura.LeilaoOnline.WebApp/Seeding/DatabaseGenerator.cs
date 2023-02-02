using System;
using Alura.LeilaoOnline.WebApp.Dados;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Seeding
{
    public static class DatabaseGenerator
    {
        public static void Seed()
        {
            using var ctx = new AppDbContext();

            if (!ctx.Database.EnsureCreated()) return;

            var generator = new LeilaoRandomGenerator(new Random());
            var leiloes = Enumerable.Range(1, 200)
                .Select(i => generator.NovoLeilao)
                .ToList();

            ctx.Leiloes.AddRange(leiloes);
            ctx.SaveChanges();
        }
    }
}