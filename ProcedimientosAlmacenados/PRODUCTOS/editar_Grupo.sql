create procedure [dbo].[editar_Grupo]
@id int,
@Grupo varchar(50)

as
if EXISTS (SELECT Linea FROM Grupo_de_Productos  where Linea = @Grupo and Idline<>@id  )
RAISERROR ('YA EXISTE UN GRUPO CON ESTE NOMBRE, Ingrese de nuevo', 16,1)
else
update  Grupo_de_Productos set Linea=@grupo
where Idline=@id