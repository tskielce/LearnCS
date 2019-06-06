namespace Common
{
    public class Parameters
    {
        public string ConnectionStringMsSql { get; set; }
        public string ConnectionStringMySql { get; set; }
        public string path { get; set; }
        public string fileName { get; set; }
        public enum fileType { txt, csv };
    }
}

