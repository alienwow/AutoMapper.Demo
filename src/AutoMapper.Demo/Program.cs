using AutoMapper.Demo.Mappers;
using System;

namespace AutoMapper.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var entityUser = new Entities.User()
            {
                Name = "userEntity",
                Age = 18,
                //Birthdate = new DateTime(1991, 1, 1)
            };

            ////  AutoMapper 方式1
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Dtos.User, Entities.User>().ReverseMap();
            //});
            //var dtoUser1 = Mapper.Map<Dtos.User>(entityUser);
            //var entityUser1 = Mapper.Map<Entities.User>(dtoUser1);

            ////  AutoMapper 方式2
            //var configuration = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<Dtos.User, Entities.User>().ReverseMap();
            //});
            //var mapper = configuration.CreateMapper();
            //var dtoUser2 = mapper.Map<Dtos.User>(entityUser);
            //var entityUser2 = mapper.Map<Entities.User>(dtoUser2);


            ////  AutoMapper 方式3
            //var dtoUser3 = entityUser.ToDto();
            //var entityUser3 = dtoUser3.ToEntity();

            // 封装的 AutoMapper
            AutoMapperManager.Instance.AddMap<Dtos.User, Entities.User>();
            var dtoUser4 = AutoMapperManager.Instance.Map<Dtos.User>(entityUser);
            var entityUser4 = AutoMapperManager.Instance.Map<Entities.User>(dtoUser4);

            Console.WriteLine("Hello World!");
        }


    }

}
