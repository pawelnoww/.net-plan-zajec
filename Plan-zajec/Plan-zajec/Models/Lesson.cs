namespace Plan_zajec.Models;

public class Lesson
{
    public int ID { get; set; }
    public int GroupID { get; set; }
    public string Name { get; set; }
    public int LecturerID { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}