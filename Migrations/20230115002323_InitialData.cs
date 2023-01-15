using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebEF.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CATEGORIES",
                columns: new[] { "CategoryId", "Description", "Name", "Weight" },
                values: new object[] { new Guid("0f1ef1d9-1ea5-4196-bb59-9cf9a28dbabb"), null, "Actividades Personales", 50 });

            migrationBuilder.InsertData(
                table: "CATEGORIES",
                columns: new[] { "CategoryId", "Description", "Name", "Weight" },
                values: new object[] { new Guid("e361edbb-6c63-4ed3-b2e5-f32f5adef57c"), null, "Actividades Pendientes", 20 });

            migrationBuilder.InsertData(
                table: "TASKS",
                columns: new[] { "TaskId", "CategoryId", "CreationDate", "Description", "TaskPriority", "Title" },
                values: new object[,]
                {
                    { new Guid("3531ca67-ca17-4061-872b-ceb0d59f1d3b"), new Guid("0f1ef1d9-1ea5-4196-bb59-9cf9a28dbabb"), new DateTime(2023, 1, 14, 19, 23, 22, 739, DateTimeKind.Local).AddTicks(3542), "Ir a pedir el prestamo al banco", 2, "Ir al banco" },
                    { new Guid("959ad597-82a6-49fa-a548-e679bdf3e72a"), new Guid("e361edbb-6c63-4ed3-b2e5-f32f5adef57c"), new DateTime(2023, 1, 14, 19, 23, 22, 739, DateTimeKind.Local).AddTicks(3538), "Diseñar modelo E/R de la base de datos del nuevo cliente", 2, "Diseñar modelo E/R" },
                    { new Guid("c1842460-d11f-447a-bdc1-ec751fd88b18"), new Guid("0f1ef1d9-1ea5-4196-bb59-9cf9a28dbabb"), new DateTime(2023, 1, 14, 19, 23, 22, 739, DateTimeKind.Local).AddTicks(3546), "Llevar la moto al lavadero", 1, "Lavar la moto" },
                    { new Guid("ecdde551-9a9f-484e-9a23-7dd982fb7882"), new Guid("e361edbb-6c63-4ed3-b2e5-f32f5adef57c"), new DateTime(2023, 1, 14, 19, 23, 22, 739, DateTimeKind.Local).AddTicks(3523), null, 0, "Crear web app de prueba" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TASKS",
                keyColumn: "TaskId",
                keyValue: new Guid("3531ca67-ca17-4061-872b-ceb0d59f1d3b"));

            migrationBuilder.DeleteData(
                table: "TASKS",
                keyColumn: "TaskId",
                keyValue: new Guid("959ad597-82a6-49fa-a548-e679bdf3e72a"));

            migrationBuilder.DeleteData(
                table: "TASKS",
                keyColumn: "TaskId",
                keyValue: new Guid("c1842460-d11f-447a-bdc1-ec751fd88b18"));

            migrationBuilder.DeleteData(
                table: "TASKS",
                keyColumn: "TaskId",
                keyValue: new Guid("ecdde551-9a9f-484e-9a23-7dd982fb7882"));

            migrationBuilder.DeleteData(
                table: "CATEGORIES",
                keyColumn: "CategoryId",
                keyValue: new Guid("0f1ef1d9-1ea5-4196-bb59-9cf9a28dbabb"));

            migrationBuilder.DeleteData(
                table: "CATEGORIES",
                keyColumn: "CategoryId",
                keyValue: new Guid("e361edbb-6c63-4ed3-b2e5-f32f5adef57c"));
        }
    }
}
