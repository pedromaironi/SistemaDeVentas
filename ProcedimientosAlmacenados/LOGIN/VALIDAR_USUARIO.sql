create procedure validar_usuario

@password varchar(50),
@login varchar(50)
as
select * from USUARIO2
where Password = @password and Login = @login and Estado = 'ACTIVO'