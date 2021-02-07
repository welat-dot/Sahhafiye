using SahafiyeCore.Utilitis.Result.Abstract;

namespace SahafiyeCore.Utilitis.Result.Concreate
{
    public class Result : IResult
    {
        public Result(bool success, string message) : this(success)
        {
            this.message = message;
        }
        public Result(bool success, string message,string kod) : this(success)
        {
            this.message = message;
            this.kod = kod;
        }
        public Result(bool success)
        {
            this.success = success;
        }
        public bool success { get; }
        public string message { get; set; }

        public string kod { get; set; }
    }
}
