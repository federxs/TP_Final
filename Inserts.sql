insert into [ProyectoWeb].[dbo].Usuario([nombreUsuario]
      ,[contraseña]
      ,[nombre]
      ,[apellido]
      ,[email]
      ,[idRol]
      ,[borrado])
values('fedepra','fedepra123','Federico','Prado','fpra@fede.com',1,0)

INSERT INTO [ProyectoWeb].[dbo].Rol([nombre]
      ,[descripcion]
      ,[borrado])
VALUES('Admin','Rol de Administrador, acceso a todo',0)
      
INSERT INTO [ProyectoWeb].[dbo].Rol([nombre]
      ,[descripcion]
      ,[borrado])
VALUES('Gerente','Rol de Gerente, acceso protegido',0)

INSERT INTO [ProyectoWeb].[dbo].UsuarioXRol([idUsuario]
      ,[idRol])
VALUES(1,1)

INSERT INTO [ProyectoWeb].[dbo].UsuarioXRol([idUsuario]
      ,[idRol])
VALUES(1,2)