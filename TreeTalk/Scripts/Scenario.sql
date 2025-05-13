-- Extended SQL script for TreeTalk database with 20 different testing scenarios
-- Reset sequences if needed
-- ALTER SEQUENCE "User_Id_seq" RESTART WITH 1;
-- ALTER SEQUENCE "Post_Id_seq" RESTART WITH 1;
-- ALTER SEQUENCE "Comment_Id_seq" RESTART WITH 1;

-- Insert Users (extending to support the 20 scenarios)
INSERT INTO "User" (
    "Id", "Username", "Email", "PasswordHash", 
    "Birthday", "UserImageUrl", "Gender", "AboutMe", 
    "IsBanned", "IsDeleted", "LastLoginAt", "CreatedAt"
) VALUES
(
    1,
    'alice',
    'alice@example.com',
    '$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi', -- bcrypt hash (example)
    '1990-05-15',
    'https://example.com/images/alice.jpg',
    'F',
    'Tech lover and open source contributor.',
    FALSE,
    FALSE,
    NOW(),
    NOW()
),
(
    2,
    'bob',
    'bob@example.com',
    '$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi',
    '1988-02-10',
    'https://example.com/images/bob.jpg',
    'M',
    'Full-stack developer and PostgreSQL fan.',
    FALSE,
    FALSE,
    NOW(),
    NOW()
),
(
    3,
    'charlie',
    'charlie@example.com',
    '$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi',
    '1995-11-20',
    'https://example.com/images/charlie.jpg',
    'M',
    'Database engineer and tech writer.',
    FALSE,
    FALSE,
    NOW(),
    NOW()
),
(
    4,
    'dana',
    'dana@example.com',
    '$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi',
    '1992-08-25',
    'https://example.com/images/dana.jpg',
    'F',
    'UI/UX designer and frontend developer.',
    FALSE,
    FALSE,
    NOW(),
    NOW()
),
(
    5,
    'emily',
    'emily@example.com',
    '$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi',
    '1993-04-12',
    'https://example.com/images/emily.jpg',
    'F',
    'Data scientist and ML enthusiast.',
    FALSE,
    FALSE,
    NOW(),
    NOW()
),
(
    6,
    'frank',
    'frank@example.com',
    '$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi',
    '1985-09-30',
    'https://example.com/images/frank.jpg',
    'M',
    'DevOps engineer and cloud architect.',
    FALSE,
    FALSE,
    NOW(),
    NOW()
),
(
    7,
    'grace',
    'grace@example.com',
    '$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi',
    '1991-12-05',
    'https://example.com/images/grace.jpg',
    'F',
    'Cybersecurity specialist and bug bounty hunter.',
    FALSE,
    FALSE,
    NOW(),
    NOW()
),
(
    8,
    'henry',
    'henry@example.com',
    '$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi',
    '1994-06-18',
    'https://example.com/images/henry.jpg',
    'M',
    'Mobile app developer and UX enthusiast.',
    FALSE,
    FALSE,
    NOW(),
    NOW()
),
(
    9,
    'isabella',
    'isabella@example.com',
    '$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi',
    '1989-03-22',
    'https://example.com/images/isabella.jpg',
    'F',
    'Blockchain developer and cryptocurrency researcher.',
    FALSE,
    FALSE,
    NOW(),
    NOW()
),
(
    10,
    'jack',
    'jack@example.com',
    '$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi',
    '1990-07-14',
    'https://example.com/images/jack.jpg',
    'M',
    'Game developer and 3D graphics programmer.',
    FALSE,
    FALSE,
    NOW(),
    NOW()
),
(
    11,
    'kate',
    'kate@example.com',
    '$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi',
    '1987-01-29',
    'https://example.com/images/kate.jpg',
    'F',
    'Technical writer and documentation specialist.',
    FALSE,
    FALSE,
    NOW(),
    NOW()
),
(
    12,
    'liam',
    'liam@example.com',
    '$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi',
    '1996-10-03',
    'https://example.com/images/liam.jpg',
    'M',
    'QA engineer and test automation expert.',
    TRUE, -- Banned user for testing
    FALSE,
    NOW(),
    NOW()
),
(
    13,
    'mia',
    'mia@example.com',
    '$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi',
    '1993-08-08',
    'https://example.com/images/mia.jpg',
    'F',
    'Project manager and agile coach.',
    FALSE,
    FALSE,
    NOW(),
    NOW()
),
(
    14,
    'noah',
    'noah@example.com',
    '$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi',
    '1991-05-27',
    'https://example.com/images/noah.jpg',
    'M',
    'Data engineer and big data specialist.',
    FALSE,
    FALSE,
    NOW(),
    NOW()
),
(
    15,
    'olivia',
    'olivia@example.com',
    '$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi',
    '1994-12-15',
    'https://example.com/images/olivia.jpg',
    'F',
    'UX researcher and accessibility advocate.',
    FALSE,
    TRUE, -- Deleted user for testing
    NOW(),
    NOW()
),
(
    16,
    'peter',
    'peter@example.com',
    '$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi',
    '1988-11-11',
    'https://example.com/images/peter.jpg',
    'M',
    'Systems architect and performance tuning specialist.',
    FALSE,
    FALSE,
    NOW(),
    NOW()
),
(
    17,
    'quinn',
    'quinn@example.com',
    '$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi',
    '1995-02-23',
    'https://example.com/images/quinn.jpg',
    'F',
    'API designer and integration specialist.',
    FALSE,
    FALSE,
    NOW(),
    NOW()
),
(
    18,
    'ryan',
    'ryan@example.com',
    '$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi',
    '1992-07-19',
    'https://example.com/images/ryan.jpg',
    'M',
    'IoT developer and embedded systems engineer.',
    FALSE,
    FALSE,
    NOW(),
    NOW()
),
(
    19,
    'sophia',
    'sophia@example.com',
    '$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi',
    '1990-09-04',
    'https://example.com/images/sophia.jpg',
    'F',
    'AR/VR developer and 3D modeling expert.',
    FALSE,
    FALSE,
    NOW(),
    NOW()
),
(
    20,
    'thomas',
    'thomas@example.com',
    '$2a$10$nOUninm9W4BPkMNkzX5tfeEpK8ZY7zIsGvFjnmUGB6RFXlP3ZaCmi',
    '1989-04-01',
    'https://example.com/images/thomas.jpg',
    'M',
    'SRE and infrastructure automation specialist.',
    FALSE,
    FALSE,
    NOW(),
    NOW()
);

