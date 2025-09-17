create procedure Tag_Update
@Id int,
@Name varchar(200)
as
begin
update Tags set Name=@Name where TagId=@Id
end

exec Tag_Update @Id=3 , @Name='gujjar'