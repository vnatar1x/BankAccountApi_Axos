using AutoMapper;
using BanAccountApi_Models.DataModels;
using BanAccountApi_Models.ViewModels;

namespace BankAccountApi.Mappers
{
    public class BankMapperProfile : Profile
    {
        public BankMapperProfile()
        {
            CreateMap<AccountViewModel, AccountDataModel>();
            CreateMap<CustomerViewModel, CustomerDataModel>();

            CreateMap<AccountDataModel, AccountViewModel>();
            CreateMap<CustomerDataModel, CustomerViewModel>();
        }
    }
}