-- SCENARIO 1: Basic comment tree (existing)
-- Post 1 - "The Power of Open Source"
-- ├── Comment 1 (Alice): Great article!
-- │   ├── Comment 2 (Bob): Totally agree!
-- │   │   └── Comment 3 (Alice): Thanks Bob!
-- │   └── Comment 4 (Charlie): I learned a lot.
-- └── Comment 5 (Dana): More please!

-- Post 1
INSERT INTO "Post" ("AuthorId", "Title", "Content", "ImageUrl") VALUES (
    1,
    'The Power of Open Source',
    'Open source software has revolutionized the tech world by fostering collaboration, transparency, and innovation. Projects like Linux, Apache, and PostgreSQL have become the backbone of modern technology infrastructure.',
    'https://example.com/os.jpg'
);

-- Comments
INSERT INTO "Comment" ("PostId", "AuthorId", "ParentId", "Content", "IsDeleted", "Depth")
VALUES
(1, 1, NULL, 'Great article!', FALSE, 1),
(1, 2, 1, 'Totally agree!', FALSE, 2),
(1, 1, 2, 'Thanks Bob!', FALSE, 3),
(1, 3, 1, 'I learned a lot.', FALSE, 2),
(1, 4, NULL, 'More please!', FALSE, 1);

-- SCENARIO 2: Medium-depth comment tree (existing)
-- Post 2 - "Why I Love PostgreSQL"
-- ├── Comment 6 (Charlie): Best DB ever!
-- │   └── Comment 7 (Dana): And so extensible!
-- │       └── Comment 8 (Charlie): Right!
-- └── Comment 9 (Bob): JSONB support is gold.

