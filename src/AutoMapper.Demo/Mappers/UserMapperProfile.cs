namespace AutoMapper.Demo.Mappers
{
    /// <summary>
    /// UserMapperProfile
    /// </summary>
    public class UserMapperProfile : Profile
    {
        /// <summary>
        /// <see cref="UserMapperProfile"/>
        /// </summary>
        public UserMapperProfile()
        {
            CreateMap<Dtos.User, Entities.User>().ReverseMap();
        }
    }
}
