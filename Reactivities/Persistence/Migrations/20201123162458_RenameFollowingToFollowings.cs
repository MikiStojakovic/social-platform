using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
 public partial class RenameFollowingToFollowings : Migration
 {
  protected override void Up(MigrationBuilder migrationBuilder)
  {
   migrationBuilder.Sql(@"PRAGMA legacy_alter_table=OFF;
        DROP TABLE Following;
        CREATE TABLE Followings (
        ObserverId text,
        TargetId text,
        FOREIGN KEY (ObserverId) REFERENCES AspNetUsers(Id),
        FOREIGN KEY (TargetId) REFERENCES AspNetUsers(Id),
        CONSTRAINT PK_Followings PRIMARY KEY (ObserverId, TargetId)
        )
   ");
   //    migrationBuilder.DropForeignKey(
   //        name: "FK_Following_AspNetUsers_ObserverId",
   //        table: "Following");

   //    migrationBuilder.DropForeignKey(
   //        name: "FK_Following_AspNetUsers_TargetId",
   //        table: "Following");

   //    migrationBuilder.DropPrimaryKey(
   //        name: "PK_Following",
   //        table: "Following");

   //    migrationBuilder.RenameTable(
   //        name: "Following",
   //        newName: "Followings");

   //    migrationBuilder.RenameIndex(
   //        name: "IX_Following_TargetId",
   //        table: "Followings",
   //        newName: "IX_Followings_TargetId");

   //    migrationBuilder.AddPrimaryKey(
   //        name: "PK_Followings",
   //        table: "Followings",
   //        columns: new[] { "ObserverId", "TargetId" });

   //    migrationBuilder.AddForeignKey(
   //        name: "FK_Followings_AspNetUsers_ObserverId",
   //        table: "Followings",
   //        column: "ObserverId",
   //        principalTable: "AspNetUsers",
   //        principalColumn: "Id",
   //        onDelete: ReferentialAction.Restrict);

   //    migrationBuilder.AddForeignKey(
   //        name: "FK_Followings_AspNetUsers_TargetId",
   //        table: "Followings",
   //        column: "TargetId",
   //        principalTable: "AspNetUsers",
   //        principalColumn: "Id",
   //        onDelete: ReferentialAction.Restrict);
  }

  protected override void Down(MigrationBuilder migrationBuilder)
  {
   migrationBuilder.DropForeignKey(
       name: "FK_Followings_AspNetUsers_ObserverId",
       table: "Followings");

   migrationBuilder.DropForeignKey(
       name: "FK_Followings_AspNetUsers_TargetId",
       table: "Followings");

   migrationBuilder.DropPrimaryKey(
       name: "PK_Followings",
       table: "Followings");

   migrationBuilder.RenameTable(
       name: "Followings",
       newName: "Following");

   migrationBuilder.RenameIndex(
       name: "IX_Followings_TargetId",
       table: "Following",
       newName: "IX_Following_TargetId");

   migrationBuilder.AddPrimaryKey(
       name: "PK_Following",
       table: "Following",
       columns: new[] { "ObserverId", "TargetId" });

   migrationBuilder.AddForeignKey(
       name: "FK_Following_AspNetUsers_ObserverId",
       table: "Following",
       column: "ObserverId",
       principalTable: "AspNetUsers",
       principalColumn: "Id",
       onDelete: ReferentialAction.Restrict);

   migrationBuilder.AddForeignKey(
       name: "FK_Following_AspNetUsers_TargetId",
       table: "Following",
       column: "TargetId",
       principalTable: "AspNetUsers",
       principalColumn: "Id",
       onDelete: ReferentialAction.Restrict);
  }
 }
}
