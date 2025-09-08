
CREATE PROCEDURE blog_create
    @Title NVARCHAR(200),
    @Content NVARCHAR(MAX),
    @ImageUrl NVARCHAR(500) = NULL,
    @UserId NVARCHAR(450),     -- FK -> AspNetUsers
    @CategoryId INT = NULL,    -- FK -> Categories
    @Status INT = 1,            -- 1=Draft, 2=Published
	@IsDeleted bit
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO BlogPosts 
    (
        Title,
        Content,
        ImageUrl,
        UserId,
        CategoryId,
        Status,
        CreatedAt,
        IsDeleted
    )
    VALUES
    (
        @Title,
        @Content,
        @ImageUrl,
        @UserId,
        @CategoryId,
        @Status,
        GETDATE(),    -- use default created timestamp
        @IsDeleted           -- default not deleted
    );
END