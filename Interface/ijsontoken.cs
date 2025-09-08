namespace MyApiProject.Interface;

public interface IJsonToken
{
    string CreateToken( Guid id, string Username, string Email);
    Guid VerifyToken(string id);
}
