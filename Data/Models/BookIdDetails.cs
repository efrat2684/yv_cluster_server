public class BookIdDetails
{
    public string BookId { get; set; }
    public string ClusterId { get; set; }
    public ValueCodeItem FirstName { get; set; }
    public ValueCodeItem LastName { get; set; }
    public ValueCodeItem FatherFirstName { get; set; }
    public ValueCodeItem MotherFirstName { get; set; }
    public ValueCodeItem SpouseFirstName { get; set; }
    public string MaidenName { get; set; }
    public ValueCodeItem DateOfBirth { get; set; }
    public ValueCodeItem PlaceOfBirth { get; set; }
    public ValueCodeItem PermanentPlace { get; set; }
    public ValueCodeItem Source { get; set; }
    public ValueCodeItem PlaceOfDeath { get; set; }
    public ValueCodeItem AuthenticDateOfBirth { get; set; }
    public ValueCodeItem RestoredDateOfBirth { get; set; }
    public ValueCodeItem AuthenticDateOfDeath { get; set; }
    public ValueCodeItem RestoredDateOfDeath { get; set; }
    public ValueCodeItem Gender { get; set; }
    public ValueCodeItem Fate { get; set; }
    public int IsClustered { get; set; }
    public string ExistsClusterId { get; set; }
    public object RelatedFnameGroupId { get; set; }
    public int Ind { get; set; }
    public bool HasRelatedGroups { get; set; }
    public int NumberOfSuggestions { get; set; }
    public object RelatedFnameList { get; set; }
    public bool IsHasRelatedFname { get; set; }
    public string Score { get; set; }
}
