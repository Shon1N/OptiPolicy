namespace OptiPolicy.Shared.DataTransferObjects
{
    public class Envelope<TEntity>
    {
        public TEntity Response { get; set; }
        public string Result { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}
