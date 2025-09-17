create procedure Tag_Delete
@TagId int
as
begin
delete from Tags where TagId=@TagId
end


execute Tag_Delete @TagId=2;