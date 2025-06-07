using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API_Restoran.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cafe");

            migrationBuilder.CreateTable(
                name: "dish",
                schema: "cafe",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    sum = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dish", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ingredients",
                schema: "cafe",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                schema: "cafe",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "status",
                schema: "cafe",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tables",
                schema: "cafe",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tables", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dish_ingredients",
                schema: "cafe",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dish_id = table.Column<int>(type: "integer", nullable: false),
                    ingredient_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dish_ingredients", x => x.id);
                    table.ForeignKey(
                        name: "FK_dish_ingredients_dish_dish_id",
                        column: x => x.dish_id,
                        principalSchema: "cafe",
                        principalTable: "dish",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dish_ingredients_ingredients_ingredient_id",
                        column: x => x.ingredient_id,
                        principalSchema: "cafe",
                        principalTable: "ingredients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "cafe",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fio = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    login = table.Column<string>(type: "character varying(80)", unicode: false, maxLength: 80, nullable: false),
                    password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_role_role_id",
                        column: x => x.role_id,
                        principalSchema: "cafe",
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "menu",
                schema: "cafe",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    table_id = table.Column<int>(type: "integer", nullable: false),
                    status_id = table.Column<int>(type: "integer", nullable: false),
                    opened_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu", x => x.id);
                    table.ForeignKey(
                        name: "FK_menu_status_status_id",
                        column: x => x.status_id,
                        principalSchema: "cafe",
                        principalTable: "status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_menu_tables_table_id",
                        column: x => x.table_id,
                        principalSchema: "cafe",
                        principalTable: "tables",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                schema: "cafe",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    table_id = table.Column<int>(type: "integer", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    total_sum = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    status_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_orders_status_status_id",
                        column: x => x.status_id,
                        principalSchema: "cafe",
                        principalTable: "status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_orders_tables_table_id",
                        column: x => x.table_id,
                        principalSchema: "cafe",
                        principalTable: "tables",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_orders_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "cafe",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "menu_kitchen",
                schema: "cafe",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_id = table.Column<int>(type: "integer", nullable: false),
                    sent_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu_kitchen", x => x.id);
                    table.ForeignKey(
                        name: "FK_menu_kitchen_orders_order_id",
                        column: x => x.order_id,
                        principalSchema: "cafe",
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_items",
                schema: "cafe",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_id = table.Column<int>(type: "integer", nullable: false),
                    dish_id = table.Column<int>(type: "integer", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_items", x => x.id);
                    table.CheckConstraint("CK_order_items_count", "\"count\" > 0");
                    table.CheckConstraint("CK_order_items_price", "price >= 0");
                    table.ForeignKey(
                        name: "FK_order_items_dish_dish_id",
                        column: x => x.dish_id,
                        principalSchema: "cafe",
                        principalTable: "dish",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_order_items_orders_order_id",
                        column: x => x.order_id,
                        principalSchema: "cafe",
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dish_name",
                schema: "cafe",
                table: "dish",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_dish_ingredients_dish_id_ingredient_id",
                schema: "cafe",
                table: "dish_ingredients",
                columns: new[] { "dish_id", "ingredient_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_dish_ingredients_ingredient_id",
                schema: "cafe",
                table: "dish_ingredients",
                column: "ingredient_id");

            migrationBuilder.CreateIndex(
                name: "IX_ingredients_name",
                schema: "cafe",
                table: "ingredients",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_menu_status_id",
                schema: "cafe",
                table: "menu",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_menu_table_id",
                schema: "cafe",
                table: "menu",
                column: "table_id");

            migrationBuilder.CreateIndex(
                name: "IX_menu_kitchen_order_id",
                schema: "cafe",
                table: "menu_kitchen",
                column: "order_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_order_items_dish_id",
                schema: "cafe",
                table: "order_items",
                column: "dish_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_items_order_id_dish_id",
                schema: "cafe",
                table: "order_items",
                columns: new[] { "order_id", "dish_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_status_id",
                schema: "cafe",
                table: "orders",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_table_id",
                schema: "cafe",
                table: "orders",
                column: "table_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_user_id",
                schema: "cafe",
                table: "orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_role_name",
                schema: "cafe",
                table: "role",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_status_name",
                schema: "cafe",
                table: "status",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_login",
                schema: "cafe",
                table: "users",
                column: "login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_role_id",
                schema: "cafe",
                table: "users",
                column: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dish_ingredients",
                schema: "cafe");

            migrationBuilder.DropTable(
                name: "menu",
                schema: "cafe");

            migrationBuilder.DropTable(
                name: "menu_kitchen",
                schema: "cafe");

            migrationBuilder.DropTable(
                name: "order_items",
                schema: "cafe");

            migrationBuilder.DropTable(
                name: "ingredients",
                schema: "cafe");

            migrationBuilder.DropTable(
                name: "dish",
                schema: "cafe");

            migrationBuilder.DropTable(
                name: "orders",
                schema: "cafe");

            migrationBuilder.DropTable(
                name: "status",
                schema: "cafe");

            migrationBuilder.DropTable(
                name: "tables",
                schema: "cafe");

            migrationBuilder.DropTable(
                name: "users",
                schema: "cafe");

            migrationBuilder.DropTable(
                name: "role",
                schema: "cafe");
        }
    }
}