-- Post 2
INSERT INTO "Post" ("AuthorId", "Title", "Content", "ImageUrl") VALUES (
    3,
    'Why I Love PostgreSQL',
    'PostgreSQL is more than just a relational database. Its robust feature set, extensibility, and standards compliance make it an excellent choice for a wide range of applications, from simple websites to complex data analytics platforms.',
    'https://example.com/pgsql.jpg'
);

-- Comments
INSERT INTO "Comment" ("PostId", "AuthorId", "ParentId", "Content", "IsDeleted", "Depth")
VALUES
(2, 3, NULL, 'Best DB ever!', FALSE, 1),
(2, 4, 6, 'And so extensible!', FALSE, 2),
(2, 3, 7, 'Right!', FALSE, 3),
(2, 2, NULL, 'JSONB support is gold.', FALSE, 1);

-- SCENARIO 3: Wide comment tree with multiple branches (existing)
-- Post 3 - "AI Ethics in Modern Tech"
-- ├── Comment 10 (Dana): Important topic!
-- │   └── Comment 11 (Bob): Couldn't agree more.
-- │       └── Comment 12 (Charlie): But we must act fast.
-- ├── Comment 13 (Alice): Need more regulation.
-- └── Comment 14 (Dana): Let's be careful.

-- Post 3
INSERT INTO "Post" ("AuthorId", "Title", "Content", "ImageUrl") VALUES (
    4,
    'AI Ethics in Modern Tech',
    'As AI becomes more powerful, we must consider ethical boundaries. The rapid advancement of artificial intelligence technologies raises important questions about privacy, bias, accountability, and the future of work.',
    'https://example.com/ai.jpg'
);

-- Comments
INSERT INTO "Comment" ("PostId", "AuthorId", "ParentId", "Content", "IsDeleted", "Depth")
VALUES
(3, 4, NULL, 'Important topic!', FALSE, 1),
(3, 2, 10, 'Couldn''t agree more.', FALSE, 2),
(3, 3, 11, 'But we must act fast.', FALSE, 3),
(3, 1, NULL, 'Need more regulation.', FALSE, 1),
(3, 4, NULL, 'Let''s be careful.', FALSE, 1);

-- SCENARIO 4: Maximum depth comment tree (testing depth constraint)
-- Post 4 - "Understanding Recursion in Programming"
-- └── Comment chain going to maximum depth (7)

-- Post 4
INSERT INTO "Post" ("AuthorId", "Title", "Content", "ImageUrl") VALUES (
    5,
    'Understanding Recursion in Programming',
    'Recursion is a powerful technique in programming where a function calls itself. This article explores how recursion works, when to use it, and common pitfalls to avoid.',
    'https://example.com/recursion.jpg'
);

-- Comments (max depth chain)
INSERT INTO "Comment" ("PostId", "AuthorId", "ParentId", "Content", "IsDeleted", "Depth")
VALUES
(4, 5, NULL, 'I love using recursion for tree traversal!', FALSE, 1),
(4, 6, 15, 'Recursion can be tricky with large datasets though.', FALSE, 2),
(4, 7, 16, 'That''s why you need proper base cases.', FALSE, 3),
(4, 8, 17, 'And be careful about stack overflow.', FALSE, 4),
(4, 9, 18, 'Tail recursion can help with that.', FALSE, 5),
(4, 10, 19, 'Not all languages optimize for tail recursion though.', FALSE, 6),
(4, 11, 20, 'Good point! Sometimes iteration is clearer anyway.', FALSE, 7);

-- SCENARIO 5: Post with deleted comments
-- Post 5 - "The Future of Remote Work"
-- ├── Comment (Emily): Remote work is here to stay! [DELETED]
-- │   └── Comment (Frank): But what about company culture?
-- ├── Comment (Grace): I love working remotely.
-- └── Comment (Henry): Hybrid models seem best. [DELETED]

