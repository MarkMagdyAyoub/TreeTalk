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