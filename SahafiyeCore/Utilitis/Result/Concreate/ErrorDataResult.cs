namespace SahafiyeCore.Utilitis.Result.Concreate
{
    public  class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(T data,string message,string kod):base(data,message,false,kod)
        {
            
        }
        public ErrorDataResult(T data, string message) : base(data, message, false)
        {

        }
        public ErrorDataResult( T data) : base(data,false)
        {

        }
    }
}