-- Post 5
INSERT INTO "Post" ("AuthorId", "Title", "Content", "ImageUrl") VALUES (
    12,
    'The Future of Remote Work',
    'The COVID-19 pandemic accelerated the adoption of remote work. This article examines the long-term implications for businesses, employees, and office spaces.',
    'https://example.com/remote-work.jpg'
);

-- Comments with deletions
INSERT INTO "Comment" ("PostId", "AuthorId", "ParentId", "Content", "IsDeleted", "Depth")
VALUES
(5, 5, NULL, 'Remote work is here to stay!', TRUE, 1), -- Deleted comment
(5, 6, 22, 'But what about company culture?', FALSE, 2), -- Child of deleted comment
(5, 7, NULL, 'I love working remotely.', FALSE, 1),
(5, 8, NULL, 'Hybrid models seem best.', TRUE, 1); -- Another deleted comment

-- SCENARIO 6: Post by banned user with comments
-- Post 6 - "Advanced SQL Tips"
-- ├── Comment (Alice): Great tips!
-- └── Comment (Bob): I use these daily.

-- Post 6 (by banned user Liam - ID 12)
INSERT INTO "Post" ("AuthorId", "Title", "Content", "ImageUrl") VALUES (
    12, -- Liam (banned)
    'Advanced SQL Tips',
    'Improve your SQL queries with these advanced techniques. Learn about window functions, CTEs, and performance optimization strategies.',
    'https://example.com/sql-tips.jpg'
);

-- Comments on banned user's post
INSERT INTO "Comment" ("PostId", "AuthorId", "ParentId", "Content", "IsDeleted", "Depth")
VALUES
(6, 1, NULL, 'Great tips despite the author being banned!', FALSE, 1),
(6, 2, NULL, 'I use these daily.', FALSE, 1);

-- SCENARIO 7: Post with comment from deleted user
-- Post 7 - "Getting Started with Docker"
-- ├── Comment (Olivia - deleted user): Docker changed my workflow!
-- └── Comment (Peter): Containers are the future.

-- Post 7
INSERT INTO "Post" ("AuthorId", "Title", "Content", "ImageUrl") VALUES (
    9,
    'Getting Started with Docker',
    'Docker simplifies the process of managing application processes in containers. This guide walks you through the basics of containerization.',
    'https://example.com/docker.jpg'
);

-- Comments including one from deleted user
INSERT INTO "Comment" ("PostId", "AuthorId", "ParentId", "Content", "IsDeleted", "Depth")
VALUES
(7, 15, NULL, 'Docker changed my workflow!', FALSE, 1), -- Comment from deleted user (Olivia)
(7, 16, NULL, 'Containers are the future.', FALSE, 1);

-- SCENARIO 8: Deep and wide comment tree
-- Post 8 - "The Art of Code Review"
-- ├── Branch 1 with depth 3
-- ├── Branch 2 with depth 4
-- └── Branch 3 with depth 2

-- Post 8
INSERT INTO "Post" ("AuthorId", "Title", "Content", "ImageUrl") VALUES (
    11,
    'The Art of Code Review',
    'Effective code reviews improve code quality and foster knowledge sharing within teams. This article covers best practices for giving and receiving code review feedback.',
    'https://example.com/code-review.jpg'
);

-- Comments for complex tree
INSERT INTO "Comment" ("PostId", "AuthorId", "ParentId", "Content", "IsDeleted", "Depth")
VALUES
-- Branch 1
(8, 3, NULL, 'Code reviews saved our project!', FALSE, 1),
(8, 4, 31, 'What process do you follow?', FALSE, 2),
(8, 3, 32, 'We use a checklist approach.', FALSE, 3),

-- Branch 2
(8, 5, NULL, 'I struggle with giving constructive feedback.', FALSE, 1),
(8, 6, 34, 'Try focusing on the code, not the person.', FALSE, 2),
(8, 7, 35, 'The sandwich approach works well too.', FALSE, 3),
(8, 5, 36, 'Thanks for the tips!', FALSE, 4),

-- Branch 3
(8, 8, NULL, 'Automated tools can help too.', FALSE, 1),
(8, 9, 38, 'Any recommendations?', FALSE, 2);

