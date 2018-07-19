using AutoMapper.Configuration;
using System.Collections.Generic;
using System.Data;

namespace AutoMapper.Demo
{
    /// <summary>
    /// AutoMapper帮助类
    /// </summary>
    public class AutoMapperManager
    {
        private static readonly MapperConfigurationExpression _mapperConfiguration = new MapperConfigurationExpression();

        static AutoMapperManager()
        {
        }

        private AutoMapperManager()
        {
            Mapper.Initialize(_mapperConfiguration);
        }

        public static AutoMapperManager Instance { get; } = new AutoMapperManager();

        /// <summary>
        /// 添加映射关系
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        public void AddMap<TSource, TDestination>() where TSource : class, new() where TDestination : class, new()
        {
            _mapperConfiguration.CreateMap<TSource, TDestination>().ReverseMap();
        }

        /// <summary>
        /// 获取映射值
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public TDestination Map<TDestination>(object source) where TDestination : class, new()
        {
            if (source == null)
            {
                return default(TDestination);
            }

            return Mapper.Map<TDestination>(source);
        }

        /// <summary>
        /// 获取集合映射值
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public IEnumerable<TDestination> Map<TDestination>(IEnumerable<object> source) where TDestination : class, new()
        {
            if (source == null)
            {
                return default(IEnumerable<TDestination>);
            }

            return Mapper.Map<IEnumerable<TDestination>>(source);
        }

        /// <summary>
        /// 获取映射值
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public TDestination Map<TSource, TDestination>(TSource source) where TSource : class, new() where TDestination : class, new()
        {
            if (source == null)
            {
                return default(TDestination);
            }

            return Mapper.Map<TSource, TDestination>(source);
        }

        /// <summary>
        /// 获取集合映射值
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> source) where TSource : class, new() where TDestination : class, new()
        {
            if (source == null)
            {
                return default(IEnumerable<TDestination>);
            }

            return Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(source);
        }

        /// <summary>
        /// 读取DataReader内容
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        public IEnumerable<TDestination> Map<TDestination>(IDataReader reader)
        {
            if (reader == null)
            {
                return new List<TDestination>();
            }

            var result = Mapper.Map<IEnumerable<TDestination>>(reader);

            if (!reader.IsClosed)
            {
                reader.Close();
            }

            return result;
        }
    }
}
