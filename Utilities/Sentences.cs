namespace CRM.Utilities
{
    internal static class Sentences
    {
        internal const String DELETE_USUARIO = "DELETE FROM [dbo].[usuarios] WHERE [id] = @ID";

        internal const String INSERT_USUARIO = "INSERT INTO [dbo].[usuarios] ([contrasena],[correo],[documento],[estado],[id],[idRol],[idTipoDocumento],[nombre],[telefono],[usuarioSystem])" +
            "VALUES (@CONTRASENA,@CORREO,@DOCUMENTO,@ESTADO,@ID,@IDROL,@IDTIPODOCUMENTO,@NOMBRE,@TELEFONO,@USUARIOSYSTEM)";

        internal const String SELECT_ALL_USUARIOS = "SELECT [contrasena],[correo],[documento],[estado],[id]," +
                    "[idRol],[idTipoDocumento],[nombre],[telefono],[usuarioSystem] FROM [dbo].[usuarios]";

        internal const String SELECT_USUARIO_BY_ID = "SELECT [contrasena],[correo],[documento],[estado],[id]," +
            "[idRol],[idTipoDocumento],[nombre],[telefono],[usuarioSystem] FROM [dbo].[usuarios] WHERE [id] = @ID";

        internal const String UPDATE_USUARIO = "UPDATE [dbo].[usuarios] SET [contrasena]=@CONTRASENA,[correo]=@CORREO,[documento]=@DOCUMENTO,[estado]=@ESTADO," +
            "[idRol]=@IDROL,[idTipoDocumento]=@IDTIPODOCUMENTO,[nombre]=@NOMBRE,[telefono]=@TELEFONO,[usuarioSystem]=@USUARIOSYSTEM WHERE [id] = @ID";
    }
}