-- SCENARIO 9: Post with high engagement (many top-level comments)
-- Post 9 - "JavaScript Frameworks Comparison"

-- Post 9
INSERT INTO "Post" ("AuthorId", "Title", "Content", "ImageUrl") VALUES (
    10,
    'JavaScript Frameworks Comparison',
    'This comprehensive comparison of popular JavaScript frameworks examines React, Angular, Vue, Svelte and others across performance, learning curve, and community support metrics.',
    'https://example.com/js-frameworks.jpg'
);

-- Many top-level comments for high engagement
INSERT INTO "Comment" ("PostId", "AuthorId", "ParentId", "Content", "IsDeleted", "Depth")
VALUES
(9, 1, NULL, 'React is my favorite for large applications.', FALSE, 1),
(9, 2, NULL, 'Angular has better built-in features.', FALSE, 1),
(9, 3, NULL, 'Vue is the most approachable for beginners.', FALSE, 1),
(9, 4, NULL, 'Svelte is revolutionary with its compile-time approach.', FALSE, 1),
(9, 5, NULL, 'I prefer vanilla JS whenever possible.', FALSE, 1),
(9, 6, NULL, 'Framework fatigue is real!', FALSE, 1),
(9, 7, NULL, 'Next.js is a game-changer for React projects.', FALSE, 1),
(9, 8, NULL, 'The virtual DOM concept changed frontend development.', FALSE, 1);

-- SCENARIO 10: Post with no comments
-- Post 10 - "Introduction to WebAssembly"

-- Post 10
INSERT INTO "Post" ("AuthorId", "Title", "Content", "ImageUrl") VALUES (
    17,
    'Introduction to WebAssembly',
    'WebAssembly is a binary instruction format that enables high-performance applications on the web. This article introduces the key concepts and use cases for this emerging technology.',
    'https://example.com/wasm.jpg'
);

-- No comments for this post

-- SCENARIO 11: Post with complex reply structure
-- Post 11 - "Microservices Architecture Patterns"

-- Post 11
INSERT INTO "Post" ("AuthorId", "Title", "Content", "ImageUrl") VALUES (
    16,
    'Microservices Architecture Patterns',
    'Microservices have become a popular architectural style for building complex applications. This article explores common patterns, anti-patterns, and implementation strategies.',
    'https://example.com/microservices.jpg'
);

-- Complex reply structure
INSERT INTO "Comment" ("PostId", "AuthorId", "ParentId", "Content", "IsDeleted", "Depth")
VALUES
-- Main thread 1
(11, 2, NULL, 'Service discovery is a challenge with microservices.', FALSE, 1),
(11, 3, 48, 'Have you tried Consul or etcd?', FALSE, 2),
(11, 2, 49, 'Yes, we use Consul with great results.', FALSE, 3),
(11, 4, 50, 'How does it handle network partitions?', FALSE, 4),
(11, 2, 51, 'It has built-in health checks that help.', FALSE, 5),

-- Main thread 2
(11, 5, NULL, 'Data consistency across services is tricky.', FALSE, 1),
(11, 6, 53, 'Saga pattern can help with that.', FALSE, 2),
(11, 7, 53, 'Event sourcing is another approach.', FALSE, 2), -- Note: Same parent as above
(11, 5, 54, 'Can you explain the Saga pattern more?', FALSE, 3),
(11, 6, 56, 'It sequences local transactions with compensating actions.', FALSE, 4);

-- SCENARIO 12: Post with long discussion chain
-- Post 12 - "Quantum Computing Explained"

-- Post 12
INSERT INTO "Post" ("AuthorId", "Title", "Content", "ImageUrl") VALUES (
    14,
    'Quantum Computing Explained',
    'This accessible introduction to quantum computing covers qubits, superposition, entanglement, and quantum gates. Learn how quantum computers differ from classical computers and their potential applications.',
    'https://example.com/quantum.jpg'
);

