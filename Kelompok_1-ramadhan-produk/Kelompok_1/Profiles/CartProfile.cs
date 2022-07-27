using AutoMapper;
using Kelompok_1.Domain;
using Kelompok_1.DTO;

namespace Kelompok_1.Profiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<Cart, CartReadDTO>();
            CreateMap<CartReadDTO, Cart>();

            CreateMap<CartCreateDTO, Cart>();
            CreateMap<Cart, CartCreateDTO>();

            //CreateMap<Produk, ProdukCreateDTO>();

            //CreateMap<ProdukCreateDTO, Produk>();

            //CreateMap<KategoriCreateToExistProdukDTO, Kategori>();

            //CreateMap<AddKateWithPr, Kategori>();

            //CreateMap<Produk, ProdukReadDTO>();

            //CreateMap<Kategori, ProdukReadDTO>();

            //CreateMap<Kategori, KatePrRead>();
        }
    }
}
