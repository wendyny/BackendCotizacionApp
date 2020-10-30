using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendCotizacionApp.Migrations
{
    public partial class CrearDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Categorias",
                schema: "dbo",
                columns: table => new
                {
                    idCategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreCategoria = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.idCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                schema: "dbo",
                columns: table => new
                {
                    idCliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreCliente = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    telefono = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.idCliente);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                schema: "dbo",
                columns: table => new
                {
                    idUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreUsuario = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    informacion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.idUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Cotizaciones",
                schema: "dbo",
                columns: table => new
                {
                    idCotizacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCliente = table.Column<int>(nullable: false),
                    idUsuario = table.Column<int>(nullable: false),
                    oferta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotizaciones", x => x.idCotizacion);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_Clientes_idCliente",
                        column: x => x.idCliente,
                        principalSchema: "dbo",
                        principalTable: "Clientes",
                        principalColumn: "idCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_Usuarios_idUsuario",
                        column: x => x.idUsuario,
                        principalSchema: "dbo",
                        principalTable: "Usuarios",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                schema: "dbo",
                columns: table => new
                {
                    idProducto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    urlFotoProducto = table.Column<string>(nullable: true),
                    descripcionProducto = table.Column<string>(nullable: true),
                    precio = table.Column<double>(nullable: false),
                    tipo = table.Column<int>(nullable: false),
                    idUsuario = table.Column<int>(nullable: false),
                    idCategoria = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.idProducto);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_idCategoria",
                        column: x => x.idCategoria,
                        principalSchema: "dbo",
                        principalTable: "Categorias",
                        principalColumn: "idCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Usuarios_idUsuario",
                        column: x => x.idUsuario,
                        principalSchema: "dbo",
                        principalTable: "Usuarios",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallesCotizacion",
                schema: "dbo",
                columns: table => new
                {
                    idDetalle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idProducto = table.Column<int>(nullable: false),
                    cantidadProducto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesCotizacion", x => x.idDetalle);
                    table.ForeignKey(
                        name: "FK_DetallesCotizacion_Productos_idProducto",
                        column: x => x.idProducto,
                        principalSchema: "dbo",
                        principalTable: "Productos",
                        principalColumn: "idProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_idCliente",
                schema: "dbo",
                table: "Cotizaciones",
                column: "idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_idUsuario",
                schema: "dbo",
                table: "Cotizaciones",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesCotizacion_idProducto",
                schema: "dbo",
                table: "DetallesCotizacion",
                column: "idProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_idCategoria",
                schema: "dbo",
                table: "Productos",
                column: "idCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_idUsuario",
                schema: "dbo",
                table: "Productos",
                column: "idUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cotizaciones",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DetallesCotizacion",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Clientes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Productos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Categorias",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Usuarios",
                schema: "dbo");
        }
    }
}
