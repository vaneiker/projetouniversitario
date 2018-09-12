using System.Collections.Generic;
using Entity.UnderWriting.Entities;

namespace DI.UnderWriting.Interfaces
{
    public interface INote
    {
        IEnumerable<Note> GetAll(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
         , int officeId, int caseSeqNo, int histSeqNo);
        IEnumerable<Note> GetAllComment(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
          , int officeId, int caseSeqNo, int histSeqNo, int noteId);

        Note Insert(Note note);
        int InsertComment(Note comment);
        int InsertParticipant(Note participant);
        int InsertParticipant(IEnumerable<Note> participants);

        IEnumerable<Note> GetTeamCommunicationHeader(Note note);
        IEnumerable<Note> GetTeamCommunicationThread(Note note);
        IEnumerable<Note> GetTeamCommunicationParticipant(Note note);
    }
}
