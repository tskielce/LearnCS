namespace Common
{
    public static class HelperStaticMethods
    {
        public static bool CanVariableParseToInt(string data)
        {
            if (int.TryParse(data, out int parsed))
            {
                return true;
            }

            return false;
        }

    }
}
