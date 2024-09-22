namespace TDD_CSharp.Sources.RetweetCollection;

public class Tweet
{
    private const string NullUser = " ";
    public  string Message { get; }
    public  string User { get; }

    public Tweet()
    {
        
    }
    public Tweet(string message, string user = NullUser)
    {
        if (!IsValid(user))
        {
            throw new ArgumentException("Invalid user: User must start with '@'.");
        }
        Message = message;
        User = user;
    }

    private bool IsValid(string user)
    {
        return user.StartsWith("@");
    }
}