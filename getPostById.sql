create procedure getPostById  
@id int  
as   
begin  
        select * from BlogPosts where BlogPostId=@id  
end