namespace Custo0.Utils
{
    public class Cripto
    {
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public static bool CompararSenha(string senhaLogin, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaLogin, senhaBanco);
        }
    }
}
