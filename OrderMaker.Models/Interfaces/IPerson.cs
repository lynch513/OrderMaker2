namespace OrderMaker.Models.Interfaces
{
    public interface IPerson
    {
        string Name { get; set; }
        string AdditionalName { get; set; }
        GroupType Group { get; set; }
        string Speciality { get; set; }
        PostType[] Posts { get; set; }
    }
}