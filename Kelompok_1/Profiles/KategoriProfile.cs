using Kelompok_1.Domain;
using Kelompok_1.DTO;
using AutoMapper;

namespace Kelompok_1.Profiles
{
    public class KategoriProfile : Profile
    {
        public KategoriProfile()
        {
            CreateMap<Kategori, KategoriReadDTO>();
           // CreateMap<KategoriReadDTO, Kategori>();

            CreateMap<KategoriCreateDTO, Kategori>();

            CreateMap<Produk, ProdukCreateDTO>();

            CreateMap<ProdukCreateDTO, Produk>();

            CreateMap<KategoriCreateToExistProdukDTO, Kategori>();

            CreateMap<AddKateWithPr, Kategori>();

            CreateMap<Produk, ProdukReadDTO>();

            CreateMap<Kategori, ProdukReadDTO>();

            CreateMap<Kategori, KatePrRead>();

            



        }
    }
}
