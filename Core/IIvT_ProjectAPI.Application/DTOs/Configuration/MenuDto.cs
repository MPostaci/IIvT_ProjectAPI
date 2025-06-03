namespace IIvT_ProjectAPI.Application.DTOs.Configuration
{
    public class MenuDto
    {
        public string MenuName { get; set; }
        public List<ActionDto> Actions { get; set; } = new();
    }
}
