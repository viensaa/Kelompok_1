using AutoMapper;
using Kelompok_1.Domain;
using Kelompok_1.DTO;

namespace Kelompok_1.Profiles
{
    public class ProdukProfile : Profile
    {
        public ProdukProfile()
        {
            CreateMap<ProdukReadDTO, Produk>();
            CreateMap<Produk, ProdukReadDTO>();

            CreateMap<ProdukCreateDTO, Produk>();
            CreateMap<Produk, ProdukCreateDTO>();
        }
    }
}
