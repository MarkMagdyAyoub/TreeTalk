using System;
using System.Collections.Generic;
using TreeTalk.Model.Entities;
using TreeTalkModel.Model.Entities;

namespace TreeTalkModel.Model.Data.Config
{
  public static class SampleDataConstants
  {
    // Use a fixed date for consistent model snapshots (important for migrations)
    public static readonly DateTime FixedDate = new DateTime(2025, 4, 5, 12, 0, 0);
  }

  public class Repository
  {
    /// <summary>
    /// Loads sample users with fixed timestamps to avoid migration issues.
    /// </summary>
    public static List<User> LoadUsers()
    {
      return new List<User>
            {
                // User 1: Alice
                new User
                {
                    Id = 1,
                    Username = "alice",
                    Email = "alice@example.com",
                    PasswordHash = "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi",
                    Birthday = new DateTime(1990, 05, 15),
                    UserImageUrl = "https://example.com/images/alice.jpg",
                    Gender = 'F',
                    AboutMe = "Tech lover and open source contributor.",
                    IsBanned = false,
                    IsDeleted = false,
                    LastLoginAt = SampleDataConstants.FixedDate,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null
                },
                // User 2: Bob
                new User
                {
                    Id = 2,
                    Username = "bob",
                    Email = "bob@example.com",
                    PasswordHash = "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi",
                    Birthday = new DateTime(1988, 02, 10),
                    UserImageUrl = "https://example.com/images/bob.jpg",
                    Gender = 'M',
                    AboutMe = "Full-stack developer and PostgreSQL fan.",
                    IsBanned = false,
                    IsDeleted = false,
                    LastLoginAt = SampleDataConstants.FixedDate,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null
                },
                // User 3: Charlie
                new User
                {
                    Id = 3,
                    Username = "charlie",
                    Email = "charlie@example.com",
                    PasswordHash = "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi",
                    Birthday = new DateTime(1995, 11, 20),
                    UserImageUrl = "https://example.com/images/charlie.jpg",
                    Gender = 'M',
                    AboutMe = "Database engineer and tech writer.",
                    IsBanned = false,
                    IsDeleted = false,
                    LastLoginAt = SampleDataConstants.FixedDate,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null
                },
                // User 4: Dana
                new User
                {
                    Id = 4,
                    Username = "dana",
                    Email = "dana@example.com",
                    PasswordHash = "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi",
                    Birthday = new DateTime(1992, 08, 25),
                    UserImageUrl = "https://example.com/images/dana.jpg",
                    Gender = 'F',
                    AboutMe = "UI/UX designer and frontend developer.",
                    IsBanned = false,
                    IsDeleted = false,
                    LastLoginAt = SampleDataConstants.FixedDate,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null
                },
                // User 5: Emily
                new User
                {
                    Id = 5,
                    Username = "emily",
                    Email = "emily@example.com",
                    PasswordHash = "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi",
                    Birthday = new DateTime(1993, 04, 12),
                    UserImageUrl = "https://example.com/images/emily.jpg",
                    Gender = 'F',
                    AboutMe = "Data scientist and ML enthusiast.",
                    IsBanned = false,
                    IsDeleted = false,
                    LastLoginAt = SampleDataConstants.FixedDate,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null
                },
                // User 6: Frank
                new User
                {
                    Id = 6,
                    Username = "frank",
                    Email = "frank@example.com",
                    PasswordHash = "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi",
                    Birthday = new DateTime(1985, 09, 30),
                    UserImageUrl = "https://example.com/images/frank.jpg",
                    Gender = 'M',
                    AboutMe = "DevOps engineer and cloud architect.",
                    IsBanned = false,
                    IsDeleted = false,
                    LastLoginAt = SampleDataConstants.FixedDate,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null
                },
                // User 7: Grace
                new User
                {
                    Id = 7,
                    Username = "grace",
                    Email = "grace@example.com",
                    PasswordHash = "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi",
                    Birthday = new DateTime(1991, 12, 05),
                    UserImageUrl = "https://example.com/images/grace.jpg",
                    Gender = 'F',
                    AboutMe = "Cybersecurity specialist and bug bounty hunter.",
                    IsBanned = false,
                    IsDeleted = false,
                    LastLoginAt = SampleDataConstants.FixedDate,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null
                },
                // User 8: Henry
                new User
                {
                    Id = 8,
                    Username = "henry",
                    Email = "henry@example.com",
                    PasswordHash = "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi",
                    Birthday = new DateTime(1994, 06, 18),
                    UserImageUrl = "https://example.com/images/henry.jpg",
                    Gender = 'M',
                    AboutMe = "Mobile app developer and UX enthusiast.",
                    IsBanned = false,
                    IsDeleted = false,
                    LastLoginAt = SampleDataConstants.FixedDate,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null
                },
                // User 9: Isabella
                new User
                {
                    Id = 9,
                    Username = "isabella",
                    Email = "isabella@example.com",
                    PasswordHash = "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi",
                    Birthday = new DateTime(1989, 03, 22),
                    UserImageUrl = "https://example.com/images/isabella.jpg",
                    Gender = 'F',
                    AboutMe = "Blockchain developer and cryptocurrency researcher.",
                    IsBanned = false,
                    IsDeleted = false,
                    LastLoginAt = SampleDataConstants.FixedDate,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null
                },
                // User 10: Jack
                new User
                {
                    Id = 10,
                    Username = "jack",
                    Email = "jack@example.com",
                    PasswordHash = "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi",
                    Birthday = new DateTime(1990, 07, 14),
                    UserImageUrl = "https://example.com/images/jack.jpg",
                    Gender = 'M',
                    AboutMe = "Game developer and 3D graphics programmer.",
                    IsBanned = false,
                    IsDeleted = false,
                    LastLoginAt = SampleDataConstants.FixedDate,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null
                },
                // User 11: Kate
                new User
                {
                    Id = 11,
                    Username = "kate",
                    Email = "kate@example.com",
                    PasswordHash = "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi",
                    Birthday = new DateTime(1987, 01, 29),
                    UserImageUrl = "https://example.com/images/kate.jpg",
                    Gender = 'F',
                    AboutMe = "Technical writer and documentation specialist.",
                    IsBanned = false,
                    IsDeleted = false,
                    LastLoginAt = SampleDataConstants.FixedDate,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null
                },
                // User 12: Liam (Banned)
                new User
                {
                    Id = 12,
                    Username = "liam",
                    Email = "liam@example.com",
                    PasswordHash = "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi",
                    Birthday = new DateTime(1996, 10, 03),
                    UserImageUrl = "https://example.com/images/liam.jpg",
                    Gender = 'M',
                    AboutMe = "QA engineer and test automation expert.",
                    IsBanned = true, // Banned user for testing
                    IsDeleted = false,
                    LastLoginAt = SampleDataConstants.FixedDate,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null
                },
                // User 13: Mia
                new User
                {
                    Id = 13,
                    Username = "mia",
                    Email = "mia@example.com",
                    PasswordHash = "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi",
                    Birthday = new DateTime(1993, 08, 08),
                    UserImageUrl = "https://example.com/images/mia.jpg",
                    Gender = 'F',
                    AboutMe = "Project manager and agile coach.",
                    IsBanned = false,
                    IsDeleted = false,
                    LastLoginAt = SampleDataConstants.FixedDate,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null
                },
                // User 14: Noah
                new User
                {
                    Id = 14,
                    Username = "noah",
                    Email = "noah@example.com",
                    PasswordHash = "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi",
                    Birthday = new DateTime(1991, 05, 27),
                    UserImageUrl = "https://example.com/images/noah.jpg",
                    Gender = 'M',
                    AboutMe = "Data engineer and big data specialist.",
                    IsBanned = false,
                    IsDeleted = false,
                    LastLoginAt = SampleDataConstants.FixedDate,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null
                },
                // User 15: Olivia (Deleted)
                new User
                {
                    Id = 15,
                    Username = "olivia",
                    Email = "olivia@example.com",
                    PasswordHash = "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi",
                    Birthday = new DateTime(1994, 12, 15),
                    UserImageUrl = "https://example.com/images/olivia.jpg",
                    Gender = 'F',
                    AboutMe = "UX researcher and accessibility advocate.",
                    IsBanned = false,
                    IsDeleted = true, // Deleted user for testing
                    LastLoginAt = SampleDataConstants.FixedDate,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null
                },
                // User 16: Peter
                new User
                {
                    Id = 16,
                    Username = "peter",
                    Email = "peter@example.com",
                    PasswordHash = "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi",
                    Birthday = new DateTime(1988, 11, 11),
                    UserImageUrl = "https://example.com/images/peter.jpg",
                    Gender = 'M',
                    AboutMe = "Systems architect and performance tuning specialist.",
                    IsBanned = false,
                    IsDeleted = false,
                    LastLoginAt = SampleDataConstants.FixedDate,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null
                },
                // User 17: Quinn
                new User
                {
                    Id = 17,
                    Username = "quinn",
                    Email = "quinn@example.com",
                    PasswordHash = "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi",
                    Birthday = new DateTime(1995, 02, 23),
                    UserImageUrl = "https://example.com/images/quinn.jpg",
                    Gender = 'F',
                    AboutMe = "API designer and integration specialist.",
                    IsBanned = false,
                    IsDeleted = false,
                    LastLoginAt = SampleDataConstants.FixedDate,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null
                },
                // User 18: Ryan
                new User
                {
                    Id = 18,
                    Username = "ryan",
                    Email = "ryan@example.com",
                    PasswordHash = "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi",
                    Birthday = new DateTime(1992, 07, 19),
                    UserImageUrl = "https://example.com/images/ryan.jpg",
                    Gender = 'M',
                    AboutMe = "IoT developer and embedded systems engineer.",
                    IsBanned = false,
                    IsDeleted = false,
                    LastLoginAt = SampleDataConstants.FixedDate,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null
                },
                // User 19: Sophia
                new User
                {
                    Id = 19,
                    Username = "sophia",
                    Email = "sophia@example.com",
                    PasswordHash = "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi",
                    Birthday = new DateTime(1990, 09, 04),
                    UserImageUrl = "https://example.com/images/sophia.jpg",
                    Gender = 'F',
                    AboutMe = "AR/VR developer and 3D modeling expert.",
                    IsBanned = false,
                    IsDeleted = false,
                    LastLoginAt = SampleDataConstants.FixedDate,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null
                },
                // User 20: Thomas
                new User
                {
                    Id = 20,
                    Username = "thomas",
                    Email = "thomas@example.com",
                    PasswordHash = "$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi",
                    Birthday = new DateTime(1989, 04, 01),
                    UserImageUrl = "https://example.com/images/thomas.jpg",
                    Gender = 'M',
                    AboutMe = "SRE and infrastructure automation specialist.",
                    IsBanned = false,
                    IsDeleted = false,
                    LastLoginAt = SampleDataConstants.FixedDate,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null
                }
            };
    }

