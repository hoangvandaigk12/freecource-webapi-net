using AutoMapper;
using MyWebApilApp.Data;
using MyWebApilApp.Models;

namespace MyWebApilApp.Helpers
{
    public class ApplicatiionMapper : Profile
    {
        public ApplicatiionMapper()
        {
            CreateMap<Book, BookModel>().ReverseMap();
            CreateMap<Computer, ComputerModel>().ReverseMap();
        }
    }
}
