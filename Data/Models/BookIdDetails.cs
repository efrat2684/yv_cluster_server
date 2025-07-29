<<<<<<< HEAD
public class BookIdDetails
{
    public string BookId { get; set; }
    public string ClusterId { get; set; }
=======
using static System.Formats.Asn1.AsnWriter;
using System.Net;

public class BookIdDetails
{
    public string BookId { get; set; }
>>>>>>> origin/main
    public ValueCodeItem FirstName { get; set; }
    public ValueCodeItem LastName { get; set; }
    public ValueCodeItem FatherFirstName { get; set; }
    public ValueCodeItem MotherFirstName { get; set; }
<<<<<<< HEAD
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
=======
    public ValueCodeItem PlaceOfBirth { get; set; }
    public ValueCodeItem PermanentPlace { get; set; }
    public ValueCodeItem DateOfBirth { get; set; }
    public ValueCodeItem Source { get; set; }
    public ValueCodeItem SpouseFirstName { get; set; }
    public string MaidenName { get; set; }
    public int IsClustered { get; set; }
    public string ExistsClusterId { get; set; }
    public object RelatedFnameGroupId { get; set; }
    public bool IsHasRelatedFname { get; set; }
    public int Ind { get; set; }
    public bool HasRelatedGroups { get; set; }
    public string Score { get; set; }
    public int NumberOfSuggestions { get; set; }
    public object RelatedFnameList { get; set; }

    //public BookIdDetails(
    //    string bookId,
    //    ValueCodeItem firstName,
    //    ValueCodeItem lastName,
    //    ValueCodeItem fatherFirstName,
    //    ValueCodeItem motherFirstName,
    //    ValueCodeItem placeOfBirth,
    //    ValueCodeItem permanentPlace,
    //    ValueCodeItem dateOfBirth,
    //    ValueCodeItem source,
    //    ValueCodeItem spouseFirstName,
    //    string maidenName,
    //    int isClustered,
    //    string existsClusterId,
    //    object relatedFnameGroupId,
    //    bool isHasRelatedFname,
    //    int ind,
    //    bool hasRelatedGroups,
    //    string score,
    //    int numberOfSuggestions,
    //    object relatedFnameList)
    //{
    //    BookId = bookId;
    //    FirstName = firstName;
    //    LastName = lastName;
    //    FatherFirstName = fatherFirstName;
    //    MotherFirstName = motherFirstName;
    //    PlaceOfBirth = placeOfBirth;
    //    PermanentPlace = permanentPlace;
    //    DateOfBirth = dateOfBirth;
    //    Source = source;
    //    SpouseFirstName = spouseFirstName;
    //    MaidenName = maidenName;
    //    IsClustered = isClustered;
    //    ExistsClusterId = existsClusterId;
    //    RelatedFnameGroupId = relatedFnameGroupId;
    //    IsHasRelatedFname = isHasRelatedFname;
    //    Ind = ind;
    //    HasRelatedGroups = hasRelatedGroups;
    //    Score = score;
    //    NumberOfSuggestions = numberOfSuggestions;
    //    RelatedFnameList = relatedFnameList;
    //}
}
>>>>>>> origin/main
