using AutoMapper;
using Kelompok_1.Domain;
using Kelompok_1.DTO;

namespace Kelompok_1.Profiles
{
    public class TransaksiProfile : Profile
    {
        public TransaksiProfile()
        {
            CreateMap<TransaksiReadDTO, Transaksi>();
            CreateMap<Transaksi, TransaksiReadDTO>();

            CreateMap<Cart, ProdukCartDTO >();
            CreateMap<ProdukCartDTO, Produk>();
            CreateMap<TransaksiReadDTO, Produk>();

            CreateMap<Cart, CartProdukReadDTO>();
            CreateMap<CartProdukReadDTO, Produk>();
            CreateMap<User, UserCartDTO>();
            CreateMap<UserCartDTO, User>();
            CreateMap<AddExistingCartToTransaksiDTO, Transaksi>();

            //CreateMap<TransaksiReadDTO, ProdukCartDTO>();
            //CreateMap<Transaksi, ProdukCartDTO>();
            //CreateMap<TransaksiReadDTO, Cart>();
            //CreateMap<Cart, TransaksiReadDTO>();

        }
    }
}
