using System.Collections.Generic;
using System.Linq;
using DATA.UnderWriting.Data;
using DATA.UnderWriting.Repositories.Base;
using Entity.UnderWriting.Entities;

namespace DATA.UnderWriting.Repositories.Global
{
    public class NoteRepository : GlobalRepository
    {
        public NoteRepository(GlobalEntityDataModel globalModel, GlobalEntities globalModelExtended) : base(globalModel, globalModelExtended) { }

        public virtual IEnumerable<Note> GetAll(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo)
        {
            IEnumerable<Note> result;
            IEnumerable<SP_GET_PL_PCY_NOTES_Result> temp;

            temp = globalModel.SP_GET_PL_PCY_NOTES(coprId, regionId, countryId, domesticRegId, stateProvId, cityId, officeId, caseSeqNo, histSeqNo);

            result = temp
                .Select(n => new Note
                {
                    CorpId = n.Corp_Id,
                    RegionId = n.Region_Id,
                    CountryId = n.Country_Id,
                    DomesticregId = n.Domesticreg_Id,
                    StateProvId = n.State_Prov_Id,
                    CityId = n.City_Id,
                    OfficeId = n.Office_Id,
                    CaseSeqNo = n.Case_Seq_No,
                    HistSeqNo = n.Hist_Seq_No,
                    NoteId = n.Note_Id,
                    ReferenceTypeId = n.Reference_Type_Id,
                    NoteReferenceTypeDesc = n.Note_Reference_Type_Desc,
                    NoteName = n.Note_Name,
                    OriginatedById = n.Originated_By_Id,
                    OriginatedByName = n.Originated_By_Name,
                    NoteBody = n.Note,
                    DateAdded = n.Date_Added,
                    DateModified = n.Date_Modified
                })
                .ToArray();

            return
                result;
        }
        
        public virtual IEnumerable<Note> GetAllComment(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo, int noteId)
        {
            IEnumerable<Note> result;
            IEnumerable<SP_GET_PL_PCY_NOTE_COMMENTS_Result> temp;

            temp = globalModel.SP_GET_PL_PCY_NOTE_COMMENTS(coprId, regionId, countryId, domesticRegId, stateProvId, cityId, officeId, caseSeqNo, histSeqNo, noteId);

            result = temp
                .Select(n => new Note
                {
                    CorpId = n.Corp_Id,
                    RegionId = n.Region_Id,
                    CountryId = n.Country_Id,
                    DomesticregId = n.Domesticreg_Id,
                    StateProvId = n.State_Prov_Id,
                    CityId = n.City_Id,
                    OfficeId = n.Office_Id,
                    CaseSeqNo = n.Case_Seq_No,
                    HistSeqNo = n.Hist_Seq_No,
                    NoteId = n.Note_Id,
                    CommentId = n.Comment_Id,
                    OriginatedById = n.Originated_By_Id,
                    OriginatedByName = n.Originated_By_Name,
                    NoteBody = n.Comments,
                    DateAdded = n.Date_Added,
                    DateModifiedLast = n.Date_Modified_Last,
                    OriginatedByIdLast = n.Originated_By_Id_Last,
                    OriginatedByNameLast = n.Originated_By_Name_Last
                })
                .ToArray();

            return
                result;
        }

        public virtual Note Set(Note note)
        {
            Note result;
            IEnumerable<SP_SET_PL_PCY_NOTES_Result> temp;

            temp = globalModel.SP_SET_PL_PCY_NOTES(
                    note.CorpId,
                    note.RegionId,
                    note.CountryId,
                    note.DomesticregId,
                    note.StateProvId,
                    note.CityId,
                    note.OfficeId,
                    note.CaseSeqNo,
                    note.HistSeqNo,
                    note.NoteId,
                    note.ReferenceTypeId,
                    note.NoteName,
                    note.OriginatedById,
                    note.NoteBody,
                    note.Confidential,
                    note.UserId
                );

            result = temp
                .Select(n => new Note
                {
                    CorpId = n.Corp_Id.ConvertToNoNullable(),
                    RegionId = n.Region_Id.ConvertToNoNullable(),
                    CountryId = n.Country_Id.ConvertToNoNullable(),
                    DomesticregId = n.Domesticreg_Id.ConvertToNoNullable(),
                    StateProvId = n.State_Prov_Id.ConvertToNoNullable(),
                    CityId = n.City_Id.ConvertToNoNullable(),
                    OfficeId = n.Office_Id.ConvertToNoNullable(),
                    CaseSeqNo = n.Case_Seq_No.ConvertToNoNullable(),
                    HistSeqNo = n.Hist_Seq_No.ConvertToNoNullable(),
                    NoteId = n.Note_Id.ConvertToNoNullable()
                })
                .FirstOrDefault();

            return
                result;
        }
        
