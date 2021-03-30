using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Photory.Migrations
{
    public partial class mg3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "555555f0-dee2–42de-bbbb-59kmkkmk72cf6", null, "GroupAdmin", "GroupAdmin" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e942a01d-b610-46fe-8b6f-a46cbf1e68dd", "AQAAAAEAACcQAAAAEK1wqQh005ViKZm2WrGV/uINWeUbOVWC+rPt1CfddfqWvTttMxBrNSDIgo9NC4oTOg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ed8139a4-d084-49b3-a23f-7e50b9becb65", "AQAAAAEAACcQAAAAEFs6I1lRqgnabZXAP2u6I+BKP2Q52cHtWLetAFjjncAgV0cIViDcf6dpQpqqCdJtCQ==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e3894cf0–9412–4cfe-afbf-59f706d72cf6", 0, "a6ba863d-959b-4bcd-8077-12bccb19f914", "veres.levente@nik.uni-obuda.hu", true, false, null, "veres.levente@nik.uni-obuda.hu", "veres.levente@nik.uni-obuda.hu", "AQAAAAEAACcQAAAAEBqnwl4o+iKFKkBfVJzjeXQh42+qqBjteqY9CL4AXmgaepX37oIvJZ1D540ifrDiDA==", null, false, "", false, "veres.levente@nik.uni-obuda.hu" });

            migrationBuilder.InsertData(
                table: "MyUsers",
                columns: new[] { "UserName", "BirthDate", "Email", "FullName", "Password", "UserAccess" },
                values: new object[,]
                {
                    { "HegedusMate", new DateTime(2000, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "hegedus.mate@nik.uni-obuda.hu", "HegedusMate", "AQAAAAEAACcQAAAAEK1wqQh005ViKZm2WrGV/uINWeUbOVWC+rPt1CfddfqWvTttMxBrNSDIgo9NC4oTOg==", 2 },
                    { "gadacsi.akos@nik.uni-obuda.hu", new DateTime(2000, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "gadacsi.akos@nik.uni-obuda.hu", "gadacsi.akos@nik.uni-obuda.hu", "AQAAAAEAACcQAAAAEFs6I1lRqgnabZXAP2u6I+BKP2Q52cHtWLetAFjjncAgV0cIViDcf6dpQpqqCdJtCQ==", 0 },
                    { "veres.levente@nik.uni-obuda.hu", new DateTime(2000, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "veres.levente@nik.uni-obuda.hu", "veres.levente@nik.uni-obuda.hu", "AQAAAAEAACcQAAAAEBqnwl4o+iKFKkBfVJzjeXQh42+qqBjteqY9CL4AXmgaepX37oIvJZ1D540ifrDiDA==", 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "555555f0-dee2–42de-bbbb-59kmkkmk72cf6", "e3894cf0–9412–4cfe-afbf-59f706d72cf6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "555555f0-dee2–42de-bbbb-59kmkkmk72cf6", "e3894cf0–9412–4cfe-afbf-59f706d72cf6" });

            migrationBuilder.DeleteData(
                table: "MyUsers",
                keyColumn: "UserName",
                keyValue: "gadacsi.akos@nik.uni-obuda.hu");

            migrationBuilder.DeleteData(
                table: "MyUsers",
                keyColumn: "UserName",
                keyValue: "HegedusMate");

            migrationBuilder.DeleteData(
                table: "MyUsers",
                keyColumn: "UserName",
                keyValue: "veres.levente@nik.uni-obuda.hu");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "555555f0-dee2–42de-bbbb-59kmkkmk72cf6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e3894cf0–9412–4cfe-afbf-59f706d72cf6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e3c9f400-8dff-434f-9089-d13ddafd17ba", "AQAAAAEAACcQAAAAEPd9pEYp7gFPbJsCJ7igwF7e+zy3UADi85VnqSOVsHY/VfJ01xi+wiX37qlCi3A6XA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f4012bb6-a23b-48bb-ba63-7bc101a873da", "AQAAAAEAACcQAAAAEEdH+bir5u7CCsP/inRTWbciHheaF3GfF+ziorN8hu3zhOXkccY5a8EpMMJ27D+H4Q==" });
        }
    }
}
