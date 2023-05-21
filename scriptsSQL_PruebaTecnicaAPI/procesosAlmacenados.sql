go
use DBPRUEBATECNICA
go
--************************ VALIDAMOS SI EXISTE EL PROCEDIMIENTO ************************--

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_registrar')
DROP PROCEDURE usp_registrar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_modificar')
DROP PROCEDURE usp_modificar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_obtener')
DROP PROCEDURE usp_obtener

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_listar')
DROP PROCEDURE usp_listar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_eliminar')
DROP PROCEDURE usp_eliminar

go

--************************ PROCEDIMIENTOS PARA CREAR ************************--
CREATE PROCEDURE usp_registrar
    @documentoidentidad varchar(60),
    @nombres varchar(60),
    @telefono varchar(60),
    @correo varchar(60),
    @ciudad varchar(60),
    @IdTrabajador int OUTPUT
AS
BEGIN
    -- Insertar el nuevo trabajador en la tabla
    INSERT INTO TRABAJADORES (DocumentoIdentidad, Nombres, Telefono, Correo, Ciudad)
    VALUES (@documentoidentidad, @nombres, @telefono, @correo, @ciudad)

    -- Obtener el ID del trabajador recién insertado
    SET @IdTrabajador = SCOPE_IDENTITY()
END


go


CREATE PROCEDURE usp_modificar
    @idusuario INT,
    @documentoidentidad VARCHAR(60),
    @nombres VARCHAR(60),
    @telefono VARCHAR(60),
    @correo VARCHAR(60),
    @ciudad VARCHAR(60)
AS
BEGIN
    UPDATE TRABAJADORES
    SET DocumentoIdentidad = @documentoidentidad,
        Nombres = @nombres,
        Telefono = @telefono,
        Correo = @correo,
        Ciudad = @ciudad
    WHERE IdUsuario = @idusuario;

    SELECT *
    FROM TRABAJADORES
    WHERE IdUsuario = @idusuario;
END

go

create procedure usp_obtener(@idusuario int)
as
begin

select * from TRABAJADORES where IdUsuario = @idusuario
end

go
create procedure usp_listar
as
begin

select * from TRABAJADORES
end


go

go

create procedure usp_eliminar(
@idusuario int
)
as
begin

delete from TRABAJADORES where IdUsuario = @idusuario

end

go