-- Long linear discussion
INSERT INTO "Comment" ("PostId", "AuthorId", "ParentId", "Content", "IsDeleted", "Depth")
VALUES
(12, 9, NULL, 'When will quantum computers become practical?', FALSE, 1),
(12, 10, 57, 'For certain algorithms, they already are.', FALSE, 2),
(12, 9, 58, 'Like which ones?', FALSE, 3),
(12, 10, 59, 'Shor''s algorithm for factoring large numbers.', FALSE, 4),
(12, 11, 60, 'That has implications for cryptography, right?', FALSE, 5),
(12, 10, 61, 'Exactly! Current encryption could be broken.', FALSE, 6),
(12, 9, 62, 'So what''s the solution?', FALSE, 7); -- Max depth

-- SCENARIO 13: Post with edited comments (using UpdatedAt)
-- Post 13 - "DevOps Best Practices"

-- Post 13
INSERT INTO "Post" ("AuthorId", "Title", "Content", "ImageUrl") VALUES (
    6,
    'DevOps Best Practices',
    'Implementing DevOps practices can streamline software delivery and improve team collaboration. This article covers CI/CD, infrastructure as code, and monitoring strategies.',
    'https://example.com/devops.jpg'
);

-- Comments with some edited (UpdatedAt set)
INSERT INTO "Comment" ("PostId", "AuthorId", "ParentId", "Content", "IsDeleted", "Depth", "UpdatedAt")
VALUES
(13, 6, NULL, 'Automation is the key to successful DevOps.', FALSE, 1, NOW()),
(13, 7, 64, 'Agreed! What tools do you recommend?', FALSE, 2, NULL),
(13, 6, 65, 'Jenkins, Terraform, and Prometheus are my go-to stack.', FALSE, 3, NOW() + INTERVAL '1 hour'),
(13, 8, NULL, 'Don''t forget about cultural aspects of DevOps.', FALSE, 1, NULL);

-- SCENARIO 14: Post with highly liked comments
-- Post 14 - "Machine Learning for Beginners"

-- Post 14
INSERT INTO "Post" ("AuthorId", "Title", "Content", "ImageUrl") VALUES (
    5,
    'Machine Learning for Beginners',
    'Getting started with machine learning doesn''t have to be intimidating. This guide introduces foundational concepts and tools for beginners wanting to enter the field of AI and ML.',
    'https://example.com/ml-beginners.jpg'
);

-- Comments with varying likes
INSERT INTO "Comment" ("PostId", "AuthorId", "ParentId", "Content", "IsDeleted", "Depth", "Likes")
VALUES
(14, 14, NULL, 'Python is the best language to start with for ML.', FALSE, 1, 42),
(14, 3, 68, 'Absolutely! Scikit-learn makes it so accessible.', FALSE, 2, 29),
(14, 5, NULL, 'Understanding the math is crucial though.', FALSE, 1, 15),
(14, 1, NULL, 'Any book recommendations for beginners?', FALSE, 1, 8),
(14, 14, 71, 'Hands-On Machine Learning by Aurélien Géron is excellent.', FALSE, 2, 37);

-- SCENARIO 15: Post with controversial discussion (replies to replies)
-- Post 15 - "Tabs vs. Spaces: The Eternal Debate"

-- Post 15
INSERT INTO "Post" ("AuthorId", "Title", "Content", "ImageUrl") VALUES (
    13,
    'Tabs vs. Spaces: The Eternal Debate',
    'Code formatting preferences have sparked debates among developers for decades. This lighthearted article examines the pros and cons of using tabs versus spaces for indentation.',
    'https://example.com/tabs-spaces.jpg'
);

-- Controversial discussion with many branches
INSERT INTO "Comment" ("PostId", "AuthorId", "ParentId", "Content", "IsDeleted", "Depth")
VALUES
(15, 1, NULL, 'Tabs are more accessible and customizable!', FALSE, 1),
(15, 2, 73, 'But spaces ensure consistent formatting everywhere.', FALSE, 2),
(15, 3, 74, 'That''s why we have .editorconfig files.', FALSE, 3),
(15, 2, 75, 'Not all editors support that though.', FALSE, 4),
(15, 4, NULL, 'Spaces are the industry standard.', FALSE, 1),
(15, 5, 77, 'Only because of senior developers'' preferences.', FALSE, 2),
(15, 6, 78, 'And years of practical experience!', FALSE, 3),
(15, 5, 79, 'Appeal to authority fallacy.', FALSE, 4),
(15, 6, 80, 'No, it''s empirical evidence.', FALSE, 5),
(15, 7, NULL, 'Just use both to confuse everyone!', FALSE, 1),
(15, 8, 82, 'That''s pure evil.', FALSE, 2);

