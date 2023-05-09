namespace CRM.Utilities
{
    internal static class Sentences
    {
        internal const String DELETE_PETICION = "DELETE FROM [dbo].[peticiones] WHERE [idPeticion] = @IDPETICION";

        internal const String DELETE_USUARIO = "DELETE FROM [dbo].[usuarios] WHERE [id] = @ID";

        internal const String INSERT_PETICION = "INSERT INTO [dbo].[peticiones] ([Activa],[Descripcion],[fechaRespuesta],[fechaPeticion],[id],[idAdmin],[idEstadoPeticiones],[idTipoPeticiones],[idTipoRespuesta],[Respuesta]) " +
            "VALUES (@ACTIVA,'@DESCRIPCION','@FECHARESPUESTA','@FECHAPETICION',@ID,@IDADMIN,@IDESTADOPETICIONES,@IDTIPOPETICIONES,@IDTIPORESPUESTA,'@RESPUESTA')";

        internal const String INSERT_USUARIO = "INSERT INTO [dbo].[usuarios] ([contrasena],[correo],[documento],[estado],[idRol],[idTipoDocumento],[nombre],[telefono],[usuarioSystem]) " +
            "VALUES ('@CONTRASENA','@CORREO',@DOCUMENTO,@ESTADO,@IDROL,@IDTIPODOCUMENTO,'@NOMBRE',@TELEFONO,'@USUARIOSYSTEM')";

        internal const String SELECT_ALL_PETICIONES = "SELECT [idTipoPeticiones],[Activa],[Descripcion],[fechaPeticion],[fechaRespuesta],[id],[idAdmin]," +
            "[idEstadoPeticiones],[idTipoRespuesta],[Respuesta] FROM [dbo].[peticiones]";

        internal const String SELECT_ALL_USUARIOS = "SELECT [contrasena],[correo],[documento],[estado],[id]," +
            "[idRol],[idTipoDocumento],[nombre],[telefono],[usuarioSystem] FROM [dbo].[usuarios]";

        internal const String SELECT_PETICIONES_BY_IDPETICION = "SELECT [idTipoPeticiones],[Activa],[Descripcion],[fechaPeticion],[fechaRespuesta],[id]," +
            "[idAdmin],[idEstadoPeticiones],[idTipoRespuesta],[Respuesta] FROM [dbo].[peticiones] WHERE [idPeticion] = @IDPETICION";

        internal const String SELECT_USUARIO_BY_ID = "SELECT [contrasena],[correo],[documento],[estado],[id]," +
            "[idRol],[idTipoDocumento],[nombre],[telefono],[usuarioSystem] FROM [dbo].[usuarios] WHERE [id] = @ID";

        internal const String UPDATE_PETICION = "UPDATE [dbo].[peticiones] SET [Activa] = @ACTIVA,[Descripcion] = '@DESCRIPCION',[fechaRespuesta] = '@FECHARESPUESTA',[fechaPeticion] = '@FECHAPETICION',[id] = @ID,[idAdmin] = @IDADMIN," +
            "[idEstadoPeticiones] = @IDESTADOPETICIONES,[idTipoPeticiones] = @IDTIPOPETICIONES,[idTipoRespuesta] = @IDTIPORESPUESTA,[Respuesta] = '@RESPUESTA' WHERE [idPeticion] = @IDPETICION";

        internal const String UPDATE_USUARIO = "UPDATE [dbo].[usuarios] SET [contrasena]='@CONTRASENA',[correo]='@CORREO',[documento]=@DOCUMENTO,[estado]=@ESTADO," +
            "[idRol]=@IDROL,[idTipoDocumento]=@IDTIPODOCUMENTO,[nombre]='@NOMBRE',[telefono]=@TELEFONO,[usuarioSystem]='@USUARIOSYSTEM' WHERE [id] = @ID";
    }
}