use Neptuno

create proc sp_listarProductos
as begin
select * from dbo.Productos
end

CREATE PROC sp_AddNewProduct
@id int,
@nombre nvarchar(80),
@proveedor int,
@categoria int,
@cantidadUnidad nvarchar(50),
@precioUnidad money,
@unidadExistencia smallint,
@unidadPedido smallint,
@nivelNuevoPedido smallint,
@suspendido bit
AS
BEGIN
INSERT INTO Productos values(@id,@nombre,@proveedor,@categoria,@cantidadUnidad,@precioUnidad,@unidadExistencia,@unidadPedido,@nivelNuevoPedido,@suspendido)
END

create proc updateProduct
@id int,
@nombre nvarchar(80),
@proveedor int,
@categoria int,
@cantidadUnidad nvarchar(50),
@precioUnidad money,
@unidadExistencia smallint,
@unidadPedido smallint,
@nivelNuevoPedido smallint,
@suspendido bit
as
begin
update Productos
set NombreProducto = @nombre, IdProveedor = @proveedor, IdCategoria = @categoria, CantidadPorUnidad = @cantidadUnidad, PrecioUnidad = @precioUnidad, UnidadesEnExistencia =@unidadExistencia,
UnidadesEnPedido = @unidadPedido, NivelNuevoPedido = @nivelNuevoPedido, Suspendido = @suspendido
where IdProducto = @id
end

create proc deleteProductoById
@id int
as
begin
delete from Productos where IdProducto=@id
end

use proc sp_listarp

sp_help Productos

select * from Productos
delete from Productos where IdProducto = 201
