CREATE OR REPLACE PROCEDURE soft_delete_comment_tree(IN comment_id INT)
LANGUAGE plpgsql
AS $$
BEGIN
    -- Recursive CTE to find the comment and all its descendants
    WITH RECURSIVE CommentTree AS (
        SELECT "Id" FROM "Comment" WHERE "Id" = comment_id
        UNION ALL
        SELECT c."Id"
        FROM "Comment" c
        INNER JOIN CommentTree t ON c."ParentId" = t."Id"
    )
    -- Update IsDeleted flag for all matching comments
    UPDATE "Comment"
    SET "IsDeleted" = TRUE
    WHERE "Id" IN (SELECT "Id" FROM CommentTree);
END;
$$;

-- ----------------------------------

CREATE OR REPLACE PROCEDURE soft_delete_post_and_tree(IN post_id INT)
LANGUAGE plpgsql
AS $$
BEGIN
    -- Step 1: Mark the post as deleted
    UPDATE "Post"
    SET "IsDeleted" = TRUE
    WHERE "Id" = post_id;

    -- Step 2: Recursively find all comments under this post
    WITH RECURSIVE CommentTree AS (
        SELECT "Id" FROM "Comment" WHERE "PostId" = post_id AND "ParentId" IS NULL
        UNION ALL
        SELECT c."Id"
        FROM "Comment" c
        INNER JOIN CommentTree t ON c."ParentId" = t."Id"
    )
    -- Step 3: Mark all found comments as deleted
    UPDATE "Comment"
    SET "IsDeleted" = TRUE
    WHERE "Id" IN (SELECT "Id" FROM CommentTree);
END;
$$;
