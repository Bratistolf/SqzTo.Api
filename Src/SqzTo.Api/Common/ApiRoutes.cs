namespace SqzTo.Api.Common
{
    /// <summary>
    /// Contains all API routes in project.
    /// </summary>
    public static class ApiRoutes
    {
        /// <summary>
        /// Route for POST: v1.0/sqzlink/
        /// </summary>
        public const string CreateSqzLink           = "sqzlink";

        /// <summary>
        /// Route for POST: v1.0/sqzlink/bulk
        /// </summary>
        public const string BulkCreateSqzLink       = "sqzlink/bulk";

        /// <summary>
        /// Route for GET: v1.0/sqzlink/{sqzlink}
        /// </summary>
        public const string NavigateSqzLink         = "sqzlink/{sqzlink}";

        /// <summary>
        /// Route for PATCH: v1.0/sqzlink/{sqzlink}
        /// </summary>
        public const string EditSqzLink             = "sqzlink/{sqzlink}";

        /// <summary>
        /// Route for GET: v1.0/sqzlink/{sqzlink}/details
        /// </summary>
        public const string GetSqzLinkDetails        = "sqzlink/{sqzlink}/details";

        /// <summary>
        /// Route for GET: v1.0/sqzlink/{sqzlink}/clicks
        /// </summary>
        public const string GetSqzLinkClicks         = "sqzlink/{sqzlink}/clicks";

        /// <summary>
        /// Route for GET: v1.0/sqzlink/{sqzlink}/qr
        /// </summary>
        public const string GetSqzLinkQr             = "sqzlink/{sqzlink}/qr";
    }
}
