create procedure Tag_Create
@Name varchar(200)
as
begin
insert into Tags (name) values(@Name)
end

execute Tag_Create @Name="sohail";