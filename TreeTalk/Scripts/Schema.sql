CREATE DATABASE TreeTalk;


CREATE TABLE "User"(
	"Id" SERIAL PRIMARY KEY , 
	"Username" VARCHAR(50) UNIQUE NOT NULL,
	"Email" VARCHAR(100) UNIQUE NOT NULL,
	"PasswordHash" VARCHAR(60) NOT NULL,
	"Birthday" DATE NOT NULL,
	"UserImageUrl" TEXT NOT NULL,
	"Gender" CHAR NOT NULL,
	"AboutMe" TEXT NULL,
	"IsBanned" BOOLEAN DEFAULT FALSE,
	"IsDeleted" BOOLEAN DEFAULT FALSE,
	"LastLoginAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"CreatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"UpdatedAt" TIMESTAMP NULL
);

CREATE TABLE "Post"(
	"Id" SERIAL PRIMARY KEY,
	"AuthorId" INT NOT NULL,
	"Title" VARCHAR(200) NOT NULL,
	"Content" TEXT NULL,
	"ImageUrl" TEXT NULL,
	"Likes" INT NOT NULL DEFAULT 0,
	"CreatedAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	"UpdatedAt" TIMESTAMP NULL,
	"IsDeleted" BOOLEAN DEFAULT FALSE,
	CONSTRAINT fk_post_authorid FOREIGN KEY ("AuthorId") REFERENCES "User"("Id")
);

CREATE INDEX idx_post_authorid ON "Post"("AuthorId");


CREATE TABLE "Comment"(
	"Id" SERIAL PRIMARY KEY,
	"PostId" INT NOT NULL,
	"ParentId" INT NULL,
	"AuthorId" INT NOT NULL,
	"Content" TEXT NOT NULL,
	"Likes" INT NOT NULL DEFAULT 0,
	"CreatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"UpdatedAt" TIMESTAMP NULL,
	"IsDeleted" BOOLEAN NOT NULL DEFAULT FALSE,
	"Depth" INT NOT NULL DEFAULT 1,
	CONSTRAINT fk_comment_postid FOREIGN KEY ("PostId") REFERENCES "Post"("Id") ON DELETE CASCADE,
	CONSTRAINT fk_comment_parentid FOREIGN KEY ("ParentId") REFERENCES "Comment"("Id") ON DELETE CASCADE,
	CONSTRAINT fk_comment_authorid FOREIGN KEY ("AuthorId") REFERENCES "User"("Id"),
	CONSTRAINT check_comment_depth CHECK ("Depth" BETWEEN 1 AND 7)
);

CREATE INDEX idx_comment_postid ON "Comment"("PostId");
CREATE INDEX idx_comment_authorid ON "Comment"("AuthorId");
CREATE INDEX idx_comment_parentid ON "Comment"("ParentId");
CREATE INDEX idx_comment_createdat ON "Comment"("CreatedAt");
CREATE INDEX idx_comment_comment_active ON "Comment"("Id") WHERE NOT "IsDeleted";
