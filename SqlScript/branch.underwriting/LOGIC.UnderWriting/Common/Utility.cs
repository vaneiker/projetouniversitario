
namespace LOGIC.UnderWriting.Common
{
    public static class Utility
    {
        public enum DataBaseActionType
        {
            Select,
            Update,
            Insert,
            Delete
        }

        public static string FullName(string firstName, string middleName, string firstLastName, string secondLastName)
        {
            string result, temp;

            temp =
                  (!string.IsNullOrWhiteSpace(firstName) ? firstName.Trim() + " " : string.Empty)
                + (!string.IsNullOrWhiteSpace(middleName) ? middleName.Trim() + " " : string.Empty)
                + (!string.IsNullOrWhiteSpace(firstLastName) ? firstLastName.Trim() + " " : string.Empty)
                + (!string.IsNullOrWhiteSpace(secondLastName) ? secondLastName.Trim() : string.Empty);

            result = temp.Trim();

            return
                result;
        }
    }
}
