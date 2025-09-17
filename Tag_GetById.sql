
create procedure Tag_GetById
@id int  
as   
begin  
        select * from Tags where TagId=@id  
end
exec Tag_GetById @id=1