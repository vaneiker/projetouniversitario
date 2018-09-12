using System;

namespace Entity.UnderWriting.Entities
{
    public class Note
    {
        public int CorpId { get; set; }
        public int RegionId { get; set; }
        public int CountryId { get; set; }
        public int DomesticregId { get; set; }
        public int StateProvId { get; set; }
        public int CityId { get; set; }
        public int OfficeId { get; set; }
        public int CaseSeqNo { get; set; }
        public int HistSeqNo { get; set; }
        public int NoteId { get; set; }
        public int? CommentId { get; set; }        
        public int ReferenceTypeId { get; set; }
        public string NoteReferenceTypeDesc { get; set; }
        public string NoteName { get; set; }
        public int OriginatedById { get; set; }
        public string OriginatedByName { get; set; }
        public string NoteBody { get; set; }
        public string Comment { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
        public int UserId { get; set; }
        public DateTime? DateModifiedLast { get; set; }
        public int? OriginatedByIdLast { get; set; }
        public string OriginatedByNameLast { get; set; }
        public bool Confidential { get; set; }
        
    }
}
