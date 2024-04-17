using Microsoft.AspNetCore.Mvc;

namespace ProductsAPI.Helpers;

public static class ApiErrorMessages
{
    public static ProblemDetails NotFound()
        => new() { Title = "Resource not found", Status = StatusCodes.Status404NotFound };
}