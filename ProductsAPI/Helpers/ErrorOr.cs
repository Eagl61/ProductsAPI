using Microsoft.AspNetCore.Mvc;

namespace ProductsAPI.Helpers;

public class ErrorOr<T>
{
    public T? Data { get; init; }
    public ProblemDetails? Problem { get; init; }

    private ErrorOr()
    {
    }

    public static ErrorOr<T> Ok(T data) => new() { Data = data };

    public static ErrorOr<T> Error(ProblemDetails error) => new() { Problem = error };

    public static implicit operator ErrorOr<T>(T data) => Ok(data);

    public static implicit operator ErrorOr<T>(ProblemDetails error) => Error(error);

    public bool IsError => Problem is not null;
}