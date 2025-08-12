using AutoMapper;
using GestãoFinancas.Models;
using GestãoFinancas.Dtos;

public class ExpenseProfile : Profile
{
    public ExpenseProfile()
    {
        CreateMap<ExpenseDto, Expense>();
        CreateMap<Expense, ExpenseReadDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
    }
}