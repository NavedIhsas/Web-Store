namespace Application.Common;

public class ResultDto
{
    public string Message { get; set; }
    public bool IsSucceeded { get; set; }

    public ResultDto Succeeded(string message = "عملیات با موفقیت انجام شد")
    {
        IsSucceeded = true;
        Message = message;
        return this;
    }

    public ResultDto Failed(string message)
    {
        IsSucceeded = false;
        Message = message;
        return this;
    }
}

public class ResultDto<T>
{
    public string Message { get; set; }
    public bool IsSucceeded { get; set; }
    public T Data { get; set; }

    public ResultDto<T> Succeeded(ResultDto<InvoiceStatus> date, string message = "عملیات با موفقیت انجام شد")
    {
        IsSucceeded = true;
        Message = message;
        Data = date;
        return this;
    }

    public ResultDto<T> Failed(string message)
    {
        IsSucceeded = false;
        Message = message;
        return this;
    }
}