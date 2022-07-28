using AutoMapper;
using Kelompok_1.Domain;
using Kelompok_1.DTO;

namespace Kelompok_1.Profiles
{
    public class CartProfile : Profile
    {

        public CartProfile()
        {
            CreateMap<AddExistingProdukToCartDTO, User>();
            CreateMap<AddExistingProdukToCartDTO, Cart>();
            CreateMap<AddExistingProdukToCartDTO, Produk>();

            CreateMap<CartProdukReadDTO, Cart>();
            CreateMap<Cart, CartProdukReadDTO>();
            

            CreateMap<ProdukCartDTO, Produk>();
            CreateMap<Produk, ProdukCartDTO>();

            
           // CreateMap<Cart, ProdukCartDTO>();

        }
    }
}