    /// <summary>
    /// Loads sample posts with fixed timestamps.
    /// </summary>
    public static List<Post> LoadPosts()
    {
      return new List<Post>
            {
                // Post 1
                new Post
                {
                    Id = 1,
                    Title = "The Power of Open Source",
                    Content = "Open source software has revolutionized the tech world by fostering collaboration, transparency, and innovation. Projects like Linux, Apache, and PostgreSQL have become the backbone of modern technology infrastructure.",
                    ImageUrl = "https://example.com/os.jpg",
                    Likes = 0,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null,
                    IsDeleted = false,
                    AuthorId = 1
                },
                // Post 2
                new Post
                {
                    Id = 2,
                    Title = "Why I Love PostgreSQL",
                    Content = "PostgreSQL is more than just a relational database. Its robust feature set, extensibility, and standards compliance make it an excellent choice for a wide range of applications, from simple websites to complex data analytics platforms.",
                    ImageUrl = "https://example.com/pgsql.jpg",
                    Likes = 0,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null,
                    IsDeleted = false,
                    AuthorId = 3
                },
                // Post 3
                new Post
                {
                    Id = 3,
                    Title = "AI Ethics in Modern Tech",
                    Content = "As AI becomes more powerful, we must consider ethical boundaries. The rapid advancement of artificial intelligence technologies raises important questions about privacy, bias, accountability, and the future of work.",
                    ImageUrl = "https://example.com/ai.jpg",
                    Likes = 0,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null,
                    IsDeleted = false,
                    AuthorId = 4
                },
                // Post 4
                new Post
                {
                    Id = 4,
                    Title = "Understanding Recursion in Programming",
                    Content = "Recursion is a powerful technique in programming where a function calls itself. This article explores how recursion works, when to use it, and common pitfalls to avoid.",
                    ImageUrl = "https://example.com/recursion.jpg",
                    Likes = 0,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null,
                    IsDeleted = false,
                    AuthorId = 5
                },
                // Post 5
                new Post
                {
                    Id = 5,
                    Title = "The Future of Remote Work",
                    Content = "The COVID-19 pandemic accelerated the adoption of remote work. This article examines the long-term implications for businesses, employees, and office spaces.",
                    ImageUrl = "https://example.com/remote-work.jpg",
                    Likes = 0,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null,
                    IsDeleted = false,
                    AuthorId = 12 // Liam (banned)
                },
                // Post 6
                new Post
                {
                    Id = 6,
                    Title = "Advanced SQL Tips",
                    Content = "Improve your SQL queries with these advanced techniques. Learn about window functions, CTEs, and performance optimization strategies.",
                    ImageUrl = "https://example.com/sql-tips.jpg",
                    Likes = 0,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null,
                    IsDeleted = false,
                    AuthorId = 12 // Liam (banned)
                },
                // Post 7
                new Post
                {
                    Id = 7,
                    Title = "Getting Started with Docker",
                    Content = "Docker simplifies the process of managing application processes in containers. This guide walks you through the basics of containerization.",
                    ImageUrl = "https://example.com/docker.jpg",
                    Likes = 0,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null,
                    IsDeleted = false,
                    AuthorId = 9
                },
                // Post 8
                new Post
                {
                    Id = 8,
                    Title = "The Art of Code Review",
                    Content = "Effective code reviews improve code quality and foster knowledge sharing within teams. This article covers best practices for giving and receiving code review feedback.",
                    ImageUrl = "https://example.com/code-review.jpg",
                    Likes = 0,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null,
                    IsDeleted = false,
                    AuthorId = 11
                },
                // Post 9
                new Post
                {
                    Id = 9,
                    Title = "JavaScript Frameworks Comparison",
                    Content = "This comprehensive comparison of popular JavaScript frameworks examines React, Angular, Vue, Svelte and others across performance, learning curve, and community support metrics.",
                    ImageUrl = "https://example.com/js-frameworks.jpg",
                    Likes = 0,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null,
                    IsDeleted = false,
                    AuthorId = 10
                },
                // Post 10
                new Post
                {
                    Id = 10,
                    Title = "Introduction to WebAssembly",
                    Content = "WebAssembly is a binary instruction format that enables high-performance applications on the web. This article introduces the key concepts and use cases for this emerging technology.",
                    ImageUrl = "https://example.com/wasm.jpg",
                    Likes = 0,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null,
                    IsDeleted = false,
                    AuthorId = 17
                },
                // Post 11
                new Post
                {
                    Id = 11,
                    Title = "Microservices Architecture Patterns",
                    Content = "Microservices have become a popular architectural style for building complex applications. This article explores common patterns, anti-patterns, and implementation strategies.",
                    ImageUrl = "https://example.com/microservices.jpg",
                    Likes = 0,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null,
                    IsDeleted = false,
                    AuthorId = 16
                },
                // Post 12
                new Post
                {
                    Id = 12,
                    Title = "Quantum Computing Explained",
                    Content = "This accessible introduction to quantum computing covers qubits, superposition, entanglement, and quantum gates. Learn how quantum computers differ from classical computers and their potential applications.",
                    ImageUrl = "https://example.com/quantum.jpg",
                    Likes = 0,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null,
                    IsDeleted = false,
                    AuthorId = 14
                },
                // Post 13
                new Post
                {
                    Id = 13,
                    Title = "DevOps Best Practices",
                    Content = "Implementing DevOps practices can streamline software delivery and improve team collaboration. This article covers CI/CD, infrastructure as code, and monitoring strategies.",
                    ImageUrl = "https://example.com/devops.jpg",
                    Likes = 0,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null, // Will be updated by comments later
                    IsDeleted = false,
                    AuthorId = 6
                },
                // Post 14
                new Post
                {
                    Id = 14,
                    Title = "Machine Learning for Beginners",
                    Content = "Getting started with machine learning doesn't have to be intimidating. This guide introduces foundational concepts and tools for beginners wanting to enter the field of AI and ML.",
                    ImageUrl = "https://example.com/ml-beginners.jpg",
                    Likes = 0,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null,
                    IsDeleted = false,
                    AuthorId = 5
                },
                // Post 15
                new Post
                {
                    Id = 15,
                    Title = "Tabs vs. Spaces: The Eternal Debate",
                    Content = "Code formatting preferences have sparked debates among developers for decades. This lighthearted article examines the pros and cons of using tabs versus spaces for indentation.",
                    ImageUrl = "https://example.com/tabs-spaces.jpg",
                    Likes = 0,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null,
                    IsDeleted = false,
                    AuthorId = 13
                },
                // Post 16
                new Post
                {
                    Id = 16,
                    Title = "Cybersecurity Essentials",
                    Content = "Protecting your digital assets is more important than ever. This comprehensive guide covers the fundamentals of cybersecurity for individuals and small businesses.",
                    ImageUrl = "https://example.com/cybersecurity.jpg",
                    Likes = 156,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null,
                    IsDeleted = false,
                    AuthorId = 7
                },
                // Post 17
                new Post
                {
                    Id = 17,
                    Title = "Frontend Performance Optimization",
                    Content = "Speed matters for user experience and SEO. This guide explores techniques for optimizing frontend performance, from code splitting to image optimization.",
                    ImageUrl = "https://example.com/frontend-perf.jpg",
                    Likes = 0,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = SampleDataConstants.FixedDate.AddDays(2), // NOW() + INTERVAL '2 days'
                    IsDeleted = false,
                    AuthorId = 19
                },
                // Post 18
                new Post
                {
                    Id = 18,
                    Title = "Software Architecture Decision Records",
                    Content = "Documenting architectural decisions is crucial for team alignment and knowledge preservation. This article introduces Architecture Decision Records (ADRs) as a lightweight documentation method.",
                    ImageUrl = "https://example.com/adr.jpg",
                    Likes = 0,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null,
                    IsDeleted = false,
                    AuthorId = 18
                },
                // Post 19
                new Post
                {
                    Id = 19,
                    Title = "Design Patterns in Modern JavaScript",
                    Content = "Classical design patterns remain relevant in modern JavaScript development. This article examines how patterns like Observer, Factory, and Singleton can be implemented using ES6+ features.",
                    ImageUrl = "https://example.com/js-patterns.jpg",
                    Likes = 0,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null,
                    IsDeleted = false,
                    AuthorId = 2
                },
                // Post 20
                new Post
                {
                    Id = 20,
                    Title = "The Future of Web Development",
                    Content = "Web development continues to evolve at a rapid pace. This article explores emerging trends like Web Components, WebAssembly, Edge Computing, and Progressive Web Apps that are shaping the future.",
                    ImageUrl = "https://example.com/future-web.jpg",
                    Likes = 0,
                    CreatedAt = SampleDataConstants.FixedDate,
                    UpdatedAt = null,
                    IsDeleted = false,
                    AuthorId = 13
                }
            };
    }

