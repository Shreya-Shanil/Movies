create database void
go
use void
go
create table movies(
	srno INT IDENTITY(1,1),
	mname varchar(15) UNIQUE,
	years smallint , 
	actor varchar(15) NOT NULL,
	actress varchar(15) NOT NULL,		
	dname varchar(25) NOT NULL
)
go 
create procedure usp_set_movies
(
@srno int
,@mname	varchar(15)
,@years	smallint
,@actor	varchar(15)
,@actress	varchar(15)
,@dname	varchar(25)
)
as
begin
	if exists 
	(
		select 1 from movies where srno = @srno
	)
	begin
		update movies
		set 
		 mname	=@mname
		,years	=@years
		,actor	=@actor
		,actress=@actress
		,dname	=@dname
		where srno =@srno
	end
	else 
	begin
		insert into movies 
		(
			mname
			,years
			,actor
			,actress
			,dname
		)
		values
		(
			@mname
			,@years
			,@actor
			,@actress
			,@dname
		)
	end
end
GO
create procedure usp_get_movies
(
	@actor varchar(15)
)
as
begin
	
	SELECT srno
		,mname
		,years
		,actor
		,actress
		,dname
	FROM movies
	where actor like @actor+'%'
end
go
create procedure usp_get_movies_by_id
(
	@srno int
)
as
begin
	if(@srno<=0)
	begin
		set @srno =null
	end
	SELECT srno
		,mname
		,years
		,actor
		,actress
		,dname
	FROM movies
	where SRNO =isnull(@srno ,srno )
end
go