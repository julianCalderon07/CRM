namespace CRM.Utilities
{
    internal static class Sentences
    {
        internal const String SELECT_ALL_USUARIOS = "SELECT [contrasena],[correo],[documento],[estado],[id]," +
            "[idRol],[idTipoDocumento],[nombre],[telefono],[usuarioSystem] FROM [dbo].[usuarios]";

        internal const String SELECT_USUARIO_BY_ID = "SELECT [contrasena],[correo],[documento],[estado],[id]," +
            "[idRol],[idTipoDocumento],[nombre],[telefono],[usuarioSystem] FROM [dbo].[usuarios] WHERE id = @ID";
    }
}