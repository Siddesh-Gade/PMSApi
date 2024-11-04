using AutoMapper;
using PMSWebApi.Models;
using PMSWebApi.ViewModels;

namespace PMSWebApi.Filters
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employees, EmployeeVM>();
            CreateMap<EmployeeVM, Employees>();
            CreateMap<Rounds, RoundsVM>();
            CreateMap<RoundsVM, Rounds>();
            CreateMap<KPIs, KpiVM>();
            CreateMap<KpiVM, KPIs>();
        }
    }
}
