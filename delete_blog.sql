create procedure delete_blog
@id int
as 
begin
delete from  BlogPosts where BlogPostId=@id;
end

exec delete_blog @id=20