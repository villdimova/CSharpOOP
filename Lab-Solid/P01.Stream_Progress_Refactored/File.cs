namespace P01.Stream_Progress
{
    public class File: IProgressable
    {
        public string Name { get; set; }

        public int Length { get; set; }

        public int BytesSent { get; set; }
    }
}
