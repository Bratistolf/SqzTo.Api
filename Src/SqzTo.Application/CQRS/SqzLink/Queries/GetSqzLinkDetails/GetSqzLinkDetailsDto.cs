namespace SqzTo.Application.CQRS.SqzLink.Queries.GetSqzLinkDetails
{
    public class GetSqzLinkDetailsDto
    {
        public string Link { get; set; }

        public string Url { get; set; }

        public int Clicks { get; set; }

        public string Created { get; set; }
    }
}
