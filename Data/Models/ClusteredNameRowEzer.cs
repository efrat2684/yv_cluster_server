using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    internal class ClusteredNameRowEzer
    {
        public string BookId { get; set; }
        public string ClusterId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string SpouseFirstName { get; set; }
        public string DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string PermanentPlace { get; set; }
        public string Source { get; set; }
        public string PlaceOfDeath { get; set; }
        public string AuthenticDateOfBirth { get; set; }
        public string RestoredDateOfBirth { get; set; }
        public string AuthenticDateOfDeath { get; set; }
        public string RestoredDateOfDeath { get; set; }
        public string Gender { get; set; }
        public string Fate { get; set; }
        public string FirstNameCode { get; set; }
        public string FatherNameCode { get; set; }
        public string LastNameCode { get; set; }
        public string MotherNameCode { get; set; }
        public string SpouseFirstNameCode { get; set; }
        public string DateOfBirthCode { get; set; }
        public string PlaceOfBirthCode { get; set; }
        public string PermanentPlaceCode { get; set; }
        public string SourceCode { get; set; }
        public string MaidenName { get; set; }
        public int IsClustered { get; set; }
        public string ExistsClusterId { get; set; }
        public bool RelatedFnameGroupId { get; set; }
        public int Ind { get; set; }
        public bool HasRelatedGroups { get; set; }
        public int NumberOfSuggestions { get; set; }
        public bool RelatedFnameList { get; set; }
    }
}