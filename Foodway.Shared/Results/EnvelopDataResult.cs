namespace Foodway.Shared.Results;

public class EnvelopDataResult<T> : EnvelopResult
{
    public T? Data { get; private set; }

    public static EnvelopDataResult<T> Ok(T data)
    {
        return new EnvelopDataResult<T>
        {
            Data = data
        };
    }

    public static EnvelopDataResult<T> Created(T data)
    {
        return new EnvelopDataResult<T>
        {
            Data = data
        };
    }
}