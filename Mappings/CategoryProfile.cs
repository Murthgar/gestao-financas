using AutoMapper;
using GestãoFinancas.Models;
using GestãoFinancas.Dtos;

namespace GestãoFinancas.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryDto>();
        }
    }

}