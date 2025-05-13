CREATE OR REPLACE FUNCTION get_comment_children(comment_id INT)
RETURNS TABLE(
    "CommentID" INT,
    "ParentCommentID" INT,
    "Username" TEXT,
    "IndentedContent" TEXT,
    "Depth" INT,
    "Path" TEXT,
    "Likes" INT,
    "ImageUrl" TEXT
) AS $$
WITH RECURSIVE CommentTree AS (
    -- direct child of input comment
    SELECT 
        c."Id" AS "CommentID",
        c."PostId" AS "PostID",
        c."ParentId" AS "ParentCommentID",
        u."Username",
        c."Content",
        1 AS "Depth",
        CAST(c."Id" AS TEXT) AS "Path",
        c."Likes",            
        u."UserImageUrl" AS "ImageUrl"  
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
        ct."Path" || '->' || c."Id" AS "Path",
        c."Likes",            
        u."UserImageUrl" AS "ImageUrl" 
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
    ct."Path",
    ct."Likes",
    ct."ImageUrl"
FROM CommentTree ct
ORDER BY ct."Path";
$$ LANGUAGE SQL;