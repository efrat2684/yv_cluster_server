public class SapirClusterModel
{
    public List<BookIdDetails> BookIdList { get; set; }
    //public List<SapirClusterDetail> SapirClusterDetails { get; set; }
    public string Comments { get; set; }
    public string Level { get; set; }
    public bool GroupHasMultimedia { get; set; }
    public string? GroupId { get; set; }
    public int StatusCode { get; set; }
}