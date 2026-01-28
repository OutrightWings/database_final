public class UserDocument
    {
        public int Id { get; set; }
        public string Filename { get; set; } = "";
        public string FilePath { get; set; } = "";
        public DateTime UploadedAt { get; set; }
    }