        public virtual int SetComment(Note comment)
        {
            int result;
            IEnumerable<SP_SET_PL_PCY_NOTE_COMMENTS_Result> temp;

            result = -1;

            temp = globalModel.SP_SET_PL_PCY_NOTE_COMMENTS(
                    comment.CorpId,
                    comment.RegionId,
                    comment.CountryId,
                    comment.DomesticregId,
                    comment.StateProvId,
                    comment.CityId,
                    comment.OfficeId,
                    comment.CaseSeqNo,
                    comment.HistSeqNo,
                    comment.NoteId,
                    comment.CommentId,
                    comment.OriginatedById,
                    comment.Comment,
                    comment.UserId
                );

            return
                result;
        }    

        public virtual int SetParticipant(Note note)
        {
            int result;
            IEnumerable<SP_SET_PL_PCY_NOTE_PARTICIPANT_Result> temp;

            result = -1;

            temp = globalModel.SP_SET_PL_PCY_NOTE_PARTICIPANT(
                    note.CorpId,
                    note.RegionId,
                    note.CountryId,
                    note.DomesticregId,
                    note.StateProvId,
                    note.CityId,
                    note.OfficeId,
                    note.CaseSeqNo,
                    note.HistSeqNo,
                    note.NoteId,
                    note.OriginatedById,
                    note.UserId
                );

            return
                result;
        }

        public virtual IEnumerable<Note> GetTeamCommunicationHeader(Note note)
        {
            IEnumerable<Note> result;
            IEnumerable<SP_GET_PL_PCY_NOTE_TEAM_COMMUNICATION_HEADER_Result> temp;

            temp = globalModel.SP_GET_PL_PCY_NOTE_TEAM_COMMUNICATION_HEADER(
                note.CorpId,
                note.RegionId,
                note.CountryId,
                note.DomesticregId,
                note.StateProvId,
                note.CityId,
                note.OfficeId,
                note.CaseSeqNo,
                note.HistSeqNo,
                note.OriginatedById);

            result = temp
                .Select(n => new Note
                {
                    CorpId = n.Corp_Id,
                    RegionId = n.Region_Id,
                    CountryId = n.Country_Id,
                    DomesticregId = n.Domesticreg_Id,
                    StateProvId = n.State_Prov_Id,
                    CityId = n.City_Id,
                    OfficeId = n.Office_Id,
                    CaseSeqNo = n.Case_Seq_No,
                    HistSeqNo = n.Hist_Seq_No,
                    NoteId = n.Note_Id,
                    Confidential = n.Confidential,
                    NoteName = n.Note_Name,
                    DateAdded = n.DateStarted,
                    DateModified = n.DateLastReply
                })
                .ToArray();

            return
                result;
        }
        
        public virtual IEnumerable<Note> GetTeamCommunicationThread(Note note)
        {
            IEnumerable<Note> result;
            IEnumerable<SP_GET_PL_PCY_NOTE_TEAM_COMMUNICATION_THREAD_Result> temp;

            temp = globalModel.SP_GET_PL_PCY_NOTE_TEAM_COMMUNICATION_THREAD(
                note.CorpId,
                note.RegionId,
                note.CountryId,
                note.DomesticregId,
                note.StateProvId,
                note.CityId,
                note.OfficeId,
                note.CaseSeqNo,
                note.HistSeqNo,
                note.NoteId);

            result = temp
                .Select(n => new Note
                {
                    CorpId = n.Corp_Id,
                    RegionId = n.Region_Id,
                    CountryId = n.Country_Id,
                    DomesticregId = n.Domesticreg_Id,
                    StateProvId = n.State_Prov_Id,
                    CityId = n.City_Id,
                    OfficeId = n.Office_Id,
                    CaseSeqNo = n.Case_Seq_No,
                    HistSeqNo = n.Hist_Seq_No,
                    NoteId = n.Note_Id,
                    CommentId = n.Comment_Id,
                    NoteBody = n.Note,
                    OriginatedById = n.Originated_By_Id,
                    OriginatedByName = n.OriginatedByName,
                    DateAdded = n.DateAdded
                })
                .ToArray();

            return
                result;
        }
        
        public virtual IEnumerable<Note> GetTeamCommunicationParticipant(Note note)
        {
            IEnumerable<Note> result;
            IEnumerable<SP_GET_PL_PCY_NOTE_PARTICIPANT_Result> temp;

            temp = globalModel.SP_GET_PL_PCY_NOTE_PARTICIPANT(
                note.CorpId,
                note.RegionId,
                note.CountryId,
                note.DomesticregId,
                note.StateProvId,
                note.CityId,
                note.OfficeId,
                note.CaseSeqNo,
                note.HistSeqNo,
                note.NoteId);

            result = temp
                .Select(n => new Note
                {
                    CorpId = n.Corp_Id,
                    RegionId = n.Region_Id,
                    CountryId = n.Country_Id,
                    DomesticregId = n.Domesticreg_Id,
                    StateProvId = n.State_Prov_Id,
                    CityId = n.City_Id,
                    OfficeId = n.Office_Id,
                    CaseSeqNo = n.Case_Seq_No,
                    HistSeqNo = n.Hist_Seq_No,
                    NoteId = n.Note_Id,
                    OriginatedById = n.Participant_Id,
                    OriginatedByName = n.OriginatedByName
                })
                .ToArray();

            return
                result;
        }

    }
}
