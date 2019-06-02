using AutoMapper;
using Common.DTO.Question;
using DataAccessLayer.Entities;

namespace BusinessLogic.System
{
	public static class MapperInitializer
	{
		public static void InitMapper()
		{
			Mapper.Initialize(cfg => cfg.CreateMap<Question, QuestionDTO>());
		}
	}
}