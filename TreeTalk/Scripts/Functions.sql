CREATE OR REPLACE FUNCTION get_comment_children(comment_id INT)
RETURNS TABLE(
    "CommentID" INT,
    "ParentCommentID" INT,
    "Username" TEXT,
    "IndentedContent" TEXT,
    "Depth" INT,
    "Path" TEXT
) AS $$
WITH RECURSIVE CommentTree AS (
    -- Base case: direct child of the input comment
    SELECT 
        c."Id" AS "CommentID",
        c."PostId" AS "PostID",
        c."ParentId" AS "ParentCommentID",
        u."Username",
        c."Content",
        1 AS "Depth",
        CAST(c."Id" AS TEXT) AS "Path"
    FROM "Comment" c
    JOIN "User" u ON u."Id" = c."AuthorId"
    WHERE c."ParentId" = comment_id AND NOT c."IsDeleted"

    UNION ALL

    -- Recursive case: nested replies
    SELECT 
        c."Id" AS "CommentID",
        c."PostId" AS "PostID",
        c."ParentId" AS "ParentCommentID",
        u."Username",
        c."Content",
        ct."Depth" + 1 AS "Depth",
        ct."Path" || '->' || c."Id" AS "Path"
    FROM "Comment" c
    JOIN "User" u ON u."Id" = c."AuthorId"
    JOIN CommentTree ct ON c."ParentId" = ct."CommentID"
    WHERE NOT c."IsDeleted"
)
-- Final select with indentation
SELECT 
    ct."CommentID",
    ct."ParentCommentID",
    ct."Username",
    LPAD('', (ct."Depth" - 1) * 4, ' ') || ct."Content" AS "IndentedContent",
    ct."Depth",
    ct."Path"
FROM CommentTree ct
ORDER BY ct."Path";
$$ LANGUAGE SQL;

-- SELECT get_comment_tree(post_id);

-----------------------------------------------------------------------------------------------------

CREATE OR REPLACE FUNCTION get_comment_tree(post_id INT)
RETURNS TABLE(
    "CommentID" INT,
    "ParentCommentID" INT,
    "Username" TEXT,
    "IndentedContent" TEXT,
    "Depth" INT,
    "Path" TEXT
) AS $$
WITH RECURSIVE CommentTree AS (
    -- Base case: top-level comments
    SELECT 
        c."Id" AS "CommentID",
        c."PostId" AS "PostID",
        c."ParentId" AS "ParentCommentID",
        u."Username",
        c."Content",
        1 AS "Depth",
        CAST(c."Id" AS TEXT) AS "Path"
    FROM "Comment" c
    JOIN "User" u ON u."Id" = c."AuthorId"
    WHERE c."PostId" = post_id AND c."ParentId" IS NULL AND NOT c."IsDeleted"

    UNION ALL

    -- Recursive case: replies
    SELECT 
        c."Id" AS "CommentID",
        c."PostId" AS "PostID",
        c."ParentId" AS "ParentCommentID",
        u."Username",
        c."Content",
        ct."Depth" + 1 AS "Depth",
        ct."Path" || '->' || c."Id" AS "Path"
    FROM "Comment" c
    JOIN "User" u ON u."Id" = c."AuthorId"
    JOIN CommentTree ct ON c."ParentId" = ct."CommentID"
    WHERE c."PostId" = post_id AND NOT c."IsDeleted"
)
-- Final select with indentation
SELECT 
    ct."CommentID",
    ct."ParentCommentID",
    ct."Username",
    LPAD('', (ct."Depth" - 1) * 4, ' ') || ct."Content" AS "IndentedContent",
    ct."Depth",
    ct."Path"
FROM CommentTree ct
ORDER BY ct."Path";
$$ LANGUAGE SQL;

-- SELECT * FROM get_comment_children(comment_id);