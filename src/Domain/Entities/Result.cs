namespace Domain.Entities
{
    public record struct Result
    {
        public bool IsSuccess { get; set; }
        public string Errors { get; set; }
    }
}