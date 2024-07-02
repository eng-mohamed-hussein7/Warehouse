namespace BusinessLogicLayer.DTO
{
    public class DismissalNoticeDTO
    {
        public int Id { get; set; }
        public string Destination { get; set; }
        public string Number { get; set; }
        public string Notes { get; set; }

        public List<DismissalNoticeDetailDTO> DismissalNoticeDetailDTOs { get; set; }
    }

    public class DismissalNoticeDetailDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int Product_ID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string Notes { get; set; }
        public int DismissalNoticeHead_ID { get; set; }

    }
}
