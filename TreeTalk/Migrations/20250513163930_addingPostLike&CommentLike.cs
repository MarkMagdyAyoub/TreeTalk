using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TreeTalk.Migrations
{
    /// <inheritdoc />
    public partial class addingPostLikeCommentLike : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommentLike",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CommentId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentLike", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentLike_Comment_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentLike_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostLike",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PostId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostLike", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostLike_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostLike_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CommentLike",
                columns: new[] { "Id", "CommentId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 1, 3 },
                    { 3, 2, 1 },
                    { 4, 2, 4 },
                    { 5, 3, 2 },
                    { 6, 3, 4 },
                    { 7, 9, 1 },
                    { 8, 9, 5 },
                    { 9, 9, 6 },
                    { 10, 6, 7 },
                    { 11, 6, 8 },
                    { 12, 7, 9 },
                    { 13, 7, 10 },
                    { 14, 47, 11 },
                    { 15, 47, 12 },
                    { 16, 47, 13 },
                    { 17, 48, 14 },
                    { 18, 48, 15 },
                    { 19, 84, 16 },
                    { 20, 84, 17 },
                    { 21, 84, 18 },
                    { 22, 84, 19 },
                    { 23, 85, 20 },
                    { 24, 85, 1 },
                    { 25, 85, 2 }
                });

            migrationBuilder.InsertData(
                table: "PostLike",
                columns: new[] { "Id", "PostId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 1, 3 },
                    { 3, 2, 4 },
                    { 4, 2, 5 },
                    { 5, 2, 6 },
                    { 6, 3, 7 },
                    { 7, 3, 8 },
                    { 8, 9, 9 },
                    { 9, 9, 10 },
                    { 10, 9, 11 },
                    { 11, 9, 12 },
                    { 12, 9, 13 },
                    { 13, 9, 14 },
                    { 14, 16, 15 },
                    { 15, 16, 16 },
                    { 16, 16, 17 },
                    { 17, 16, 18 },
                    { 18, 16, 19 },
                    { 19, 16, 20 },
                    { 20, 13, 1 },
                    { 21, 13, 2 },
                    { 22, 13, 3 },
                    { 23, 13, 4 },
                    { 24, 13, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentLike_CommentId",
                table: "CommentLike",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentLike_UserId_CommentId",
                table: "CommentLike",
                columns: new[] { "UserId", "CommentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostLike_PostId",
                table: "PostLike",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostLike_UserId_PostId",
                table: "PostLike",
                columns: new[] { "UserId", "PostId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentLike");

            migrationBuilder.DropTable(
                name: "PostLike");
        }
    }
}
