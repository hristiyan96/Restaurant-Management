using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddExpandedMenuItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Available", "Category", "CreatedAt", "Description", "ImageUrl", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("10000001-0000-0000-0000-000000000000"), true, "Предястия", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Печен хляб с домати, чесън и босилек", null, "Брускета с домати", 8.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("10000002-0000-0000-0000-000000000000"), true, "Предястия", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Моцарела, домати, босилек и зехтин", null, "Капрезе", 10.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("10000003-0000-0000-0000-000000000000"), true, "Предястия", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Топъл хляб с чесън и масло", null, "Чесънков хляб", 6.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("10000004-0000-0000-0000-000000000000"), true, "Предястия", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Кремообразна супа от свежи гъби", null, "Крем суп от гъби", 9.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("10000005-0000-0000-0000-000000000000"), true, "Предястия", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Смес от български сирена с мед и орехи", null, "Сырена табла", 12.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("20000001-0000-0000-0000-000000000000"), true, "Салати", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Домати, краставици, лук, маслини, сирене", null, "Гръцка салата", 11.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("20000002-0000-0000-0000-000000000000"), true, "Салати", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Рукола, червени домати, пармезан", null, "Салата от рукола", 10.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("20000003-0000-0000-0000-000000000000"), true, "Салати", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Класическа българска салата", null, "Шопска салата", 9.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("20000004-0000-0000-0000-000000000000"), true, "Салати", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Свежа салата с риба тон и яйце", null, "Салата с риба тон", 13.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("30000001-0000-0000-0000-000000000000"), true, "Супи", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Българска студена супа от кисело мляко", null, "Таратор", 7.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("30000002-0000-0000-0000-000000000000"), true, "Супи", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Традиционна чорба с месо и зеленчуци", null, "Чорба по балкански", 10.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("30000003-0000-0000-0000-000000000000"), true, "Супи", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Супа от свежи гъби с крем", null, "Гъбена супа", 9.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("30000004-0000-0000-0000-000000000000"), true, "Супи", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Традиционна рибена супа", null, "Рибена чорба", 11.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("30000005-0000-0000-0000-000000000000"), true, "Супи", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Пикантна супа от червена леща", null, "Суп от червена леща", 8.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000001-0000-0000-0000-000000000000"), true, "Пици", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Пица с пеперони и моцарела", null, "Пица Пеперони", 20.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000002-0000-0000-0000-000000000000"), true, "Пици", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Гъби, шунка, маслини, артишоки", null, "Пица Капричоза", 22.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000003-0000-0000-0000-000000000000"), true, "Пици", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Моцарела, горгонзола, пармезан, рикота", null, "Пица Четири сирена", 21.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000004-0000-0000-0000-000000000000"), true, "Пици", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Разнообразие от свежи зеленчуци", null, "Пица Вегетарианска", 19.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000005-0000-0000-0000-000000000000"), true, "Пици", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Шунка, ананас, моцарела", null, "Пица Хавайска", 20.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000006-0000-0000-0000-000000000000"), true, "Пици", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Класическа италианска пица", null, "Пица Четири сезона", 23.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("50000001-0000-0000-0000-000000000000"), true, "Основни", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Грилована свинска пържола с картофи", null, "Свинска пържола", 25.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("50000002-0000-0000-0000-000000000000"), true, "Основни", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Печено рибно филе с лимон", null, "Рибно филе", 24.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("50000003-0000-0000-0000-000000000000"), true, "Основни", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Спагети с бекон, яйце и пармезан", null, "Паста Карбонара", 19.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("50000004-0000-0000-0000-000000000000"), true, "Основни", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Спагети с месо и доматен сос", null, "Паста Болонезе", 20.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("50000005-0000-0000-0000-000000000000"), true, "Основни", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Традиционна италианска лазаня", null, "Лазаня", 21.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("50000006-0000-0000-0000-000000000000"), true, "Основни", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Традиционно българско ястие", null, "Кавърма", 23.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("50000007-0000-0000-0000-000000000000"), true, "Основни", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Балканска мусака с картофи", null, "Мусака", 22.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("50000008-0000-0000-0000-000000000000"), true, "Основни", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Гриловано телешко филе с гарнитура", null, "Телешко филе", 28.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("50000009-0000-0000-0000-000000000000"), true, "Основни", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Печена риба с зеленчуци", null, "Риба на скара", 26.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("60000001-0000-0000-0000-000000000000"), true, "Десерти", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Богата шоколадова торта", null, "Шоколадова торта", 9.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("60000002-0000-0000-0000-000000000000"), true, "Десерти", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Класически чийзкейк с плодове", null, "Чийзкейк", 8.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("60000003-0000-0000-0000-000000000000"), true, "Десерти", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Френски крем карамел", null, "Крем карамел", 7.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("60000004-0000-0000-0000-000000000000"), true, "Десерти", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Сладки палачинки с мед или сладко", null, "Палачинки", 6.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("60000005-0000-0000-0000-000000000000"), true, "Десерти", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Свеж мус от манго", null, "Мус от манго", 8.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000001-0000-0000-0000-000000000000"), true, "Безалкохолни", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "330ml", null, "Кока Кола", 3.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000002-0000-0000-0000-000000000000"), true, "Безалкохолни", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "330ml", null, "Пепси", 3.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000003-0000-0000-0000-000000000000"), true, "Безалкохолни", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "330ml", null, "Фанта", 3.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000004-0000-0000-0000-000000000000"), true, "Безалкохолни", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "330ml", null, "Спрайт", 3.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000005-0000-0000-0000-000000000000"), true, "Безалкохолни", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "330ml", null, "Тоника", 3.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000006-0000-0000-0000-000000000000"), true, "Безалкохолни", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "500ml", null, "Минерална вода", 2.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("70000007-0000-0000-0000-000000000000"), true, "Безалкохолни", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "500ml", null, "Газирана вода", 2.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("80000001-0000-0000-0000-000000000000"), true, "Сокове", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Свеж пресен сок 300ml", null, "Портокалов сок", 5.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("80000002-0000-0000-0000-000000000000"), true, "Сокове", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Свеж пресен сок 300ml", null, "Ябълков сок", 5.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("80000003-0000-0000-0000-000000000000"), true, "Сокове", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Свеж пресен сок 300ml", null, "Вишнев сок", 5.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("80000004-0000-0000-0000-000000000000"), true, "Сокове", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Свеж пресен сок 300ml", null, "Гроздов сок", 5.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("80000005-0000-0000-0000-000000000000"), true, "Сокове", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Микс от плодове 300ml", null, "Многоцветен сок", 5.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("90000001-0000-0000-0000-000000000000"), true, "Кафе", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Класическо еспресо", null, "Еспресо", 3.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("90000002-0000-0000-0000-000000000000"), true, "Кафе", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Еспресо с мляко и пяна", null, "Капучино", 4.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("90000003-0000-0000-0000-000000000000"), true, "Кафе", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Еспресо с много мляко", null, "Лате", 4.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("90000004-0000-0000-0000-000000000000"), true, "Кафе", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Еспресо с гореща вода", null, "Американо", 3.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("90000005-0000-0000-0000-000000000000"), true, "Кафе", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Капучино с шоколад", null, "Мокачино", 5.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("90000006-0000-0000-0000-000000000000"), true, "Кафе", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Кремообразно кафе с мляко", null, "Флатуайт", 5.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("90000007-0000-0000-0000-000000000000"), true, "Кафе", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Слоесто кафе и мляко", null, "Лате макиато", 5.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("a0000001-0000-0000-0000-000000000000"), true, "Вина", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "150ml", null, "Червено вино - дом", 6.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("a0000002-0000-0000-0000-000000000000"), true, "Вина", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "150ml", null, "Бяло вино - дом", 6.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("a0000003-0000-0000-0000-000000000000"), true, "Вина", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "150ml", null, "Розе вино - дом", 6.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("a0000004-0000-0000-0000-000000000000"), true, "Вина", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "750ml", null, "Червено вино - бутилка", 25.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("a0000005-0000-0000-0000-000000000000"), true, "Вина", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "750ml", null, "Бяло вино - бутилка", 25.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("b0000001-0000-0000-0000-000000000000"), true, "Бира", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "500ml", null, "Бира - Загорка", 4.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("b0000002-0000-0000-0000-000000000000"), true, "Бира", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "500ml", null, "Бира - Каменица", 4.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("b0000003-0000-0000-0000-000000000000"), true, "Бира", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "500ml", null, "Бира - Ариана", 4.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("b0000004-0000-0000-0000-000000000000"), true, "Бира", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "500ml", null, "Бира - Хайнекен", 5.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("b0000005-0000-0000-0000-000000000000"), true, "Бира", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "500ml", null, "Бира - Старопрамен", 5.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c0000001-0000-0000-0000-000000000000"), true, "Коктейли", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Класически мохито с мента", null, "Мохито", 8.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c0000002-0000-0000-0000-000000000000"), true, "Коктейли", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Тропически коктейл", null, "Пина Колада", 9.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c0000003-0000-0000-0000-000000000000"), true, "Коктейли", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Класическа маргарита", null, "Маргарита", 8.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c0000004-0000-0000-0000-000000000000"), true, "Коктейли", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Модерен коктейл", null, "Космополитен", 9.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c0000005-0000-0000-0000-000000000000"), true, "Коктейли", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Екзотичен коктейл", null, "Майтай", 8.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("d0000001-0000-0000-0000-000000000000"), true, "Силни напитки", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "50ml", null, "Ракия", 5.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("d0000002-0000-0000-0000-000000000000"), true, "Силни напитки", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "50ml", null, "Уиски", 8.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("d0000003-0000-0000-0000-000000000000"), true, "Силни напитки", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "50ml", null, "Водка", 6.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("d0000004-0000-0000-0000-000000000000"), true, "Силни напитки", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "50ml", null, "Коняк", 7.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("d0000005-0000-0000-0000-000000000000"), true, "Силни напитки", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "50ml", null, "Ром", 7.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("10000001-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("10000002-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("10000003-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("10000004-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("10000005-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("20000001-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("20000002-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("20000003-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("20000004-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("30000001-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("30000002-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("30000003-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("30000004-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("30000005-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("40000001-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("40000002-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("40000003-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("40000004-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("40000005-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("40000006-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("50000001-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("50000002-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("50000003-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("50000004-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("50000005-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("50000006-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("50000007-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("50000008-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("50000009-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("60000001-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("60000002-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("60000003-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("60000004-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("60000005-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("70000001-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("70000002-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("70000003-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("70000004-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("70000005-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("70000006-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("70000007-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("80000001-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("80000002-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("80000003-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("80000004-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("80000005-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("90000001-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("90000002-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("90000003-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("90000004-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("90000005-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("90000006-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("90000007-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("a0000001-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("a0000002-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("a0000003-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("a0000004-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("a0000005-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("b0000001-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("b0000002-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("b0000003-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("b0000004-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("b0000005-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("c0000001-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("c0000002-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("c0000003-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("c0000004-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("c0000005-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("d0000002-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("d0000003-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("d0000004-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("d0000005-0000-0000-0000-000000000000"));
        }
    }
}
