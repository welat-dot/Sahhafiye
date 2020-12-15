namespace SahafiyeCore.Utilitis.Result.Abstract
{
    public interface IResult
    {
        bool success { get; }
        string message { get; }
        string kod { get; }
    }
}
