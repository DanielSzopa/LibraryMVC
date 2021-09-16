using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryMVC.WebApplication.Migrations
{
    public partial class InitializeExampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 2, "Polska dziennikarka i scenarzystka, autorka bestsellerowych powieści kryminalnych", "Katarzyna", "Bonda" },
                    { 3, "Brytyjska autorka powieści kryminalnych i obyczajowych", "Agatha", "Christie" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Book" },
                    { 3, "Newspaper" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "New Era" },
                    { 3, "Opera" }
                });

            migrationBuilder.InsertData(
                table: "TypeOfBooks",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Crime Story" },
                    { 3, "Romantic" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "DateOfRelease", "Description", "PublisherId", "Status", "Title", "TypeOfBookId" },
                values: new object[,]
                {
                    { 1, 2, 2, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sasza Załuska zostaje przyjęta na cywilny etat do gdańskiej policji i natychmiast oddelegowana do zadania w Łodzi.", 2, 2, "Lampiony", 2 },
                    { 2, 3, 2, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Historia zamożnego kupca warszawskiego Stanisława Wokulskiego i jego miłości do pięknej, lecz zubożałej arystokratki Izabeli Łęckiej.", 3, 2, "Lalka", 2 },
                    { 3, 3, 2, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ta epopeja narodowa (z elementami gawędy szlacheckiej) powstała w latach 1832–1834 w Paryżu.", 3, 2, "Pan Tadeusz", 2 },
                    { 4, 2, 3, new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Czasopismo opowiadające o początku kariery Junior Developera", 2, 2, "Biografia Daniela Szopy", 2 },
                    { 5, 2, 2, new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "„Wesele” stanowi najważniejszy młodopolski dramat. w Łodzi.", 2, 2, "Wesele", 2 },
                    { 6, 3, 2, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Historia dwojga ludzi, którzy zakochali się w Zakopanem", 2, 2, "Miłość w Zakopanem", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TypeOfBooks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TypeOfBooks",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