    /// <summary>
    /// Loads sample comments with fixed timestamps.
    /// </summary>
    public static List<Comment> LoadComments()
    {
      return new List<Comment>
            {
                // SCENARIO 1: Basic comment tree
                new Comment { Id = 1, PostId = 1, AuthorId = 1, ParentId = null, Content = "Great article!", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 2, PostId = 1, AuthorId = 2, ParentId = 1, Content = "Totally agree!", IsDeleted = false, Depth = 2, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 3, PostId = 1, AuthorId = 1, ParentId = 2, Content = "Thanks Bob!", IsDeleted = false, Depth = 3, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 4, PostId = 1, AuthorId = 3, ParentId = 1, Content = "I learned a lot.", IsDeleted = false, Depth = 2, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 5, PostId = 1, AuthorId = 4, ParentId = null, Content = "More please!", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },

                // SCENARIO 2: Medium-depth comment tree
                new Comment { Id = 6, PostId = 2, AuthorId = 3, ParentId = null, Content = "Best DB ever!", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 7, PostId = 2, AuthorId = 4, ParentId = 6, Content = "And so extensible!", IsDeleted = false, Depth = 2, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 8, PostId = 2, AuthorId = 3, ParentId = 7, Content = "Right!", IsDeleted = false, Depth = 3, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 9, PostId = 2, AuthorId = 2, ParentId = null, Content = "JSONB support is gold.", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },

                // SCENARIO 3: Wide comment tree with multiple branches
                new Comment { Id = 10, PostId = 3, AuthorId = 4, ParentId = null, Content = "Important topic!", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 11, PostId = 3, AuthorId = 2, ParentId = 10, Content = "Couldn't agree more.", IsDeleted = false, Depth = 2, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 12, PostId = 3, AuthorId = 3, ParentId = 11, Content = "But we must act fast.", IsDeleted = false, Depth = 3, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 13, PostId = 3, AuthorId = 1, ParentId = null, Content = "Need more regulation.", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 14, PostId = 3, AuthorId = 4, ParentId = null, Content = "Let's be careful.", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },

                // SCENARIO 4: Maximum depth comment tree (testing depth constraint)
                new Comment { Id = 15, PostId = 4, AuthorId = 5, ParentId = null, Content = "I love using recursion for tree traversal!", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 16, PostId = 4, AuthorId = 6, ParentId = 15, Content = "Recursion can be tricky with large datasets though.", IsDeleted = false, Depth = 2, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 17, PostId = 4, AuthorId = 7, ParentId = 16, Content = "That's why you need proper base cases.", IsDeleted = false, Depth = 3, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 18, PostId = 4, AuthorId = 8, ParentId = 17, Content = "And be careful about stack overflow.", IsDeleted = false, Depth = 4, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 19, PostId = 4, AuthorId = 9, ParentId = 18, Content = "Tail recursion can help with that.", IsDeleted = false, Depth = 5, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 20, PostId = 4, AuthorId = 10, ParentId = 19, Content = "Not all languages optimize for tail recursion though.", IsDeleted = false, Depth = 6, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 21, PostId = 4, AuthorId = 11, ParentId = 20, Content = "Good point! Sometimes iteration is clearer anyway.", IsDeleted = false, Depth = 7, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },

                // SCENARIO 5: Post with deleted comments
                new Comment { Id = 22, PostId = 5, AuthorId = 5, ParentId = null, Content = "Remote work is here to stay!", IsDeleted = true, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null }, // Deleted comment
                new Comment { Id = 23, PostId = 5, AuthorId = 6, ParentId = 22, Content = "But what about company culture?", IsDeleted = false, Depth = 2, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null }, // Child of deleted comment
                new Comment { Id = 24, PostId = 5, AuthorId = 7, ParentId = null, Content = "I love working remotely.", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 25, PostId = 5, AuthorId = 8, ParentId = null, Content = "Hybrid models seem best.", IsDeleted = true, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null }, // Another deleted comment

                // SCENARIO 6: Post by banned user with comments
                new Comment { Id = 26, PostId = 6, AuthorId = 1, ParentId = null, Content = "Great tips despite the author being banned!", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 27, PostId = 6, AuthorId = 2, ParentId = null, Content = "I use these daily.", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },

                // SCENARIO 7: Post with comment from deleted user
                new Comment { Id = 28, PostId = 7, AuthorId = 15, ParentId = null, Content = "Docker changed my workflow!", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null }, // Comment from deleted user (Olivia)
                new Comment { Id = 29, PostId = 7, AuthorId = 16, ParentId = null, Content = "Containers are the future.", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },

                // SCENARIO 8: Deep and wide comment tree
                // Branch 1
                new Comment { Id = 30, PostId = 8, AuthorId = 3, ParentId = null, Content = "Code reviews saved our project!", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 31, PostId = 8, AuthorId = 4, ParentId = 30, Content = "What process do you follow?", IsDeleted = false, Depth = 2, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 32, PostId = 8, AuthorId = 3, ParentId = 31, Content = "We use a checklist approach.", IsDeleted = false, Depth = 3, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                // Branch 2
                new Comment { Id = 33, PostId = 8, AuthorId = 5, ParentId = null, Content = "I struggle with giving constructive feedback.", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 34, PostId = 8, AuthorId = 6, ParentId = 33, Content = "Try focusing on the code, not the person.", IsDeleted = false, Depth = 2, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 35, PostId = 8, AuthorId = 7, ParentId = 34, Content = "The sandwich approach works well too.", IsDeleted = false, Depth = 3, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 36, PostId = 8, AuthorId = 5, ParentId = 35, Content = "Thanks for the tips!", IsDeleted = false, Depth = 4, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                // Branch 3
                new Comment { Id = 37, PostId = 8, AuthorId = 8, ParentId = null, Content = "Automated tools can help too.", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 38, PostId = 8, AuthorId = 9, ParentId = 37, Content = "Any recommendations?", IsDeleted = false, Depth = 2, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },

                // SCENARIO 9: Post with high engagement (many top-level comments)
                new Comment { Id = 39, PostId = 9, AuthorId = 1, ParentId = null, Content = "React is my favorite for large applications.", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 40, PostId = 9, AuthorId = 2, ParentId = null, Content = "Angular has better built-in features.", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 41, PostId = 9, AuthorId = 3, ParentId = null, Content = "Vue is the most approachable for beginners.", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 42, PostId = 9, AuthorId = 4, ParentId = null, Content = "Svelte is revolutionary with its compile-time approach.", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 43, PostId = 9, AuthorId = 5, ParentId = null, Content = "I prefer vanilla JS whenever possible.", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 44, PostId = 9, AuthorId = 6, ParentId = null, Content = "Framework fatigue is real!", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 45, PostId = 9, AuthorId = 7, ParentId = null, Content = "Next.js is a game-changer for React projects.", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 46, PostId = 9, AuthorId = 8, ParentId = null, Content = "The virtual DOM concept changed frontend development.", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },

                // SCENARIO 10: Post with no comments (no entries here)

                // SCENARIO 11: Post with complex reply structure
                // Main thread 1
                new Comment { Id = 47, PostId = 11, AuthorId = 2, ParentId = null, Content = "Service discovery is a challenge with microservices.", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 48, PostId = 11, AuthorId = 3, ParentId = 47, Content = "Have you tried Consul or etcd?", IsDeleted = false, Depth = 2, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 49, PostId = 11, AuthorId = 2, ParentId = 48, Content = "Yes, we use Consul with great results.", IsDeleted = false, Depth = 3, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 50, PostId = 11, AuthorId = 4, ParentId = 49, Content = "How does it handle network partitions?", IsDeleted = false, Depth = 4, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 51, PostId = 11, AuthorId = 2, ParentId = 50, Content = "It has built-in health checks that help.", IsDeleted = false, Depth = 5, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                // Main thread 2
                new Comment { Id = 52, PostId = 11, AuthorId = 5, ParentId = null, Content = "Data consistency across services is tricky.", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 53, PostId = 11, AuthorId = 6, ParentId = 52, Content = "Saga pattern can help with that.", IsDeleted = false, Depth = 2, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 54, PostId = 11, AuthorId = 7, ParentId = 52, Content = "Event sourcing is another approach.", IsDeleted = false, Depth = 2, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 55, PostId = 11, AuthorId = 5, ParentId = 53, Content = "Can you explain the Saga pattern more?", IsDeleted = false, Depth = 3, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 56, PostId = 11, AuthorId = 6, ParentId = 55, Content = "It sequences local transactions with compensating actions.", IsDeleted = false, Depth = 4, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },

                // SCENARIO 12: Post with long discussion chain
                new Comment { Id = 57, PostId = 12, AuthorId = 9, ParentId = null, Content = "When will quantum computers become practical?", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 58, PostId = 12, AuthorId = 10, ParentId = 57, Content = "For certain algorithms, they already are.", IsDeleted = false, Depth = 2, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 59, PostId = 12, AuthorId = 9, ParentId = 58, Content = "Like which ones?", IsDeleted = false, Depth = 3, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 60, PostId = 12, AuthorId = 10, ParentId = 59, Content = "Shor's algorithm for factoring large numbers.", IsDeleted = false, Depth = 4, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 61, PostId = 12, AuthorId = 11, ParentId = 60, Content = "That has implications for cryptography, right?", IsDeleted = false, Depth = 5, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 62, PostId = 12, AuthorId = 10, ParentId = 61, Content = "Exactly! Current encryption could be broken.", IsDeleted = false, Depth = 6, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 63, PostId = 12, AuthorId = 9, ParentId = 62, Content = "So what's the solution?", IsDeleted = false, Depth = 7, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null }, // Max depth

                // SCENARIO 13: Post with edited comments (using UpdatedAt)
                new Comment { Id = 64, PostId = 13, AuthorId = 6, ParentId = null, Content = "Automation is the key to successful DevOps.", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = SampleDataConstants.FixedDate },
                new Comment { Id = 65, PostId = 13, AuthorId = 7, ParentId = 64, Content = "Agreed! What tools do you recommend?", IsDeleted = false, Depth = 2, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 66, PostId = 13, AuthorId = 6, ParentId = 65, Content = "Jenkins, Terraform, and Prometheus are my go-to stack.", IsDeleted = false, Depth = 3, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = SampleDataConstants.FixedDate.AddHours(1) },
                new Comment { Id = 67, PostId = 13, AuthorId = 8, ParentId = null, Content = "Don't forget about cultural aspects of DevOps.", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },

                // SCENARIO 14: Post with highly liked comments
                new Comment { Id = 68, PostId = 14, AuthorId = 14, ParentId = null, Content = "Python is the best language to start with for ML.", IsDeleted = false, Depth = 1, Likes = 42, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 69, PostId = 14, AuthorId = 3, ParentId = 68, Content = "Absolutely! Scikit-learn makes it so accessible.", IsDeleted = false, Depth = 2, Likes = 29, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 70, PostId = 14, AuthorId = 5, ParentId = null, Content = "Understanding the math is crucial though.", IsDeleted = false, Depth = 1, Likes = 15, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 71, PostId = 14, AuthorId = 1, ParentId = null, Content = "Any book recommendations for beginners?", IsDeleted = false, Depth = 1, Likes = 8, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 72, PostId = 14, AuthorId = 14, ParentId = 71, Content = "Hands-On Machine Learning by Aurélien Géron is excellent.", IsDeleted = false, Depth = 2, Likes = 37, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },

                // SCENARIO 15: Post with controversial discussion (replies to replies)
                new Comment { Id = 73, PostId = 15, AuthorId = 1, ParentId = null, Content = "Tabs are more accessible and customizable!", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 74, PostId = 15, AuthorId = 2, ParentId = 73, Content = "But spaces ensure consistent formatting everywhere.", IsDeleted = false, Depth = 2, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 75, PostId = 15, AuthorId = 3, ParentId = 74, Content = "That's why we have .editorconfig files.", IsDeleted = false, Depth = 3, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 76, PostId = 15, AuthorId = 2, ParentId = 75, Content = "Not all editors support that though.", IsDeleted = false, Depth = 4, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 77, PostId = 15, AuthorId = 4, ParentId = null, Content = "Spaces are the industry standard.", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 78, PostId = 15, AuthorId = 5, ParentId = 77, Content = "Only because of senior developers' preferences.", IsDeleted = false, Depth = 2, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 79, PostId = 15, AuthorId = 6, ParentId = 78, Content = "And years of practical experience!", IsDeleted = false, Depth = 3, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 80, PostId = 15, AuthorId = 5, ParentId = 79, Content = "Appeal to authority fallacy.", IsDeleted = false, Depth = 4, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 81, PostId = 15, AuthorId = 6, ParentId = 80, Content = "No, it's empirical evidence.", IsDeleted = false, Depth = 5, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 82, PostId = 15, AuthorId = 7, ParentId = null, Content = "Just use both to confuse everyone!", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 83, PostId = 15, AuthorId = 8, ParentId = 82, Content = "That's pure evil.", IsDeleted = false, Depth = 2, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },

                // SCENARIO 16: Post with likes and many comments
                new Comment { Id = 84, PostId = 16, AuthorId = 9, ParentId = null, Content = "Two-factor authentication is non-negotiable these days.", IsDeleted = false, Depth = 1, Likes = 45, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 85, PostId = 16, AuthorId = 10, ParentId = 84, Content = "What's your preferred 2FA method?", IsDeleted = false, Depth = 2, Likes = 12, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 86, PostId = 16, AuthorId = 9, ParentId = 85, Content = "Hardware keys for critical accounts, authenticator apps for others.", IsDeleted = false, Depth = 3, Likes = 23, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 87, PostId = 16, AuthorId = 11, ParentId = null, Content = "Regular security audits saved our company.", IsDeleted = false, Depth = 1, Likes = 39, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 88, PostId = 16, AuthorId = 12, ParentId = null, Content = "Password managers are essential.", IsDeleted = false, Depth = 1, Likes = 51, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 89, PostId = 16, AuthorId = 13, ParentId = null, Content = "What about zero-trust architecture?", IsDeleted = false, Depth = 1, Likes = 8, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 90, PostId = 16, AuthorId = 7, ParentId = 89, Content = "Excellent point! I'll cover that in part 2.", IsDeleted = false, Depth = 2, Likes = 17, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },

                // SCENARIO 17: Post with updated content (edited post)
                new Comment { Id = 91, PostId = 17, AuthorId = 8, ParentId = null, Content = "Thanks for adding the section on Core Web Vitals!", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 92, PostId = 17, AuthorId = 19, ParentId = 91, Content = "You're welcome! It's become so important for SEO.", IsDeleted = false, Depth = 2, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 93, PostId = 17, AuthorId = 4, ParentId = null, Content = "The updated examples are much clearer now.", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 94, PostId = 17, AuthorId = 1, ParentId = null, Content = "Could you expand on lazy loading in a future update?", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },

                // SCENARIO 18: Post with nested quotes/references
                new Comment { Id = 95, PostId = 18, AuthorId = 16, ParentId = null, Content = "We've implemented ADRs with great success.", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 96, PostId = 18, AuthorId = 17, ParentId = 95, Content = "What template do you use?", IsDeleted = false, Depth = 2, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 97, PostId = 18, AuthorId = 16, ParentId = 96, Content = "We use Michael Nygard's template with some customizations.", IsDeleted = false, Depth = 3, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 98, PostId = 18, AuthorId = 17, ParentId = 97, Content = "Could you share those customizations?", IsDeleted = false, Depth = 4, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 99, PostId = 18, AuthorId = 16, ParentId = 98, Content = "We added sections for security implications and performance considerations.", IsDeleted = false, Depth = 5, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 100, PostId = 18, AuthorId = 1, ParentId = null, Content = "How do you handle updating outdated ADRs?", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 101, PostId = 18, AuthorId = 18, ParentId = 100, Content = "Don't change old ADRs! Create new ones that supersede them.", IsDeleted = false, Depth = 2, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 102, PostId = 18, AuthorId = 2, ParentId = 101, Content = "As @user16 mentioned above, clear references are key.", IsDeleted = false, Depth = 3, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },

                // SCENARIO 19: Post with technical discussion and code references
                new Comment { Id = 103, PostId = 19, AuthorId = 10, ParentId = null, Content = "I prefer using proxies for the Observer pattern in modern JS.", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 104, PostId = 19, AuthorId = 2, ParentId = 103, Content = "Interesting! Can you elaborate on the advantages?", IsDeleted = false, Depth = 2, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 105, PostId = 19, AuthorId = 10, ParentId = 104, Content = "It's more declarative and requires less boilerplate than traditional implementations.", IsDeleted = false, Depth = 3, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 106, PostId = 19, AuthorId = 3, ParentId = null, Content = "Singleton is often overused and creates tight coupling.", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 107, PostId = 19, AuthorId = 4, ParentId = 106, Content = "True, dependency injection is usually a better approach.", IsDeleted = false, Depth = 2, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 108, PostId = 19, AuthorId = 20, ParentId = null, Content = "The Factory examples could use more real-world context.", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 109, PostId = 19, AuthorId = 2, ParentId = 108, Content = "Thanks for the feedback! I'll update with better examples.", IsDeleted = false, Depth = 2, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },

                // SCENARIO 20: Post with maximum depth nested comments with deletions in the middle
                new Comment { Id = 110, PostId = 20, AuthorId = 1, ParentId = null, Content = "Web Components will finally solve reusability.", IsDeleted = false, Depth = 1, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 111, PostId = 20, AuthorId = 2, ParentId = 110, Content = "Custom Elements are already well-supported.", IsDeleted = false, Depth = 2, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 112, PostId = 20, AuthorId = 3, ParentId = 111, Content = "Shadow DOM is the game changer here.", IsDeleted = false, Depth = 3, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 113, PostId = 20, AuthorId = 4, ParentId = 112, Content = "But the tooling is still immature compared to React.", IsDeleted = true, Depth = 4, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null }, // Deleted comment
                new Comment { Id = 114, PostId = 20, AuthorId = 5, ParentId = 113, Content = "Responding to a deleted comment but still relevant.", IsDeleted = false, Depth = 5, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null }, // Response to deleted
                new Comment { Id = 115, PostId = 20, AuthorId = 6, ParentId = 114, Content = "The ecosystem is definitely catching up though.", IsDeleted = false, Depth = 6, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null },
                new Comment { Id = 116, PostId = 20, AuthorId = 7, ParentId = 115, Content = "Give it another year and it will be mainstream.", IsDeleted = false, Depth = 7, Likes = 0, CreatedAt = SampleDataConstants.FixedDate, UpdatedAt = null } // Max depth
            };
    }

    /// <summary>
    /// Loads sample post likes for testing or seeding
    /// </summary>
    public static List<PostLike> LoadPostLike()
    {
      return new List<PostLike>
      {
          // Post 1 Likes
          new PostLike { Id = 1, PostId = 1, UserId = 2 },  // Bob liked Alice's post
          new PostLike { Id = 2, PostId = 1, UserId = 3 },  // Charlie liked it too

          // Post 2 Likes
          new PostLike { Id = 3, PostId = 2, UserId = 4 },  // Dana liked PostgreSQL post
          new PostLike { Id = 4, PostId = 2, UserId = 5 },  // Emily liked it
          new PostLike { Id = 5, PostId = 2, UserId = 6 },  // Frank liked it

          // Post 3 Likes
          new PostLike { Id = 6, PostId = 3, UserId = 7 },  // Grace liked AI Ethics post
          new PostLike { Id = 7, PostId = 3, UserId = 8 },  // Henry liked it

          // Post 9 Likes (JavaScript frameworks)
          new PostLike { Id = 8, PostId = 9, UserId = 9 },   // Isabella liked it
          new PostLike { Id = 9, PostId = 9, UserId = 10 },  // Jack liked it
          new PostLike { Id = 10, PostId = 9, UserId = 11 }, // Kate liked it
          new PostLike { Id = 11, PostId = 9, UserId = 12 },// Liam liked it (banned user)
          new PostLike { Id = 12, PostId = 9, UserId = 13 },// Mia liked it
          new PostLike { Id = 13, PostId = 9, UserId = 14 },// Noah liked it

          // Post 16 Likes (Cybersecurity Essentials)
          new PostLike { Id = 14, PostId = 16, UserId = 15 },// Olivia liked it (deleted user)
          new PostLike { Id = 15, PostId = 16, UserId = 16 },// Peter liked it
          new PostLike { Id = 16, PostId = 16, UserId = 17 },// Quinn liked it
          new PostLike { Id = 17, PostId = 16, UserId = 18 },// Ryan liked it
          new PostLike { Id = 18, PostId = 16, UserId = 19 },// Sophia liked it
          new PostLike { Id = 19, PostId = 16, UserId = 20 },// Thomas liked it

          // Post 13 Likes (Docker post by banned user)
          new PostLike { Id = 20, PostId = 13, UserId = 1 },
          new PostLike { Id = 21, PostId = 13, UserId = 2 },
          new PostLike { Id = 22, PostId = 13, UserId = 3 },
          new PostLike { Id = 23, PostId = 13, UserId = 4 },
          new PostLike { Id = 24, PostId = 13, UserId = 5 }
      };
    }

    /// <summary>
    /// Loads sample comment likes for testing or seeding
    /// </summary>
    public static List<CommentLike> LoadCommentLike()
    {
      return new List<CommentLike>
      {
          // Comment 1 Likes
          new CommentLike { Id = 1, CommentId = 1, UserId = 2 },  // Bob liked Alice's top-level comment
          new CommentLike { Id = 2, CommentId = 1, UserId = 3 },  // Charlie liked it

          // Comment 2 Likes
          new CommentLike { Id = 3, CommentId = 2, UserId = 1 },  // Alice liked Bob's reply
          new CommentLike { Id = 4, CommentId = 2, UserId = 4 },  // Dana liked it

          // Comment 3 Likes
          new CommentLike { Id = 5, CommentId = 3, UserId = 2 },  // Bob liked his own reply
          new CommentLike { Id = 6, CommentId = 3, UserId = 4 },  // Dana liked "Thanks Bob!"

          // Comment 9 Likes (JSONB support is gold)
          new CommentLike { Id = 7, CommentId = 9, UserId = 1 },
          new CommentLike { Id = 8, CommentId = 9, UserId = 5 },
          new CommentLike { Id = 9, CommentId = 9, UserId = 6 },

          // Comment 6 Likes (Best DB ever!)
          new CommentLike { Id = 10, CommentId = 6, UserId = 7 },
          new CommentLike { Id = 11, CommentId = 6, UserId = 8 },

          // Comment 7 Likes (And so extensible!)
          new CommentLike { Id = 12, CommentId = 7, UserId = 9 },
          new CommentLike { Id = 13, CommentId = 7, UserId = 10 },

          // Comment 47 Likes (Service discovery is a challenge)
          new CommentLike { Id = 14, CommentId = 47, UserId = 11 },
          new CommentLike { Id = 15, CommentId = 47, UserId = 12 },
          new CommentLike { Id = 16, CommentId = 47, UserId = 13 },

          // Comment 48 Likes (What template do you use?)
          new CommentLike { Id = 17, CommentId = 48, UserId = 14 },
          new CommentLike { Id = 18, CommentId = 48, UserId = 15 },

          // Comment 84 Likes (Two-factor authentication is non-negotiable)
          new CommentLike { Id = 19, CommentId = 84, UserId = 16 },
          new CommentLike { Id = 20, CommentId = 84, UserId = 17 },
          new CommentLike { Id = 21, CommentId = 84, UserId = 18 },
          new CommentLike { Id = 22, CommentId = 84, UserId = 19 },

          // Comment 85 Likes (What's your preferred 2FA method?)
          new CommentLike { Id = 23, CommentId = 85, UserId = 20 },
          new CommentLike { Id = 24, CommentId = 85, UserId = 1 },
          new CommentLike { Id = 25, CommentId = 85, UserId = 2 }
      };
    }
  }
}