-- SCENARIO 16: Post with likes and many comments
-- Post 16 - "Cybersecurity Essentials"

-- Post 16
INSERT INTO "Post" ("AuthorId", "Title", "Content", "ImageUrl", "Likes") VALUES (
    7,
    'Cybersecurity Essentials',
    'Protecting your digital assets is more important than ever. This comprehensive guide covers the fundamentals of cybersecurity for individuals and small businesses.',
    'https://example.com/cybersecurity.jpg',
    156
);

-- Comments with varying engagement
INSERT INTO "Comment" ("PostId", "AuthorId", "ParentId", "Content", "IsDeleted", "Depth", "Likes")
VALUES
(16, 9, NULL, 'Two-factor authentication is non-negotiable these days.', FALSE, 1, 45),
(16, 10, 84, 'What''s your preferred 2FA method?', FALSE, 2, 12),
(16, 9, 85, 'Hardware keys for critical accounts, authenticator apps for others.', FALSE, 3, 23),
(16, 11, NULL, 'Regular security audits saved our company.', FALSE, 1, 39),
(16, 12, NULL, 'Password managers are essential.', FALSE, 1, 51),
(16, 13, NULL, 'What about zero-trust architecture?', FALSE, 1, 8),
(16, 7, 89, 'Excellent point! I''ll cover that in part 2.', FALSE, 2, 17);

-- SCENARIO 17: Post with updated content (edited post)
-- Post 17 - "Frontend Performance Optimization"

-- Post 17
INSERT INTO "Post" ("AuthorId", "Title", "Content", "ImageUrl", "UpdatedAt") VALUES (
    19,
    'Frontend Performance Optimization',
    'Speed matters for user experience and SEO. This guide explores techniques for optimizing frontend performance, from code splitting to image optimization.',
    'https://example.com/frontend-perf.jpg',
    NOW() + INTERVAL '2 days'
);

-- Comments discussing the updated post
INSERT INTO "Comment" ("PostId", "AuthorId", "ParentId", "Content", "IsDeleted", "Depth")
VALUES
(17, 8, NULL, 'Thanks for adding the section on Core Web Vitals!', FALSE, 1),
(17, 19, 91, 'You''re welcome! It''s become so important for SEO.', FALSE, 2),
(17, 4, NULL, 'The updated examples are much clearer now.', FALSE, 1),
(17, 1, NULL, 'Could you expand on lazy loading in a future update?', FALSE, 1);

-- SCENARIO 18: Post with nested quotes/references
-- Post 18 - "Software Architecture Decision Records"

-- Post 18
INSERT INTO "Post" ("AuthorId", "Title", "Content", "ImageUrl") VALUES (
    18,
    'Software Architecture Decision Records',
    'Documenting architectural decisions is crucial for team alignment and knowledge preservation. This article introduces Architecture Decision Records (ADRs) as a lightweight documentation method.',
    'https://example.com/adr.jpg'
);

-- Comments with nested discussions and references to previous comments
INSERT INTO "Comment" ("PostId", "AuthorId", "ParentId", "Content", "IsDeleted", "Depth")
VALUES
(18, 16, NULL, 'We''ve implemented ADRs with great success.', FALSE, 1),
(18, 17, 95, 'What template do you use?', FALSE, 2),
(18, 16, 96, 'We use Michael Nygard''s template with some customizations.', FALSE, 3),
(18, 17, 97, 'Could you share those customizations?', FALSE, 4),
(18, 16, 98, 'We added sections for security implications and performance considerations.', FALSE, 5),
(18, 1, NULL, 'How do you handle updating outdated ADRs?', FALSE, 1),
(18, 18, 100, 'Don''t change old ADRs! Create new ones that supersede them.', FALSE, 2),
(18, 2, 101, 'As @user16 mentioned above, clear references are key.', FALSE, 3);

