namespace MTODotNetTrainingBatch1.WebApplication1.Models
{
    public class Product
    {
        public int? No { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreatedDateTime { get; set; }   
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int?  UpdatedBy { get; set; }
        public int? CategoryId { get; set; }
    }

}
