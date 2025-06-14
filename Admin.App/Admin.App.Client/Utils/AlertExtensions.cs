using Admin.Shared.Response;
using MudBlazor;

namespace Admin.App.Client.Utils;

public static class AlertExtensions
{
    public static async Task<T?> HandleResponseAsync<T>(
        this Task<Response<T>> responseTask, 
        ISnackbar snackbar)
    {
        try
        {
            var response = await responseTask;
            if (!string.IsNullOrEmpty(response.Message))
            {
                snackbar.Add($"{response.Message}", response.IsSuccess ? Severity.Success : Severity.Error);
            }
            return response.Data;
        }
        catch (Exception ex)
        {
            snackbar.Add($"{ex.Message}", Severity.Error);
            var response =await responseTask;
            return response.Data;
        }
    }
}