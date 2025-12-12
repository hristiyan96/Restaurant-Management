using RestaurantManagement.Models;

namespace RestaurantManagement.Data
{
    public static class MenuSeedData
    {
        public static List<MenuItem> GetMenuItems(DateTime seedDate)
        {
            var menuItems = new List<MenuItem>();

            // Предястия (Appetizers)
            menuItems.AddRange(new[]
            {
                new MenuItem { Id = Guid.Parse("10000001-0000-0000-0000-000000000000"), Name = "Брускета с домати", Description = "Печен хляб с домати, чесън и босилек", Price = 8.50m, Category = "Предястия", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("10000002-0000-0000-0000-000000000000"), Name = "Капрезе", Description = "Моцарела, домати, босилек и зехтин", Price = 10.00m, Category = "Предястия", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("10000003-0000-0000-0000-000000000000"), Name = "Чесънков хляб", Description = "Топъл хляб с чесън и масло", Price = 6.00m, Category = "Предястия", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("10000004-0000-0000-0000-000000000000"), Name = "Крем суп от гъби", Description = "Кремообразна супа от свежи гъби", Price = 9.50m, Category = "Предястия", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("10000005-0000-0000-0000-000000000000"), Name = "Сырена табла", Description = "Смес от български сирена с мед и орехи", Price = 12.00m, Category = "Предястия", CreatedAt = seedDate, UpdatedAt = seedDate }
            });

            // Салати (Salads)
            menuItems.AddRange(new[]
            {
                new MenuItem { Id = Guid.Parse("BBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBBBB"), Name = "Салата Цезар", Description = "Свежа салата с пилешко месо", Price = 12.50m, Category = "Салати", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("20000001-0000-0000-0000-000000000000"), Name = "Гръцка салата", Description = "Домати, краставици, лук, маслини, сирене", Price = 11.00m, Category = "Салати", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("20000002-0000-0000-0000-000000000000"), Name = "Салата от рукола", Description = "Рукола, червени домати, пармезан", Price = 10.50m, Category = "Салати", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("20000003-0000-0000-0000-000000000000"), Name = "Шопска салата", Description = "Класическа българска салата", Price = 9.00m, Category = "Салати", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("20000004-0000-0000-0000-000000000000"), Name = "Салата с риба тон", Description = "Свежа салата с риба тон и яйце", Price = 13.00m, Category = "Салати", CreatedAt = seedDate, UpdatedAt = seedDate }
            });

            // Супи (Soups)
            menuItems.AddRange(new[]
            {
                new MenuItem { Id = Guid.Parse("30000001-0000-0000-0000-000000000000"), Name = "Таратор", Description = "Българска студена супа от кисело мляко", Price = 7.50m, Category = "Супи", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("30000002-0000-0000-0000-000000000000"), Name = "Чорба по балкански", Description = "Традиционна чорба с месо и зеленчуци", Price = 10.00m, Category = "Супи", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("30000003-0000-0000-0000-000000000000"), Name = "Гъбена супа", Description = "Супа от свежи гъби с крем", Price = 9.50m, Category = "Супи", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("30000004-0000-0000-0000-000000000000"), Name = "Рибена чорба", Description = "Традиционна рибена супа", Price = 11.50m, Category = "Супи", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("30000005-0000-0000-0000-000000000000"), Name = "Суп от червена леща", Description = "Пикантна супа от червена леща", Price = 8.00m, Category = "Супи", CreatedAt = seedDate, UpdatedAt = seedDate }
            });

            // Пици (Pizzas)
            menuItems.AddRange(new[]
            {
                new MenuItem { Id = Guid.Parse("CCCCCCCC-CCCC-CCCC-CCCC-CCCCCCCCCCCC"), Name = "Пица Маргарита", Description = "Класическа пица с моцарела", Price = 18.00m, Category = "Пици", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("40000001-0000-0000-0000-000000000000"), Name = "Пица Пеперони", Description = "Пица с пеперони и моцарела", Price = 20.00m, Category = "Пици", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("40000002-0000-0000-0000-000000000000"), Name = "Пица Капричоза", Description = "Гъби, шунка, маслини, артишоки", Price = 22.00m, Category = "Пици", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("40000003-0000-0000-0000-000000000000"), Name = "Пица Четири сирена", Description = "Моцарела, горгонзола, пармезан, рикота", Price = 21.00m, Category = "Пици", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("40000004-0000-0000-0000-000000000000"), Name = "Пица Вегетарианска", Description = "Разнообразие от свежи зеленчуци", Price = 19.00m, Category = "Пици", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("40000005-0000-0000-0000-000000000000"), Name = "Пица Хавайска", Description = "Шунка, ананас, моцарела", Price = 20.50m, Category = "Пици", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("40000006-0000-0000-0000-000000000000"), Name = "Пица Четири сезона", Description = "Класическа италианска пица", Price = 23.00m, Category = "Пици", CreatedAt = seedDate, UpdatedAt = seedDate }
            });

            // Основни ястия (Main Dishes)
            menuItems.AddRange(new[]
            {
                new MenuItem { Id = Guid.Parse("DDDDDDDD-DDDD-DDDD-DDDD-DDDDDDDDDDDD"), Name = "Гриловано пиле", Description = "Сочно пилешко филе", Price = 22.00m, Category = "Основни", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("50000001-0000-0000-0000-000000000000"), Name = "Свинска пържола", Description = "Грилована свинска пържола с картофи", Price = 25.00m, Category = "Основни", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("50000002-0000-0000-0000-000000000000"), Name = "Рибно филе", Description = "Печено рибно филе с лимон", Price = 24.00m, Category = "Основни", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("50000003-0000-0000-0000-000000000000"), Name = "Паста Карбонара", Description = "Спагети с бекон, яйце и пармезан", Price = 19.50m, Category = "Основни", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("50000004-0000-0000-0000-000000000000"), Name = "Паста Болонезе", Description = "Спагети с месо и доматен сос", Price = 20.00m, Category = "Основни", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("50000005-0000-0000-0000-000000000000"), Name = "Лазаня", Description = "Традиционна италианска лазаня", Price = 21.50m, Category = "Основни", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("50000006-0000-0000-0000-000000000000"), Name = "Кавърма", Description = "Традиционно българско ястие", Price = 23.00m, Category = "Основни", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("50000007-0000-0000-0000-000000000000"), Name = "Мусака", Description = "Балканска мусака с картофи", Price = 22.50m, Category = "Основни", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("50000008-0000-0000-0000-000000000000"), Name = "Телешко филе", Description = "Гриловано телешко филе с гарнитура", Price = 28.00m, Category = "Основни", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("50000009-0000-0000-0000-000000000000"), Name = "Риба на скара", Description = "Печена риба с зеленчуци", Price = 26.00m, Category = "Основни", CreatedAt = seedDate, UpdatedAt = seedDate }
            });

            // Десерти (Desserts)
            menuItems.AddRange(new[]
            {
                new MenuItem { Id = Guid.Parse("EEEEEEEE-EEEE-EEEE-EEEE-EEEEEEEEEEEE"), Name = "Тирамису", Description = "Италиански десерт", Price = 8.50m, Category = "Десерти", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("60000001-0000-0000-0000-000000000000"), Name = "Шоколадова торта", Description = "Богата шоколадова торта", Price = 9.00m, Category = "Десерти", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("60000002-0000-0000-0000-000000000000"), Name = "Чийзкейк", Description = "Класически чийзкейк с плодове", Price = 8.50m, Category = "Десерти", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("60000003-0000-0000-0000-000000000000"), Name = "Крем карамел", Description = "Френски крем карамел", Price = 7.50m, Category = "Десерти", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("60000004-0000-0000-0000-000000000000"), Name = "Палачинки", Description = "Сладки палачинки с мед или сладко", Price = 6.50m, Category = "Десерти", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("60000005-0000-0000-0000-000000000000"), Name = "Мус от манго", Description = "Свеж мус от манго", Price = 8.00m, Category = "Десерти", CreatedAt = seedDate, UpdatedAt = seedDate }
            });

            // Напитки - Безалкохолни (Soft Drinks)
            menuItems.AddRange(new[]
            {
                new MenuItem { Id = Guid.Parse("70000001-0000-0000-0000-000000000000"), Name = "Кока Кола", Description = "330ml", Price = 3.50m, Category = "Безалкохолни", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("70000002-0000-0000-0000-000000000000"), Name = "Пепси", Description = "330ml", Price = 3.50m, Category = "Безалкохолни", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("70000003-0000-0000-0000-000000000000"), Name = "Фанта", Description = "330ml", Price = 3.50m, Category = "Безалкохолни", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("70000004-0000-0000-0000-000000000000"), Name = "Спрайт", Description = "330ml", Price = 3.50m, Category = "Безалкохолни", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("70000005-0000-0000-0000-000000000000"), Name = "Тоника", Description = "330ml", Price = 3.50m, Category = "Безалкохолни", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("70000006-0000-0000-0000-000000000000"), Name = "Минерална вода", Description = "500ml", Price = 2.50m, Category = "Безалкохолни", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("70000007-0000-0000-0000-000000000000"), Name = "Газирана вода", Description = "500ml", Price = 2.50m, Category = "Безалкохолни", CreatedAt = seedDate, UpdatedAt = seedDate }
            });

            // Напитки - Сокове (Juices)
            menuItems.AddRange(new[]
            {
                new MenuItem { Id = Guid.Parse("80000001-0000-0000-0000-000000000000"), Name = "Портокалов сок", Description = "Свеж пресен сок 300ml", Price = 5.00m, Category = "Сокове", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("80000002-0000-0000-0000-000000000000"), Name = "Ябълков сок", Description = "Свеж пресен сок 300ml", Price = 5.00m, Category = "Сокове", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("80000003-0000-0000-0000-000000000000"), Name = "Вишнев сок", Description = "Свеж пресен сок 300ml", Price = 5.50m, Category = "Сокове", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("80000004-0000-0000-0000-000000000000"), Name = "Гроздов сок", Description = "Свеж пресен сок 300ml", Price = 5.00m, Category = "Сокове", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("80000005-0000-0000-0000-000000000000"), Name = "Многоцветен сок", Description = "Микс от плодове 300ml", Price = 5.50m, Category = "Сокове", CreatedAt = seedDate, UpdatedAt = seedDate }
            });

            // Кафе (Coffee)
            menuItems.AddRange(new[]
            {
                new MenuItem { Id = Guid.Parse("90000001-0000-0000-0000-000000000000"), Name = "Еспресо", Description = "Класическо еспресо", Price = 3.00m, Category = "Кафе", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("90000002-0000-0000-0000-000000000000"), Name = "Капучино", Description = "Еспресо с мляко и пяна", Price = 4.50m, Category = "Кафе", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("90000003-0000-0000-0000-000000000000"), Name = "Лате", Description = "Еспресо с много мляко", Price = 4.50m, Category = "Кафе", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("90000004-0000-0000-0000-000000000000"), Name = "Американо", Description = "Еспресо с гореща вода", Price = 3.50m, Category = "Кафе", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("90000005-0000-0000-0000-000000000000"), Name = "Мокачино", Description = "Капучино с шоколад", Price = 5.00m, Category = "Кафе", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("90000006-0000-0000-0000-000000000000"), Name = "Флатуайт", Description = "Кремообразно кафе с мляко", Price = 5.00m, Category = "Кафе", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("90000007-0000-0000-0000-000000000000"), Name = "Лате макиато", Description = "Слоесто кафе и мляко", Price = 5.00m, Category = "Кафе", CreatedAt = seedDate, UpdatedAt = seedDate }
            });

            // Алкохол - Вина (Wines)
            menuItems.AddRange(new[]
            {
                new MenuItem { Id = Guid.Parse("A0000001-0000-0000-0000-000000000000"), Name = "Червено вино - дом", Description = "150ml", Price = 6.00m, Category = "Вина", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("A0000002-0000-0000-0000-000000000000"), Name = "Бяло вино - дом", Description = "150ml", Price = 6.00m, Category = "Вина", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("A0000003-0000-0000-0000-000000000000"), Name = "Розе вино - дом", Description = "150ml", Price = 6.00m, Category = "Вина", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("A0000004-0000-0000-0000-000000000000"), Name = "Червено вино - бутилка", Description = "750ml", Price = 25.00m, Category = "Вина", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("A0000005-0000-0000-0000-000000000000"), Name = "Бяло вино - бутилка", Description = "750ml", Price = 25.00m, Category = "Вина", CreatedAt = seedDate, UpdatedAt = seedDate }
            });

            // Алкохол - Бира (Beer)
            menuItems.AddRange(new[]
            {
                new MenuItem { Id = Guid.Parse("B0000001-0000-0000-0000-000000000000"), Name = "Бира - Загорка", Description = "500ml", Price = 4.50m, Category = "Бира", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("B0000002-0000-0000-0000-000000000000"), Name = "Бира - Каменица", Description = "500ml", Price = 4.50m, Category = "Бира", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("B0000003-0000-0000-0000-000000000000"), Name = "Бира - Ариана", Description = "500ml", Price = 4.50m, Category = "Бира", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("B0000004-0000-0000-0000-000000000000"), Name = "Бира - Хайнекен", Description = "500ml", Price = 5.50m, Category = "Бира", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("B0000005-0000-0000-0000-000000000000"), Name = "Бира - Старопрамен", Description = "500ml", Price = 5.00m, Category = "Бира", CreatedAt = seedDate, UpdatedAt = seedDate }
            });

            // Алкохол - Коктейли (Cocktails)
            menuItems.AddRange(new[]
            {
                new MenuItem { Id = Guid.Parse("C0000001-0000-0000-0000-000000000000"), Name = "Мохито", Description = "Класически мохито с мента", Price = 8.00m, Category = "Коктейли", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("C0000002-0000-0000-0000-000000000000"), Name = "Пина Колада", Description = "Тропически коктейл", Price = 9.00m, Category = "Коктейли", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("C0000003-0000-0000-0000-000000000000"), Name = "Маргарита", Description = "Класическа маргарита", Price = 8.50m, Category = "Коктейли", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("C0000004-0000-0000-0000-000000000000"), Name = "Космополитен", Description = "Модерен коктейл", Price = 9.00m, Category = "Коктейли", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("C0000005-0000-0000-0000-000000000000"), Name = "Майтай", Description = "Екзотичен коктейл", Price = 8.50m, Category = "Коктейли", CreatedAt = seedDate, UpdatedAt = seedDate }
            });

            // Алкохол - Силни (Strong Alcohol)
            menuItems.AddRange(new[]
            {
                new MenuItem { Id = Guid.Parse("D0000001-0000-0000-0000-000000000000"), Name = "Ракия", Description = "50ml", Price = 5.00m, Category = "Силни напитки", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("D0000002-0000-0000-0000-000000000000"), Name = "Уиски", Description = "50ml", Price = 8.00m, Category = "Силни напитки", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("D0000003-0000-0000-0000-000000000000"), Name = "Водка", Description = "50ml", Price = 6.00m, Category = "Силни напитки", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("D0000004-0000-0000-0000-000000000000"), Name = "Коняк", Description = "50ml", Price = 7.00m, Category = "Силни напитки", CreatedAt = seedDate, UpdatedAt = seedDate },
                new MenuItem { Id = Guid.Parse("D0000005-0000-0000-0000-000000000000"), Name = "Ром", Description = "50ml", Price = 7.00m, Category = "Силни напитки", CreatedAt = seedDate, UpdatedAt = seedDate }
            });

            return menuItems;
        }
    }
}
