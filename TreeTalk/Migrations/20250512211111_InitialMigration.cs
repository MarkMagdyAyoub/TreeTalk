using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TreeTalk.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "VARCHAR", maxLength: 60, nullable: true),
                    Birthday = table.Column<DateTime>(type: "DATE", nullable: false),
                    UserImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<char>(type: "CHAR", nullable: false),
                    AboutMe = table.Column<string>(type: "TEXT", nullable: true),
                    IsBanned = table.Column<bool>(type: "BOOLEAN", nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "BOOLEAN", nullable: false, defaultValue: false),
                    ProviderId = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: true),
                    Provider = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "None"),
                    LastLoginAt = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "TIMESTAMP", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "VARCHAR", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Likes = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_User_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PostId = table.Column<int>(type: "integer", nullable: false),
                    ParentId = table.Column<int>(type: "integer", nullable: true),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    Likes = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Depth = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Comment_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_User_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AboutMe", "Birthday", "CreatedAt", "Email", "Gender", "LastLoginAt", "PasswordHash", "ProviderId", "UpdatedAt", "UserImageUrl", "Username" },
                values: new object[,]
                {
                    { 1, "Tech lover and open source contributor.", new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "alice@example.com", 'F', new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi", null, null, "https://example.com/images/alice.jpg", "alice" },
                    { 2, "Full-stack developer and PostgreSQL fan.", new DateTime(1988, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "bob@example.com", 'M', new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi", null, null, "https://example.com/images/bob.jpg", "bob" },
                    { 3, "Database engineer and tech writer.", new DateTime(1995, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "charlie@example.com", 'M', new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi", null, null, "https://example.com/images/charlie.jpg", "charlie" },
                    { 4, "UI/UX designer and frontend developer.", new DateTime(1992, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "dana@example.com", 'F', new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi", null, null, "https://example.com/images/dana.jpg", "dana" },
                    { 5, "Data scientist and ML enthusiast.", new DateTime(1993, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "emily@example.com", 'F', new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi", null, null, "https://example.com/images/emily.jpg", "emily" },
                    { 6, "DevOps engineer and cloud architect.", new DateTime(1985, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "frank@example.com", 'M', new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi", null, null, "https://example.com/images/frank.jpg", "frank" },
                    { 7, "Cybersecurity specialist and bug bounty hunter.", new DateTime(1991, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "grace@example.com", 'F', new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi", null, null, "https://example.com/images/grace.jpg", "grace" },
                    { 8, "Mobile app developer and UX enthusiast.", new DateTime(1994, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "henry@example.com", 'M', new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi", null, null, "https://example.com/images/henry.jpg", "henry" },
                    { 9, "Blockchain developer and cryptocurrency researcher.", new DateTime(1989, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "isabella@example.com", 'F', new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi", null, null, "https://example.com/images/isabella.jpg", "isabella" },
                    { 10, "Game developer and 3D graphics programmer.", new DateTime(1990, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "jack@example.com", 'M', new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi", null, null, "https://example.com/images/jack.jpg", "jack" },
                    { 11, "Technical writer and documentation specialist.", new DateTime(1987, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "kate@example.com", 'F', new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi", null, null, "https://example.com/images/kate.jpg", "kate" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AboutMe", "Birthday", "CreatedAt", "Email", "Gender", "IsBanned", "LastLoginAt", "PasswordHash", "ProviderId", "UpdatedAt", "UserImageUrl", "Username" },
                values: new object[] { 12, "QA engineer and test automation expert.", new DateTime(1996, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "liam@example.com", 'M', true, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi", null, null, "https://example.com/images/liam.jpg", "liam" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AboutMe", "Birthday", "CreatedAt", "Email", "Gender", "LastLoginAt", "PasswordHash", "ProviderId", "UpdatedAt", "UserImageUrl", "Username" },
                values: new object[,]
                {
                    { 13, "Project manager and agile coach.", new DateTime(1993, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "mia@example.com", 'F', new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi", null, null, "https://example.com/images/mia.jpg", "mia" },
                    { 14, "Data engineer and big data specialist.", new DateTime(1991, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "noah@example.com", 'M', new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi", null, null, "https://example.com/images/noah.jpg", "noah" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AboutMe", "Birthday", "CreatedAt", "Email", "Gender", "IsDeleted", "LastLoginAt", "PasswordHash", "ProviderId", "UpdatedAt", "UserImageUrl", "Username" },
                values: new object[] { 15, "UX researcher and accessibility advocate.", new DateTime(1994, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "olivia@example.com", 'F', true, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi", null, null, "https://example.com/images/olivia.jpg", "olivia" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AboutMe", "Birthday", "CreatedAt", "Email", "Gender", "LastLoginAt", "PasswordHash", "ProviderId", "UpdatedAt", "UserImageUrl", "Username" },
                values: new object[,]
                {
                    { 16, "Systems architect and performance tuning specialist.", new DateTime(1988, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "peter@example.com", 'M', new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi", null, null, "https://example.com/images/peter.jpg", "peter" },
                    { 17, "API designer and integration specialist.", new DateTime(1995, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "quinn@example.com", 'F', new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi", null, null, "https://example.com/images/quinn.jpg", "quinn" },
                    { 18, "IoT developer and embedded systems engineer.", new DateTime(1992, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "ryan@example.com", 'M', new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi", null, null, "https://example.com/images/ryan.jpg", "ryan" },
                    { 19, "AR/VR developer and 3D modeling expert.", new DateTime(1990, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "sophia@example.com", 'F', new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi", null, null, "https://example.com/images/sophia.jpg", "sophia" },
                    { 20, "SRE and infrastructure automation specialist.", new DateTime(1989, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "thomas@example.com", 'M', new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi", null, null, "https://example.com/images/thomas.jpg", "thomas" }
                });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "ImageUrl", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, "Open source software has revolutionized the tech world by fostering collaboration, transparency, and innovation. Projects like Linux, Apache, and PostgreSQL have become the backbone of modern technology infrastructure.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/os.jpg", "The Power of Open Source", null },
                    { 2, 3, "PostgreSQL is more than just a relational database. Its robust feature set, extensibility, and standards compliance make it an excellent choice for a wide range of applications, from simple websites to complex data analytics platforms.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/pgsql.jpg", "Why I Love PostgreSQL", null },
                    { 3, 4, "As AI becomes more powerful, we must consider ethical boundaries. The rapid advancement of artificial intelligence technologies raises important questions about privacy, bias, accountability, and the future of work.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/ai.jpg", "AI Ethics in Modern Tech", null },
                    { 4, 5, "Recursion is a powerful technique in programming where a function calls itself. This article explores how recursion works, when to use it, and common pitfalls to avoid.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/recursion.jpg", "Understanding Recursion in Programming", null },
                    { 5, 12, "The COVID-19 pandemic accelerated the adoption of remote work. This article examines the long-term implications for businesses, employees, and office spaces.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/remote-work.jpg", "The Future of Remote Work", null },
                    { 6, 12, "Improve your SQL queries with these advanced techniques. Learn about window functions, CTEs, and performance optimization strategies.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/sql-tips.jpg", "Advanced SQL Tips", null },
                    { 7, 9, "Docker simplifies the process of managing application processes in containers. This guide walks you through the basics of containerization.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/docker.jpg", "Getting Started with Docker", null },
                    { 8, 11, "Effective code reviews improve code quality and foster knowledge sharing within teams. This article covers best practices for giving and receiving code review feedback.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/code-review.jpg", "The Art of Code Review", null },
                    { 9, 10, "This comprehensive comparison of popular JavaScript frameworks examines React, Angular, Vue, Svelte and others across performance, learning curve, and community support metrics.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/js-frameworks.jpg", "JavaScript Frameworks Comparison", null },
                    { 10, 17, "WebAssembly is a binary instruction format that enables high-performance applications on the web. This article introduces the key concepts and use cases for this emerging technology.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/wasm.jpg", "Introduction to WebAssembly", null },
                    { 11, 16, "Microservices have become a popular architectural style for building complex applications. This article explores common patterns, anti-patterns, and implementation strategies.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/microservices.jpg", "Microservices Architecture Patterns", null },
                    { 12, 14, "This accessible introduction to quantum computing covers qubits, superposition, entanglement, and quantum gates. Learn how quantum computers differ from classical computers and their potential applications.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/quantum.jpg", "Quantum Computing Explained", null },
                    { 13, 6, "Implementing DevOps practices can streamline software delivery and improve team collaboration. This article covers CI/CD, infrastructure as code, and monitoring strategies.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/devops.jpg", "DevOps Best Practices", null },
                    { 14, 5, "Getting started with machine learning doesn't have to be intimidating. This guide introduces foundational concepts and tools for beginners wanting to enter the field of AI and ML.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/ml-beginners.jpg", "Machine Learning for Beginners", null },
                    { 15, 13, "Code formatting preferences have sparked debates among developers for decades. This lighthearted article examines the pros and cons of using tabs versus spaces for indentation.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/tabs-spaces.jpg", "Tabs vs. Spaces: The Eternal Debate", null }
                });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "ImageUrl", "Likes", "Title", "UpdatedAt" },
                values: new object[] { 16, 7, "Protecting your digital assets is more important than ever. This comprehensive guide covers the fundamentals of cybersecurity for individuals and small businesses.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/cybersecurity.jpg", 156, "Cybersecurity Essentials", null });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "ImageUrl", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 17, 19, "Speed matters for user experience and SEO. This guide explores techniques for optimizing frontend performance, from code splitting to image optimization.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/frontend-perf.jpg", "Frontend Performance Optimization", new DateTime(2025, 4, 7, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 18, "Documenting architectural decisions is crucial for team alignment and knowledge preservation. This article introduces Architecture Decision Records (ADRs) as a lightweight documentation method.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/adr.jpg", "Software Architecture Decision Records", null },
                    { 19, 2, "Classical design patterns remain relevant in modern JavaScript development. This article examines how patterns like Observer, Factory, and Singleton can be implemented using ES6+ features.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/js-patterns.jpg", "Design Patterns in Modern JavaScript", null },
                    { 20, 13, "Web development continues to evolve at a rapid pace. This article explores emerging trends like Web Components, WebAssembly, Edge Computing, and Progressive Web Apps that are shaping the future.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/future-web.jpg", "The Future of Web Development", null }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Depth", "ParentId", "PostId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, "Great article!", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 1, null },
                    { 5, 4, "More please!", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 1, null },
                    { 6, 3, "Best DB ever!", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 2, null },
                    { 9, 2, "JSONB support is gold.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 2, null },
                    { 10, 4, "Important topic!", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 3, null },
                    { 13, 1, "Need more regulation.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 3, null },
                    { 14, 4, "Let's be careful.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 3, null },
                    { 15, 5, "I love using recursion for tree traversal!", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 4, null }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Depth", "IsDeleted", "ParentId", "PostId", "UpdatedAt" },
                values: new object[] { 22, 5, "Remote work is here to stay!", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, true, null, 5, null });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Depth", "ParentId", "PostId", "UpdatedAt" },
                values: new object[] { 24, 7, "I love working remotely.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 5, null });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Depth", "IsDeleted", "ParentId", "PostId", "UpdatedAt" },
                values: new object[] { 25, 8, "Hybrid models seem best.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, true, null, 5, null });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Depth", "ParentId", "PostId", "UpdatedAt" },
                values: new object[,]
                {
                    { 26, 1, "Great tips despite the author being banned!", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 6, null },
                    { 27, 2, "I use these daily.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 6, null },
                    { 28, 15, "Docker changed my workflow!", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 7, null },
                    { 29, 16, "Containers are the future.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 7, null },
                    { 30, 3, "Code reviews saved our project!", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 8, null },
                    { 33, 5, "I struggle with giving constructive feedback.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 8, null },
                    { 37, 8, "Automated tools can help too.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 8, null },
                    { 39, 1, "React is my favorite for large applications.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 9, null },
                    { 40, 2, "Angular has better built-in features.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 9, null },
                    { 41, 3, "Vue is the most approachable for beginners.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 9, null },
                    { 42, 4, "Svelte is revolutionary with its compile-time approach.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 9, null },
                    { 43, 5, "I prefer vanilla JS whenever possible.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 9, null },
                    { 44, 6, "Framework fatigue is real!", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 9, null },
                    { 45, 7, "Next.js is a game-changer for React projects.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 9, null },
                    { 46, 8, "The virtual DOM concept changed frontend development.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 9, null },
                    { 47, 2, "Service discovery is a challenge with microservices.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 11, null },
                    { 52, 5, "Data consistency across services is tricky.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 11, null },
                    { 57, 9, "When will quantum computers become practical?", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 12, null },
                    { 64, 6, "Automation is the key to successful DevOps.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 13, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, 8, "Don't forget about cultural aspects of DevOps.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 13, null }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Depth", "Likes", "ParentId", "PostId", "UpdatedAt" },
                values: new object[,]
                {
                    { 68, 14, "Python is the best language to start with for ML.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 42, null, 14, null },
                    { 70, 5, "Understanding the math is crucial though.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 15, null, 14, null },
                    { 71, 1, "Any book recommendations for beginners?", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 8, null, 14, null }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Depth", "ParentId", "PostId", "UpdatedAt" },
                values: new object[,]
                {
                    { 73, 1, "Tabs are more accessible and customizable!", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 15, null },
                    { 77, 4, "Spaces are the industry standard.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 15, null },
                    { 82, 7, "Just use both to confuse everyone!", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 15, null }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Depth", "Likes", "ParentId", "PostId", "UpdatedAt" },
                values: new object[,]
                {
                    { 84, 9, "Two-factor authentication is non-negotiable these days.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 45, null, 16, null },
                    { 87, 11, "Regular security audits saved our company.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 39, null, 16, null },
                    { 88, 12, "Password managers are essential.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 51, null, 16, null },
                    { 89, 13, "What about zero-trust architecture?", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 8, null, 16, null }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Depth", "ParentId", "PostId", "UpdatedAt" },
                values: new object[,]
                {
                    { 91, 8, "Thanks for adding the section on Core Web Vitals!", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 17, null },
                    { 93, 4, "The updated examples are much clearer now.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 17, null },
                    { 94, 1, "Could you expand on lazy loading in a future update?", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 17, null },
                    { 95, 16, "We've implemented ADRs with great success.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 18, null },
                    { 100, 1, "How do you handle updating outdated ADRs?", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 18, null },
                    { 103, 10, "I prefer using proxies for the Observer pattern in modern JS.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 19, null },
                    { 106, 3, "Singleton is often overused and creates tight coupling.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 19, null },
                    { 108, 20, "The Factory examples could use more real-world context.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 19, null },
                    { 110, 1, "Web Components will finally solve reusability.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 20, null },
                    { 2, 2, "Totally agree!", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 1, null },
                    { 4, 3, "I learned a lot.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 1, null },
                    { 7, 4, "And so extensible!", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 6, 2, null },
                    { 11, 2, "Couldn't agree more.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 10, 3, null },
                    { 16, 6, "Recursion can be tricky with large datasets though.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 15, 4, null },
                    { 23, 6, "But what about company culture?", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 22, 5, null },
                    { 31, 4, "What process do you follow?", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 30, 8, null },
                    { 34, 6, "Try focusing on the code, not the person.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 33, 8, null },
                    { 38, 9, "Any recommendations?", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 37, 8, null },
                    { 48, 3, "Have you tried Consul or etcd?", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 47, 11, null },
                    { 53, 6, "Saga pattern can help with that.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 52, 11, null },
                    { 54, 7, "Event sourcing is another approach.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 52, 11, null },
                    { 58, 10, "For certain algorithms, they already are.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 57, 12, null },
                    { 65, 7, "Agreed! What tools do you recommend?", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 64, 13, null }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Depth", "Likes", "ParentId", "PostId", "UpdatedAt" },
                values: new object[,]
                {
                    { 69, 3, "Absolutely! Scikit-learn makes it so accessible.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 29, 68, 14, null },
                    { 72, 14, "Hands-On Machine Learning by Aurélien Géron is excellent.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 37, 71, 14, null }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Depth", "ParentId", "PostId", "UpdatedAt" },
                values: new object[,]
                {
                    { 74, 2, "But spaces ensure consistent formatting everywhere.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 73, 15, null },
                    { 78, 5, "Only because of senior developers' preferences.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 77, 15, null },
                    { 83, 8, "That's pure evil.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 82, 15, null }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Depth", "Likes", "ParentId", "PostId", "UpdatedAt" },
                values: new object[,]
                {
                    { 85, 10, "What's your preferred 2FA method?", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 12, 84, 16, null },
                    { 90, 7, "Excellent point! I'll cover that in part 2.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 17, 89, 16, null }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Depth", "ParentId", "PostId", "UpdatedAt" },
                values: new object[,]
                {
                    { 92, 19, "You're welcome! It's become so important for SEO.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 91, 17, null },
                    { 96, 17, "What template do you use?", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 95, 18, null },
                    { 101, 18, "Don't change old ADRs! Create new ones that supersede them.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 100, 18, null },
                    { 104, 2, "Interesting! Can you elaborate on the advantages?", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 103, 19, null },
                    { 107, 4, "True, dependency injection is usually a better approach.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 106, 19, null },
                    { 109, 2, "Thanks for the feedback! I'll update with better examples.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 108, 19, null },
                    { 111, 2, "Custom Elements are already well-supported.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 110, 20, null },
                    { 3, 1, "Thanks Bob!", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 1, null },
                    { 8, 3, "Right!", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, 7, 2, null },
                    { 12, 3, "But we must act fast.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, 11, 3, null },
                    { 17, 7, "That's why you need proper base cases.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, 16, 4, null },
                    { 32, 3, "We use a checklist approach.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, 31, 8, null },
                    { 35, 7, "The sandwich approach works well too.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, 34, 8, null },
                    { 49, 2, "Yes, we use Consul with great results.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, 48, 11, null },
                    { 55, 5, "Can you explain the Saga pattern more?", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, 53, 11, null },
                    { 59, 9, "Like which ones?", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, 58, 12, null },
                    { 66, 6, "Jenkins, Terraform, and Prometheus are my go-to stack.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, 65, 13, new DateTime(2025, 4, 5, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 75, 3, "That's why we have .editorconfig files.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, 74, 15, null },
                    { 79, 6, "And years of practical experience!", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, 78, 15, null }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Depth", "Likes", "ParentId", "PostId", "UpdatedAt" },
                values: new object[] { 86, 9, "Hardware keys for critical accounts, authenticator apps for others.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, 23, 85, 16, null });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Depth", "ParentId", "PostId", "UpdatedAt" },
                values: new object[,]
                {
                    { 97, 16, "We use Michael Nygard's template with some customizations.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, 96, 18, null },
                    { 102, 2, "As @user16 mentioned above, clear references are key.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, 101, 18, null },
                    { 105, 10, "It's more declarative and requires less boilerplate than traditional implementations.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, 104, 19, null },
                    { 112, 3, "Shadow DOM is the game changer here.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, 111, 20, null },
                    { 18, 8, "And be careful about stack overflow.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4, 17, 4, null },
                    { 36, 5, "Thanks for the tips!", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4, 35, 8, null },
                    { 50, 4, "How does it handle network partitions?", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4, 49, 11, null },
                    { 56, 6, "It sequences local transactions with compensating actions.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4, 55, 11, null },
                    { 60, 10, "Shor's algorithm for factoring large numbers.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4, 59, 12, null },
                    { 76, 2, "Not all editors support that though.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4, 75, 15, null },
                    { 80, 5, "Appeal to authority fallacy.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4, 79, 15, null },
                    { 98, 17, "Could you share those customizations?", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4, 97, 18, null }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Depth", "IsDeleted", "ParentId", "PostId", "UpdatedAt" },
                values: new object[] { 113, 4, "But the tooling is still immature compared to React.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 4, true, 112, 20, null });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Depth", "ParentId", "PostId", "UpdatedAt" },
                values: new object[,]
                {
                    { 19, 9, "Tail recursion can help with that.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 5, 18, 4, null },
                    { 51, 2, "It has built-in health checks that help.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 5, 50, 11, null },
                    { 61, 11, "That has implications for cryptography, right?", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 5, 60, 12, null },
                    { 81, 6, "No, it's empirical evidence.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 5, 80, 15, null },
                    { 99, 16, "We added sections for security implications and performance considerations.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 5, 98, 18, null },
                    { 114, 5, "Responding to a deleted comment but still relevant.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 5, 113, 20, null },
                    { 20, 10, "Not all languages optimize for tail recursion though.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 6, 19, 4, null },
                    { 62, 10, "Exactly! Current encryption could be broken.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 6, 61, 12, null },
                    { 115, 6, "The ecosystem is definitely catching up though.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 6, 114, 20, null },
                    { 21, 11, "Good point! Sometimes iteration is clearer anyway.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 7, 20, 4, null },
                    { 63, 9, "So what's the solution?", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 7, 62, 12, null },
                    { 116, 7, "Give it another year and it will be mainstream.", new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 7, 115, 20, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_AuthorId",
                table: "Comment",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ParentId",
                table: "Comment",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostId",
                table: "Comment",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_AuthorId",
                table: "Post",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                table: "User",
                column: "Username",
                unique: true);

            migrationBuilder.Sql(File.ReadAllText("./Migrations/Functions/get_comment_children.sql"));
            migrationBuilder.Sql(File.ReadAllText("./Migrations/Functions/get_comment_tree.sql"));
            migrationBuilder.Sql(File.ReadAllText("./Migrations/Functions/soft_delete_comment_tree.sql"));
            migrationBuilder.Sql(File.ReadAllText("./Migrations/Functions/soft_delete_post_and_tree.sql"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.Sql("DROP FUNCTION IF EXISTS get_comment_children(INT);");
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS get_comment_tree(INT);");
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS soft_delete_comment_tree(INT);");
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS soft_delete_post_and_tree(INT);");
      }
    }
}