-- SCENARIO 19: Post with technical discussion and code references
-- Post 19 - "Design Patterns in Modern JavaScript"

-- Post 19
INSERT INTO "Post" ("AuthorId", "Title", "Content", "ImageUrl") VALUES (
    2,
    'Design Patterns in Modern JavaScript',
    'Classical design patterns remain relevant in modern JavaScript development. This article examines how patterns like Observer, Factory, and Singleton can be implemented using ES6+ features.',
    'https://example.com/js-patterns.jpg'
);

-- Comments discussing code implementation
INSERT INTO "Comment" ("PostId", "AuthorId", "ParentId", "Content", "IsDeleted", "Depth")
VALUES
(19, 10, NULL, 'I prefer using proxies for the Observer pattern in modern JS.', FALSE, 1),
(19, 2, 103, 'Interesting! Can you elaborate on the advantages?', FALSE, 2),
(19, 10, 104, 'It''s more declarative and requires less boilerplate than traditional implementations.', FALSE, 3),
(19, 3, NULL, 'Singleton is often overused and creates tight coupling.', FALSE, 1),
(19, 4, 106, 'True, dependency injection is usually a better approach.', FALSE, 2),
(19, 20, NULL, 'The Factory examples could use more real-world context.', FALSE, 1),
(19, 2, 108, 'Thanks for the feedback! I''ll update with better examples.', FALSE, 2);

-- SCENARIO 20: Post with maximum depth nested comments with deletions in the middle
-- Post 20 - "The Future of Web Development"

-- Post 20
INSERT INTO "Post" ("AuthorId", "Title", "Content", "ImageUrl") VALUES (
    13,
    'The Future of Web Development',
    'Web development continues to evolve at a rapid pace. This article explores emerging trends like Web Components, WebAssembly, Edge Computing, and Progressive Web Apps that are shaping the future.',
    'https://example.com/future-web.jpg'
);

-- Complex nested comments with deletions
INSERT INTO "Comment" ("PostId", "AuthorId", "ParentId", "Content", "IsDeleted", "Depth")
VALUES
(20, 1, NULL, 'Web Components will finally solve reusability.', FALSE, 1),
(20, 2, 110, 'Custom Elements are already well-supported.', FALSE, 2),
(20, 3, 111, 'Shadow DOM is the game changer here.', FALSE, 3),
(20, 4, 112, 'But the tooling is still immature compared to React.', TRUE, 4), -- Deleted comment
(20, 5, 113, 'Responding to a deleted comment but still relevant.', FALSE, 5), -- Response to deleted
(20, 6, 114, 'The ecosystem is definitely catching up though.', FALSE, 6),
(20, 7, 115, 'Give it another year and it will be mainstream.', FALSE, 7); -- Max depth

-- Test queries
SELECT * FROM get_comment_tree(1); -- Basic comment tree
SELECT * FROM get_comment_tree(4); -- Maximum depth test
SELECT * FROM get_comment_tree(5); -- Deleted comments test
SELECT * FROM get_comment_tree(11); -- Complex reply structure
SELECT * FROM get_comment_tree(15); -- Controversial discussion
SELECT * FROM get_comment_tree(20); -- Complex with middle deletions

-- Delete all rows from Post (also deletes related Comments due to ON DELETE CASCADE, but Comment is already cleared)
DELETE FROM "Post";

-- Delete all rows from User (also deletes related Posts and Comments if ON DELETE CASCADE is added to foreign keys)
DELETE FROM "User";

-- Reset the User Id sequence to start at 1
ALTER SEQUENCE "User_Id_seq" RESTART WITH 1;

-- Reset the Post Id sequence to start at 1
ALTER SEQUENCE "Post_Id_seq" RESTART WITH 1;

-- Reset the Comment Id sequence to start at 1
ALTER SEQUENCE "Comment_Id_seq" RESTART WITH 1;