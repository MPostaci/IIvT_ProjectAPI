namespace IIvT_ProjectAPI.Application.DTOs.Category
{
    public class ListCategoryDto
    {
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EnumDto ContentType { get; set; }
    }
}
