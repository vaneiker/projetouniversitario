using System;
using System.Collections.Generic;
using DI.UnderWriting.Interfaces;
using Entity.UnderWriting.Entities;
using LOGIC.UnderWriting.Global;

namespace DI.UnderWriting.Implementations
{
    public class NoteBll : INote
    {
        private NoteManager _noteManager;

        public NoteBll()
        {
            _noteManager = new NoteManager();
        }

        IEnumerable<Note> INote.GetAll(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo)
        {
            return
                 _noteManager.GetAll(coprId, regionId, countryId, domesticRegId, stateProvId, cityId, officeId, caseSeqNo, histSeqNo);
        }

        IEnumerable<Note> INote.GetAllComment(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int noteId)
        {
            return
                  _noteManager.GetAllComment(coprId, regionId, countryId, domesticRegId, stateProvId, cityId, officeId, caseSeqNo, histSeqNo, noteId);
        }

        Note INote.Insert(Note note)
        {
            return
               _noteManager.Insert(note);
        }

        int INote.InsertComment(Note comment)
        {
            return
                 _noteManager.InsertComment(comment);
        }

        int INote.InsertParticipant(Note participant)
        {
            return
                 _noteManager.InsertParticipant(participant);
        }

        int INote.InsertParticipant(IEnumerable<Note> participants)
        {
            return
                 _noteManager.InsertParticipant(participants);
        }

        IEnumerable<Note> INote.GetTeamCommunicationHeader(Note note)
        {
            return
                _noteManager.GetTeamCommunicationHeader(note);
        }

        IEnumerable<Note> INote.GetTeamCommunicationThread(Note note)
        {
            return
                _noteManager.GetTeamCommunicationThread(note);
        }

        IEnumerable<Note> INote.GetTeamCommunicationParticipant(Note note)
        {
            return
                _noteManager.GetTeamCommunicationParticipant(note);
        }
    }
    public class NoteWS : INote
    {
        IEnumerable<Note> INote.GetAll(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Note> INote.GetAllComment(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int noteId)
        {
            throw new NotImplementedException();
        }

        Note INote.Insert(Note note)
        {
            throw new NotImplementedException();
        }

        int INote.InsertComment(Note comment)
        {
            throw new NotImplementedException();
        }

        int INote.InsertParticipant(Note participant)
        {
            throw new NotImplementedException();
        }

        int INote.InsertParticipant(IEnumerable<Note> participants)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Note> INote.GetTeamCommunicationHeader(Note note)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Note> INote.GetTeamCommunicationThread(Note note)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Note> INote.GetTeamCommunicationParticipant(Note note)
        {
            throw new NotImplementedException();
        }
    }
}
