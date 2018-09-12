using System;
using System.Collections.Generic;
using DATA.UnderWriting.Repositories.Global;
using DATA.UnderWriting.UnitOfWork;
using Entity.UnderWriting.Entities;
using LOGIC.UnderWriting.Common;
using System.Linq;

namespace LOGIC.UnderWriting.Global
{
    public class NoteManager
    {
        private NoteRepository _noteRepository;

        public NoteManager()
        {
            _noteRepository = SingletonUnitOfWork.Instance.NoteRepository;
        }

        public virtual IEnumerable<Note> GetAll(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
           , int officeId, int caseSeqNo, int histSeqNo)
        {
            return
                _noteRepository.GetAll(coprId, regionId, countryId, domesticRegId, stateProvId, cityId, officeId, caseSeqNo, histSeqNo);
        }
        public virtual IEnumerable<Note> GetAllComment(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
           , int officeId, int caseSeqNo, int histSeqNo, int noteId)
        {
            return
                _noteRepository.GetAllComment(coprId, regionId, countryId, domesticRegId, stateProvId, cityId, officeId, caseSeqNo, histSeqNo, noteId);
        }

        public virtual Note Insert(Note note)
        {
            this.IsValid(note, Utility.DataBaseActionType.Insert);

            note.NoteId = -1;

            return
                _noteRepository.Set(note);
        }
        public virtual int InsertComment(Note comment)
        {
            this.IsValid(comment, Utility.DataBaseActionType.Update);

            comment.CommentId = -1;

            return
                _noteRepository.SetComment(comment);
        }
        public virtual int InsertParticipant(Note participant)
        {
            return
                this.SetParticipant(participant);
        }
        public virtual int InsertParticipant(IEnumerable<Note> participants)
        {
            int result;

            result = -1;

            if (participants != null && participants.Any())
                foreach (Note participant in participants)
                    result = this.SetParticipant(participant);

            return
                result;

        }

        public virtual IEnumerable<Note> GetTeamCommunicationHeader(Note note)
        {
            return
                _noteRepository.GetTeamCommunicationHeader(note);
        }
        public virtual IEnumerable<Note> GetTeamCommunicationThread(Note note)
        {
            return
                _noteRepository.GetTeamCommunicationThread(note);
        }
        public virtual IEnumerable<Note> GetTeamCommunicationParticipant(Note note)
        {
            return
                _noteRepository.GetTeamCommunicationParticipant(note);
        }

        private int SetParticipant(Note participant)
        {
            this.IsValid(participant, Utility.DataBaseActionType.Update);

            return
                _noteRepository.SetParticipant(participant);
        }
        private void IsValid(Note note, Utility.DataBaseActionType action)
        {
            bool checkUserId;

            if (note.CorpId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CorpId");
            if (note.RegionId <= 0)
                throw new ArgumentException("This property can't be under 0.", "RegionId");
            if (note.CountryId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CountryId");
            if (note.DomesticregId <= 0)
                throw new ArgumentException("This property can't be under 0.", "DomesticregId");
            if (note.StateProvId <= 0)
                throw new ArgumentException("This property can't be under 0.", "StateProvId");
            if (note.CityId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CityId");
            if (note.OfficeId <= 0)
                throw new ArgumentException("This property can't be under 0.", "OfficeId");
            if (note.CaseSeqNo <= 0)
                throw new ArgumentException("This property can't be under 0.", "CaseSeqNo");

            checkUserId = false;

            switch (action)
            {
                case Utility.DataBaseActionType.Update:
                case Utility.DataBaseActionType.Delete:
                    checkUserId = true;
                    if (note.NoteId <= 0)
                        throw new ArgumentException("This property can't be under 0.", "NoteId");
                    break;
                case Utility.DataBaseActionType.Insert:
                    checkUserId = true;
                    break;
                case Utility.DataBaseActionType.Select:
                default:
                    break;
            }

            if (checkUserId && note.UserId <= 0)
                throw new ArgumentException("This property can't be under 0.", "UserId");
            if (checkUserId && note.OriginatedById <= 0)
                throw new ArgumentException("This property can't be under 0.", "OriginatedById");
        }
    }
}
