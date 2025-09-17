create or alter procedure updateBlog
@Id int,
@Title NVARCHAR(200) ,
@Content varchar(max),
@ImageUrl NVARCHAR(500),
@UserId NVARCHAR(450),
@CategoryId int,
@Status int
As
begin
update BlogPosts
set Title=@Title,Content=@Content,ImageUrl=@ImageUrl,UserId=@UserId,CategoryId=@CategoryId,Status=@Status,UpdatedAt=GETDATE(),IsDeleted=0
where BlogPostId=@Id
end

EXEC UpdateBlog
    @BlogPostId = 6,
    @Title = 'Getting Started with .NET Core',
    @Content = 'This is a sample blog post content for testing update procedure.',
    @ImageUrl = N'https://example.com/images/blog1.jpg',
    @UserId = 'user-001',
    @CategoryId = 2,
    @Status = 0;