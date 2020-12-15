using SahafiyeCore.Utilitis.Result.Abstract;

namespace SahafiyeCore.Utilitis.Result.Concreate
{
    public class DataResult<T>:Result,IDataResult<T>
    {
        public DataResult(T Data,string message,bool success,string kod):base(success,message)
        {
            this.Data = Data;
            this.kod = kod;
        }
        public DataResult(T Data, string message, bool success) : base(success, message)
        {
            this.Data = Data;
           
        }
        public DataResult( string message, bool success,string kod) : base(success, message)
        {
            this.kod = kod;
        }
        public DataResult(string message, bool success) : base(success, message)
        {
            
        }
        public DataResult(T Data, bool success) : base(success)
        {
            this.Data = Data;
        }
        public T Data { get; }
        public string kod { get; }

    }
}
