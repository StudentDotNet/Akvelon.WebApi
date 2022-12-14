using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Akvelon.Data.Migrations
{
    public partial class SeedMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CompletionDate", "Name", "Priority", "StartDate", "Status" },
                values: new object[,]
                {
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new DateTime(2012, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DocumentService App", 1, new DateTime(2011, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), new DateTime(2012, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "DocumentService Api", 1, new DateTime(2011, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), null, "Search Service Api", 2, new DateTime(2011, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("d28888e9-2ba9-474a-a40f-e38cb54f9b35"), new DateTime(12, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Auth Service", 3, new DateTime(11, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Description", "Name", "Priority", "ProjectId", "Status" },
                values: new object[,]
                {
                    { new Guid("c3c4a8ad-a580-4a56-992d-f04335dbfd85"), "Implementing UI part for document service", "Implementing UI part for document service", 1, new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), 2 },
                    { new Guid("3f44d87e-04b4-439c-831b-f9e8713aab25"), "Manuially Testing of the UI", "Testing UI", 1, new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), 1 },
                    { new Guid("7d2f6df3-a0a2-47ae-9ae0-ab1789be7445"), "Integration testing", "Integration testing", 1, new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), 0 },
                    { new Guid("a6b80c79-823e-466c-ba00-66b5ac8abec1"), "Configure service for importing pdf document", "Configure service for importing pdf document", 1, new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), 2 },
                    { new Guid("e0e2f624-40c8-4b3f-bc2f-4cc4efcf6832"), "Cover the service with unit test", "Cover the service with unit test", 2, new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), 1 },
                    { new Guid("bde46372-80a8-4578-8ac8-1b39047e322e"), "Deploy service in the Azure Cloud", "Deploy service in the Azure Cloud", 3, new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), 0 },
                    { new Guid("30918f83-db5a-4a73-a643-4b73347ac994"), "Configure Elastic Search", "Configure Elastic Search", 1, new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), 2 },
                    { new Guid("ba62b8e1-d0f4-49b3-8938-8b14b9c9f318"), "Create index for document", "Create index for document", 2, new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), 1 },
                    { new Guid("2a97bdfa-2002-46e8-a025-1e4565b90044"), "", "Implement searching using Nest sdk", 3, new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), 0 },
                    { new Guid("05427b1b-f16d-4e2b-81b4-072988f69bdf"), "", "Investigate how to integrate Identity Server", 1, new Guid("d28888e9-2ba9-474a-a40f-e38cb54f9b35"), 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("05427b1b-f16d-4e2b-81b4-072988f69bdf"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("2a97bdfa-2002-46e8-a025-1e4565b90044"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("30918f83-db5a-4a73-a643-4b73347ac994"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("3f44d87e-04b4-439c-831b-f9e8713aab25"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("7d2f6df3-a0a2-47ae-9ae0-ab1789be7445"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("a6b80c79-823e-466c-ba00-66b5ac8abec1"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("ba62b8e1-d0f4-49b3-8938-8b14b9c9f318"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("bde46372-80a8-4578-8ac8-1b39047e322e"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("c3c4a8ad-a580-4a56-992d-f04335dbfd85"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("e0e2f624-40c8-4b3f-bc2f-4cc4efcf6832"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("2902b665-1190-4c70-9915-b9c2d7680450"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("d28888e9-2ba9-474a-a40f-e38cb54f9b35"));
        }
    }
}
