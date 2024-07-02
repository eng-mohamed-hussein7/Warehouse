namespace DomainLayer.Models.DismissalNotice
{
    public class DismissalNoticeHeader : GeneralEntity
    {
        public string Destination { get; set; }
        public string Number { get; set; }
        public string Notes { get; set; }
        public virtual List<DismissalNoticeDetail> DismissalNoticeDetails { get; set; }
    }
}