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

insert into ProyectoWeb.dbo.Pedido(fechaGeneracion,fechaEntrega,idEstado,idCliente,total)
values(DATEADD(DAY,-20,getdate()),DATEADD(DAY,-15,getdate()),1,2,130.82)

insert into ProyectoWeb.dbo.Estado(nombre,descripcion,idAmbitoEstado)
values('Rechazado','Pedido rechazado',1)

insert into ProyectoWeb.dbo.AmbitoEstado(nombre,descripcion)
values('Pedido','Ambito de los pedidos')