namespace TDD_CSharp.Sources.RetweetCollection;

public class Tweet
{
    private const string NullUser = " ";
    private readonly string _message;
    private readonly string _user;

    public Tweet(string message = "", string user = NullUser)
    {
        _message = message;
        _user = user;

        if (!IsValid(_user))
        {
            throw new ArgumentException("Invalid user: User must start with '@'.");
        }
    }

    private bool IsValid(string user)
    {
        return user.StartsWith("@");
    }
}