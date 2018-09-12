using System;

namespace Entity.UnderWriting.Entities
{
    public class Form
    {
        public class FieldValue
        {
            public int FormId { get; set; }
            public int FormCategoryId { get; set; }
            public int FieldTypeId { get; set; }
            public int? CorpId { get; set; }
            public int? RegionId { get; set; }
            public int? CountryId { get; set; }
            public int? DomesticRegId { get; set; }
            public int? StateProvId { get; set; }
            public int? CityId { get; set; }
            public int? OfficeId { get; set; }
            public int? CaseSeqNo { get; set; }
            public int? HistSeqNo { get; set; }
            public int? FieldId { get; set; }
            public int? ContactId { get; set; }
            public string FormDesc { get; set; }
            public string FieldTypeDesc { get; set; }
            public string HtmlTemplate { get; set; }
            public bool? HasValues { get; set; }
            public string TextValue { get; set; }
            public decimal? NumericValue { get; set; }
            public int? IntegerValue { get; set; }
            public DateTime? DateValue { get; set; }
            public bool? FieldValueStatus { get; set; }
            public string FieldTitle { get; set; }
            public string FormFieldDescription { get; set; }
            public string PdfTemplatePath { get; set; }

            public class Parameter
            {
                public int CorpId { get; set; }
                public int RegionId { get; set; }
                public int CountryId { get; set; }
                public int DomesticRegId { get; set; }
                public int StateProvId { get; set; }
                public int CityId { get; set; }
                public int OfficeId { get; set; }
                public int CaseSeqNo { get; set; }
                public int HistSeqNo { get; set; }
                public int ContactId { get; set; }
                public int FormId { get; set; }
                public int? FieldId { get; set; }
                public int? LanguageId { get; set; }                
            }
        }
    }
}
